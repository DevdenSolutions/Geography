using System.Collections;
using UnityEngine;

namespace Eduzo.Academy {
    public class NetworkChecker : MonoBehaviour
    {
        [SerializeField]
        private GameObject NetworkErrorPanel;
        public static NetworkChecker instance;

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }

        void Start()
        {
            StartCoroutine("CheckInternetConnection");
        }

        IEnumerator CheckInternetConnection()
        {
            while (true)
            {
                if (Application.internetReachability == NetworkReachability.NotReachable)
                {
                    NetworkErrorPanel.SetActive(true);
                }
                else
                {
                    NetworkErrorPanel.SetActive(false);
                }
                yield return new WaitForSeconds(3f);
            }
        }
    }
}
