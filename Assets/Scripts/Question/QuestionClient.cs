using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionClient : MonoBehaviour
{
    #region Singelton
    private static QuestionClient _instance;

    public static QuestionClient Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        AllCountryQuestions = new List<CountryQuestion>();
        SeedData();
    }

    #endregion

    public List<CountryQuestion> AllCountryQuestions;
    int QuestionCounter = 0;
    private void Start()
    {

        //SeedData();
        

    }

    public void CountCompletedQuestions()
    {
        int totalQuestions = 0;
        foreach(var x in AllCountryQuestions)
        {
            if(x.Completed == true)
            {
                QuestionCounter++;

            }

            totalQuestions++;
        }

        print("Total Completed: " + QuestionCounter+"/"+(totalQuestions-3));
    }

    void SeedData()
    {
        CountryQuestion India = QuestionFactory.GetCountryQuestionInstance("India");
        AllCountryQuestions.Add(India);

        CountryQuestion China = QuestionFactory.GetCountryQuestionInstance("China");
        AllCountryQuestions.Add(China);

        CountryQuestion Japan = QuestionFactory.GetCountryQuestionInstance("Japan");
        AllCountryQuestions.Add(Japan);

        CountryQuestion Indonesia = QuestionFactory.GetCountryQuestionInstance("Indonesia");
        AllCountryQuestions.Add(Indonesia);

        CountryQuestion Thailand = QuestionFactory.GetCountryQuestionInstance("Thailand");
        AllCountryQuestions.Add(Thailand);

        CountryQuestion SouthKorea = QuestionFactory.GetCountryQuestionInstance("South Korea");
        AllCountryQuestions.Add(SouthKorea);

        CountryQuestion NorthKorea = QuestionFactory.GetCountryQuestionInstance("North Korea");
        AllCountryQuestions.Add(NorthKorea);

        CountryQuestion Philippines = QuestionFactory.GetCountryQuestionInstance("Philippines");
        AllCountryQuestions.Add(Philippines);

        CountryQuestion Vietnam = QuestionFactory.GetCountryQuestionInstance("Vietnam");
        AllCountryQuestions.Add(Vietnam);

        CountryQuestion Cambodia = QuestionFactory.GetCountryQuestionInstance("Cambodia");
        AllCountryQuestions.Add(Cambodia);

        CountryQuestion Malaysia= QuestionFactory.GetCountryQuestionInstance("Malaysia");
        AllCountryQuestions.Add(Malaysia);

        CountryQuestion SriLanka = QuestionFactory.GetCountryQuestionInstance("Sri Lanka");
        AllCountryQuestions.Add(SriLanka);

        CountryQuestion SaudiArabia= QuestionFactory.GetCountryQuestionInstance("Saudi Arabia");
        AllCountryQuestions.Add(SaudiArabia);

        CountryQuestion Iran = QuestionFactory.GetCountryQuestionInstance("Iran");
        AllCountryQuestions.Add(Iran);

        CountryQuestion Afghanistan = QuestionFactory.GetCountryQuestionInstance("Afghanistan");
        AllCountryQuestions.Add(Afghanistan);

        CountryQuestion Uzbekistan = QuestionFactory.GetCountryQuestionInstance("Uzbekistan");
        AllCountryQuestions.Add(Uzbekistan);

        CountryQuestion Bangladesh = QuestionFactory.GetCountryQuestionInstance("Bangladesh");
        AllCountryQuestions.Add(Bangladesh);

        CountryQuestion Nepal = QuestionFactory.GetCountryQuestionInstance("Nepal");
        AllCountryQuestions.Add(Nepal);

        CountryQuestion Iraq = QuestionFactory.GetCountryQuestionInstance("Iraq");
        AllCountryQuestions.Add(Iraq);

        CountryQuestion Syria = QuestionFactory.GetCountryQuestionInstance("Syria");
        AllCountryQuestions.Add(Syria);

        CountryQuestion Armenia= QuestionFactory.GetCountryQuestionInstance("Armenia");
        AllCountryQuestions.Add(Armenia);

        CountryQuestion Lebanon = QuestionFactory.GetCountryQuestionInstance("Lebanon");
        AllCountryQuestions.Add(Lebanon);

        CountryQuestion Yemen = QuestionFactory.GetCountryQuestionInstance("Yemen");
        AllCountryQuestions.Add(Yemen);

        CountryQuestion Pakistan = QuestionFactory.GetCountryQuestionInstance("Pakistan");
        AllCountryQuestions.Add(Pakistan);

        CountryQuestion Russia = QuestionFactory.GetCountryQuestionInstance("Russia");
        AllCountryQuestions.Add(Russia);
    }
}

public class QuestionFactory
{
    public static CountryQuestion GetCountryQuestionInstance(string name)
    {
        CountryQuestion localCountryQuestion;

        localCountryQuestion = FactoryPattern<CountryQuestion, QuestionBase>.GetInstance();

        if (localCountryQuestion != null)
        {
            localCountryQuestion.name = name;
        }

        return localCountryQuestion;
    }
}
