using UnityEngine;
using System.Collections;
using System.Linq;

namespace Crosstales.RTVoice.WebGL
{
   /// <summary>
   /// WebGL voice provider.
   /// NOTE: This provider needs "WebGL Speech Synthesis" https://assetstore.unity.com/packages/slug/81861?aid=1011lNGT
   /// </summary>
   [HelpURL("https://www.crosstales.com/media/data/assets/rtvoice/api/class_crosstales_1_1_r_t_voice_1_1_web_g_l_1_1_voice_provider_web_g_l.html")]
   [ExecuteInEditMode]
   public class VoiceProviderWebGL : Provider.BaseCustomVoiceProvider
   {
      #region Variables

      private UnityWebGLSpeechSynthesis.ISpeechSynthesisPlugin speechSynthesisPlugin;
      private UnityWebGLSpeechSynthesis.SpeechSynthesisUtterance speechSynthesisUtterance;
      private UnityWebGLSpeechSynthesis.VoiceResult voiceResult;
      private bool isSpeaking;
      private bool isLoading;
      private int loadCounter;

      #endregion


      #region Properties

      public override string AudioFileExtension => "none";

      public override AudioType AudioFileType => AudioType.UNKNOWN;

      public override string DefaultVoiceName => "Google US English";

      public override bool isWorkingInEditor => false;

      public override bool isWorkingInPlaymode => true;

      public override bool isPlatformSupported => Util.Helper.isWebGLPlatform || Util.Helper.isStandalonePlatform || Util.Helper.isEditor;

      public override int MaxTextLength => 32000;

      public override bool isSpeakNativeSupported => true;

      public override bool isSpeakSupported => false;

      public override bool isSSMLSupported => false;

      public override bool isOnlineService => false;

      public override bool hasCoRoutines => true;

      public override bool isIL2CPPSupported => true;

      public override bool hasVoicesInEditor => false;

      #endregion


      #region MonoBehaviour methods

      private void Start()
      {
#if UNITY_WEBGL && !UNITY_EDITOR
         speechSynthesisPlugin = UnityWebGLSpeechSynthesis.WebGLSpeechSynthesisPlugin.GetInstance();
#else
         speechSynthesisPlugin = UnityWebGLSpeechSynthesis.ProxySpeechSynthesisPlugin.GetInstance();
#endif

         if (Application.isPlaying && speechSynthesisPlugin == null)
            Debug.LogError("Instance of 'WebGL Speech Synthesis' not found. Did you add it to the scene?", this);
         /*
         // wait for proxy to become available
         while (!_mSpeechSynthesisPlugin.IsAvailable())
         {
             yield return null;
         }
         */

         if (!Util.Helper.isEditorMode)
         {
            speechSynthesisPlugin.AddListenerSynthesisOnEnd(handleSynthesisOnEnd);

            // Get voices from proxy
            //StartCoroutine(getVoices());

            // Create an instance of SpeechSynthesisUtterance
            speechSynthesisPlugin.CreateSpeechSynthesisUtterance(utterance => speechSynthesisUtterance = utterance);

            /*
            while (null == _mSpeechSynthesisUtterance ||
                null == _mVoiceResult)
            {
                //wait
                yield return null;
            }
            */
         }
      }

      private void OnDestroy()
      {
         if (!Util.Helper.isEditorMode)
            speechSynthesisPlugin.RemoveListenerSynthesisOnEnd(handleSynthesisOnEnd);
      }

      #endregion


      #region Implemented methods

      public override void Load(bool forceReload = false)
      {
         if (!isLoading)
            StartCoroutine(load(forceReload));
      }

      private IEnumerator load(bool forceReload = false)
      {
         isLoading = true;

         if (cachedVoices?.Count == 0 || forceReload)
         {
            /*
            if (Util.Helper.isEditorMode)
            {
                cachedVoices = (new Model.Voice[] { new Model.Voice("Hit 'Play' to see all voices!", "", Model.Enum.Gender.UNKNOWN, "adult", "en") }).ToList(); //TODO improve in the future
            }
            else
            {
            */

            WaitForSeconds wfs = new WaitForSeconds(0.2f);

            if (!Util.Helper.isEditorMode)
            {
               loadCounter = 0;

               do
               {
                  loadCounter++;
                  yield return wfs;
               } while (speechSynthesisPlugin?.IsAvailable() == false && loadCounter < 20);

               if (speechSynthesisPlugin?.IsAvailable() == true)
               {
                  //Debug.Log("VoiceProviderWebGL: Load called - getVoices"); //TODO remove
                  yield return getVoices();
               }
               else
               {
                  Debug.LogError("Could not load any voices - giving up!", this);
               }
            }
         }

         isLoading = false;
      }

      public override IEnumerator Generate(Model.Wrapper wrapper)
      {
         Debug.LogError("'Generate' is not supported under WebGL!", this);
         yield return null;
      }

      public override IEnumerator SpeakNative(Model.Wrapper wrapper)
      {
         yield return speak(wrapper, true);
      }

      public override IEnumerator Speak(Model.Wrapper wrapper)
      {
         yield return speak(wrapper, false);
      }

      public override void Silence()
      {
         speechSynthesisPlugin?.Cancel();

         base.Silence();
      }

      #endregion


      #region Private methods

