using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public LoginPanel loginPanel;

    public AlreadyLoggedinPanel alreadyLoggedPanel;

    public OTPPanel otpPanel;

    public GameObject view;

    public Button back;

    public static UIManager instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        OnGameStart();

        back.onClick.AddListener(QuitAndClose);
    }

    private void OnGameStart()
    {
        if (PlayerPrefs.GetString("logged-in").Equals("true"))
        {
            alreadyLoggedPanel.gameObject.SetActive(true);
        }
        else
        {
            loginPanel.gameObject.SetActive(true);
        }
        view.SetActive(false);
    }

    [DllImport("__Internal")]
    private static extern void closewindow();

    public void QuitAndClose()
    {
        Application.Quit();
        closewindow();
    }
}
