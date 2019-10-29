using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calc : MonoBehaviour
{
    public Text button;
    string answer = "";

    
    // Start is called before the first frame update
    public void displayAnswer(){
        button.text = answer;
    }

    public void onClick(){
        if (button.text.Contains("DELETE"))
        {
            answer = "";
        }
        else
        {
            answer = answer + button.text;
        }
        //displayAnswer();
        button.text = "yeet";
    }
}
