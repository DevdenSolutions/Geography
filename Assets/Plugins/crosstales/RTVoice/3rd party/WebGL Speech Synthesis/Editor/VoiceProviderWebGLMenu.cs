#if UNITY_EDITOR
using UnityEditor;
using Crosstales.RTVoice.EditorUtil;

namespace Crosstales.RTVoice.WebGL
{
   /// <summary>Editor component for for adding the prefabs from 'WebGL' in the "Tools"-menu.</summary>
   public static class VoiceProviderWebGLMenu
   {
      [MenuItem("Tools/" + Util.Constants.ASSET_NAME + "/Prefabs/3rd party/VoiceProviderWebGL", false, EditorUtil.EditorHelper.MENU_ID + 380)]
      private static void AddVoiceProvider()
      {
         EditorHelper.InstantiatePrefab("WebGL Speech Synthesis", $"{EditorConfig.ASSET_PATH}3rd party/WebGL Speech Synthesis/Prefabs/");
      }

      [MenuItem("Tools/" + Util.Constants.ASSET_NAME + "/Prefabs/3rd party/VoiceProviderWebGL", true)]
      private static bool AddVoiceProviderValidator()
      {
         return !VoiceProviderWebGLEditor.isPrefabInScene;
      }
   }
}
#endif
// © 2019-2021 crosstales LLC (https://www.crosstales.com)