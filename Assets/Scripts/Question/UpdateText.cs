using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateText : MonoBehaviour
{
    public int CurrentQuestionNumber=0;

    private void Start()
    {
        UpdateSelfText();
    }

    public void UpdateSelfText()
    {
        gameObject.GetComponent<TMP_Text>().text = QuestionClient.Instance.AllCountryQuestions[CurrentQuestionNumber].name;
    }
}
