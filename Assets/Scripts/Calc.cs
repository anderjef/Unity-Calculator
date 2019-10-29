using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Calc : MonoBehaviour
{
    public Text output;
    string answer;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Test");
    }

    public void onClick(){
        //Debug.Log(EventSystem.current.currentSelectedGameObject.name);
        string value = EventSystem.current.currentSelectedGameObject.name;
        if (value.Contains("DELETE"))
        {
            answer = "";
        }
        else
        {
            answer += value;
        }
        output.text = answer;
    }
}
