using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlreadyLoggedinPanel : MonoBehaviour
{
    [SerializeField]
    private Button continueBtn, newLoginBtn;
    // Start is called before the first frame update
    void Start()
    {
        continueBtn.onClick.AddListener(OnContinueClicked);
        newLoginBtn.onClick.AddListener(OnLoginClicked);
    }

    private void OnContinueClicked()
    {
        this.gameObject.SetActive(false);
        UIManager.instance.view.SetActive(true);
    }

    private void OnLoginClicked()
    {
        this.gameObject.SetActive(false);
        UIManager.instance.loginPanel.gameObject.SetActive(true);
        PlayerPrefs.SetString("logged-in", "false");
    }
}
