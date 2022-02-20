using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanel : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_InputField mobile;

    [SerializeField]
    private Button submit;

    private void Start()
    {
        submit.onClick.AddListener(OnSubmitClicked);
    }

    private void OnSubmitClicked()
    {
        this.gameObject.SetActive(false);
        UIManager.instance.otpPanel.gameObject.SetActive(true);
    }
}
