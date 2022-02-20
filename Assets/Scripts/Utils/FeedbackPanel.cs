using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;

public class FeedbackPanel : MonoBehaviour
{
    [SerializeField]
    private Button next;

    [SerializeField]
    private GameObject groupObjects, msgObj, hintBox;

    [SerializeField]
    private ToggleGroup toggleGroup;

    private bool isSelected;

    private void Start()
    {
        next.onClick.AddListener(OnNextClicked);
    }

    void OnNextClicked()
    {
        Toggle theActiveToggle = toggleGroup.ActiveToggles().FirstOrDefault();

        if (theActiveToggle== null && groupObjects.activeInHierarchy)
        {
            hintBox.SetActive(true);
            isSelected = false;
        }
        else if((theActiveToggle.gameObject.name == ("Awful") ||
            theActiveToggle.gameObject.name.Equals("Bad")) &&
            isSelected == false)
        {
            groupObjects.SetActive(false);
            msgObj.SetActive(true);
            isSelected = true;
        }
        else
        {
            UIManager.instance.QuitAndClose();
        }
    }
}