      private IEnumerator speak(Model.Wrapper wrapper, bool isNative)
      {
         if (speechSynthesisPlugin != null)
         {
            if (wrapper == null)
            {
               Debug.LogWarning("'wrapper' is null!", this);
            }
            else
            {
               if (string.IsNullOrEmpty(wrapper.Text))
               {
                  Debug.LogWarning("'wrapper.Text' is null or empty!", this);
               }
               else
               {
                  UnityWebGLSpeechSynthesis.Voice voice = getWebGLVoice(wrapper.Voice);

                  if (voice == null)
                  {
                     Debug.LogWarning("Voice not found - can't speak the text!", this);
                  }
                  else
                  {
                     if (isSpeaking)
                     {
                        Silence();

                        do
                        {
                           yield return null;
                        } while (isSpeaking);
                     }
                     else
                     {
                        yield return null; //return to the main process (uid)
                     }

                     speechSynthesisPlugin.SetText(speechSynthesisUtterance, prepareText(wrapper));
                     speechSynthesisPlugin.SetPitch(speechSynthesisUtterance, Mathf.Clamp(wrapper.Pitch, 0f, 1.99f));
                     speechSynthesisPlugin.SetRate(speechSynthesisUtterance, Mathf.Clamp(wrapper.Rate, 0.1f, 1.99f));
                     speechSynthesisPlugin.SetVolume(speechSynthesisUtterance, wrapper.Volume);
                     speechSynthesisPlugin.SetVoice(speechSynthesisUtterance, voice);

                     if (!isNative)
                     {
                        onSpeakAudioGenerationStart(wrapper);
                        onSpeakAudioGenerationComplete(wrapper);
                     }

                     speechSynthesisPlugin.Speak(speechSynthesisUtterance);

                     onSpeakStart(wrapper);

                     silence = false;
                     isSpeaking = true;

                     do
                     {
                        yield return null;
                     } while (!silence && isSpeaking);

                     if (!silence)
                     {
                        onSpeakComplete(wrapper);
                     }
                  }
               }
            }
         }
      }

      private IEnumerator getVoices()
      {
         System.Collections.Generic.List<Model.Voice> voices = new System.Collections.Generic.List<Model.Voice>();

         WaitForSeconds wfs = new WaitForSeconds(0.1f);
         int voiceCounter = 0;

         do
         {
            speechSynthesisPlugin.GetVoices(vr => voiceResult = vr);

            voiceCounter++;

            yield return wfs;
         } while (voiceResult == null && voiceCounter < 20);

         if (voiceResult != null)
         {
            foreach (UnityWebGLSpeechSynthesis.Voice voice in voiceResult.voices)
            {
               Model.Enum.Gender gender = Util.Helper.AppleVoiceNameToGender(voice.name);

               if (gender == Crosstales.RTVoice.Model.Enum.Gender.UNKNOWN)
                  gender = Util.Helper.WSAVoiceNameToGender(voice.name);

               if (gender == Crosstales.RTVoice.Model.Enum.Gender.UNKNOWN)
                  gender = voice.name.CTContains("female") ? Model.Enum.Gender.FEMALE : voice.name.CTContains("male") ? Model.Enum.Gender.MALE : Model.Enum.Gender.UNKNOWN;

               voices.Add(new Model.Voice(voice.name, voice.name + " (" + voice.lang + ")", gender, "adult", voice.lang, voice.voiceURI));
            }
         }
         else
         {
            Debug.LogError("Could not load any voices - giving up!", this);
         }

         cachedVoices = voices.OrderBy(s => s.Name).ToList();
         loadCounter = 0;

         onVoicesReady();
      }

      private UnityWebGLSpeechSynthesis.Voice getWebGLVoice(Model.Voice ctVoice)
      {
         if (ctVoice != null)
         {
            foreach (UnityWebGLSpeechSynthesis.Voice voice in voiceResult.voices.Where(voice => ctVoice.Identifier.Equals(voice.voiceURI)))
            {
               return voice;
            }
         }

         if (voiceResult?.voices != null && voiceResult.voices.Length > 0)
            return voiceResult.voices[0];

         return null;
      }

      private void handleSynthesisOnEnd(UnityWebGLSpeechSynthesis.SpeechSynthesisEvent speechSynthesisEvent)
      {
         if (null == speechSynthesisEvent)
            return;

         isSpeaking = false;
      }

      private static string prepareText(Model.Wrapper wrapper)
      {
         //TEST
         //wrapper.ForceSSML = false;

         /*
         if (wrapper.ForceSSML && !Speaker.isAutoClearTags)
         {
             System.Text.StringBuilder sbXML = new System.Text.StringBuilder();

             sbXML.Append("<?xml version=\"1.0\" encoding=\"UTF-8\" ?>");
             sbXML.Append("<!DOCTYPE speak PUBLIC \"-//W3C//DTD SYNTHESIS 1.0//EN\" \"http://www.w3.org/TR/speech-synthesis/synthesis.dtd\">");
             sbXML.Append("<speak version=\"1.0\" xmlns=\"http://www.w3.org/2001/10/synthesis\" xml:lang=\"");
             sbXML.Append(wrapper.Voice == null ? "en-US" : wrapper.Voice.Culture);
             sbXML.Append("\">");

             sbXML.Append(wrapper.Text);

             sbXML.Append("</speak>");

             return sbXML.ToString();
         }

         */
         return wrapper.Text;
      }

      #endregion


      #region Editor-only methods

#if UNITY_EDITOR
      public override void GenerateInEditor(Model.Wrapper wrapper)
      {
         Debug.LogError("'GenerateInEditor' is not supported for WebGL!", this);
      }

      public override void SpeakNativeInEditor(Model.Wrapper wrapper)
      {
         Debug.LogError("'SpeakNativeInEditor' is not supported for WebGL!", this);
      }
#endif

      #endregion
   }
}
// © 2019-2021 crosstales LLC (https://www.crosstales.com)