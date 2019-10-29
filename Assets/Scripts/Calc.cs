﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Calc : MonoBehaviour
{
    public Text output;
    string answer;
    int operationCount = 0;
    double number1;
    double number2;
    char operation = ' ';

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
            number1 = 0;
            number2 = 0;
        }
        else if (value.Contains("ENTER"))
        {
            for (int i = 0; i < answer.Length; i++)
            {          
                if (answer[i] == 'x' || answer[i] == '/' || answer[i] == '+' || answer[i] == '-')
                {
                    output.text = answer.Substring(i+1);
                    number1 = Convert.ToDouble(answer.Substring(0, i));
                    number2 = Convert.ToDouble(answer.Substring(i+1));
                    operation = answer[i];
                }
            }
            if(operation == 'x')
            {
                number1 = number1 * number2;
            }
            else if (operation == '/')
            {
                number1 = number1 / number2;
            }
            else if (operation == '-')
            {
                number1 = number1 - number2;
            }
            else if (operation == '+')
            {
                number1 = number1 + number2;
            }
            answer = number1.ToString();
        }
        else if (value.Contains("+") || value.Contains("-") || value.Contains("x") || value.Contains("/"))
        {
            operationCount++;
            if (operationCount == 2)
            {
                for (int i = 0; i < answer.Length; i++)
                {
                    if (answer[i] == 'x' || answer[i] == '/' || answer[i] == '+' || answer[i] == '-')
                    {
                        output.text = answer.Substring(i + 1);
                        number1 = Convert.ToDouble(answer.Substring(0, i));
                        number2 = Convert.ToDouble(answer.Substring(i + 1));
                        operation = answer[i];
                    }
                }
                if (operation == 'x')
                {
                    number1 = number1 * number2;
                }
                else if (operation == '/')
                {
                    number1 = number1 / number2;
                }
                else if (operation == '-')
                {
                    number1 = number1 - number2;
                }
                else if (operation == '+')
                {
                    number1 = number1 + number2;
                }
                answer = number1.ToString();
                operationCount = 1;
            }
            answer += value;
        }
        else
        {
            answer += value;
        }
        output.text = answer;
    }
}
