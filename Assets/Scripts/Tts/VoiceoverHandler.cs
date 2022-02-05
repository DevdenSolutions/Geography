using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class VoiceoverHandler : MonoBehaviour
{
    #region variables
    [SerializeField]
    private List<GameObject> defbgs, unmutebgs;

    [SerializeField]
    private List<Button> mutebtns, unmutebtns;
    #endregion

    private void OnEnable()
    {
        for (int i = 0; i < defbgs.Count; i++)
        {
            mutebtns[i].onClick.AddListener(OnMute);
            unmutebtns[i].onClick.AddListener(OnUnmute);
        }
    }

    private void OnMute()
    {
        AudioBGManager.Instance.PlayClickSfx();
        for (int i = 0; i < defbgs.Count; i++)
        {
            defbgs[i].SetActive(false);
            unmutebgs[i].SetActive(true);
        }
    }

    private void OnUnmute()
    {
        AudioBGManager.Instance.PlayClickSfx();
        for (int i = 0; i < defbgs.Count; i++)
        {
            defbgs[i].SetActive(true);
            unmutebgs[i].SetActive(false);
        }
    }
}
