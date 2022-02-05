#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Crosstales.RTVoice.WebGL
{
   /// <summary>Custom editor for the 'VoiceProviderWebGL'-class.</summary>
   [CustomEditor(typeof(VoiceProviderWebGL))]
   public class VoiceProviderWebGLEditor : Editor
   {
      #region Variables

      private VoiceProviderWebGL script;

      #endregion


      #region Properties

      public static bool isPrefabInScene => GameObject.Find("WebGL Speech Synthesis") != null;

      #endregion


      #region Editor methods

      public void OnEnable()
      {
         script = (VoiceProviderWebGL)target;
      }

      public override void OnInspectorGUI()
      {
         //DrawDefaultInspector();

         if (GUILayout.Button(new GUIContent(" Learn more", EditorUtil.EditorHelper.Icon_Manual, "Learn more about WebGL Speech Synthesis.")))
         {
            Util.Helper.OpenURL(Crosstales.RTVoice.Util.Constants.ASSET_3P_WEBGL);
         }

         if (script.isActiveAndEnabled)
         {
            //add stuff if needed
         }
         else
         {
            EditorUtil.EditorHelper.SeparatorUI();
            EditorGUILayout.HelpBox("Script is disabled!", MessageType.Info);
         }
      }

      #endregion
   }
}
#endif
// © 2019-2021 crosstales LLC (https://www.crosstales.com)