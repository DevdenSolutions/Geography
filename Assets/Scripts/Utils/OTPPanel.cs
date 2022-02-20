using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OTPPanel : MonoBehaviour
{
    [SerializeField]
    private Button submit;

    [SerializeField]
    private TMPro.TMP_InputField schoolCode, otp;
    // Start is called before the first frame update
    void Start()
    {
        submit.onClick.AddListener(OnSubmitClicked);
    }

    private void OnSubmitClicked()
    {
        PlayerPrefs.SetString("logged-in", "true");
        this.gameObject.SetActive(false);
        UIManager.instance.view.SetActive(true);
    }
}
