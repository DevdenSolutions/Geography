using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBase : CountryQuestion
{
    public string name { get; set; }
    public string userAnswer { get ; set ; }
    public bool Completed { get; set; }
    public bool CheckIfRight(string Answer)
    {
        if(Answer == name)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
