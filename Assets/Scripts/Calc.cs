using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calc : MonoBehaviour
{
    public Text button;
    public string answer = "0";
    public string firstNum = "0", secondNum = "0";
    public string op = "";
    public GameObject outputPanel;
    private Output output;

    public void onClick(){
        output = GetComponent<Output>();
        if (op == "")
        {
            switch (button.text)
            {
                case "+":
                case "-":
                case "*":
                case "/":
                case "+/-":
                    op = button.text;
                    break;
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    firstNum += button.text;
                    break;
            }
        }
        else
        {
            if (secondNum == "")
            {
                switch (button.text)
                {
                    case "+":
                    case "-":
                    case "*":
                    case "/":
                    case "+/-":
                        op = button.text;
                        break;
                    case "0":
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                        secondNum += button.text;
                        break;
                }
            }
            else
            {
                switch (button.text)
                {
                    case "+":
                    case "-":
                    case "*":
                    case "/":
                    case "+/-":
                        if (op == "+")
                        {
                            answer = (Convert.ToDouble(firstNum) + Convert.ToDouble(secondNum)).ToString();
                        }
                        else if (op == "-")
                        {
                            answer = (Convert.ToDouble(firstNum) - Convert.ToDouble(secondNum)).ToString();
                        }
                        else if (op == "*")
                        {
                            answer = (Convert.ToDouble(firstNum) * Convert.ToDouble(secondNum)).ToString();
                        }
                        else if (op == "/")
                        {
                            answer = (Convert.ToDouble(firstNum) / Convert.ToDouble(secondNum)).ToString();
                        }
                        else if (op == "+/-")
                        {
                            answer = (Convert.ToDouble(firstNum) * -1).ToString();
                        }
                        firstNum = answer; //preparing for next operation
                        op = button.text;
                        break;
                    case "0":
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                        secondNum += button.text;
                        break;
                }
            }
        }

        if (button.text.Contains("DELETE"))
        {
            answer = "";
            firstNum = "0";
            secondNum = "0";
            op = "";
        }
        else if (button.text.Contains("ENTER"))
        {
            if (secondNum == "") //no second number input assume the user wants to execute the operation on a copy of the first number
            {
                if (op == "+")
                {
                    answer = (2 * Convert.ToDouble(firstNum)).ToString(); //a + a = 2a
                }
                else if (op == "-")
                {
                    answer = "0"; //a - a = 0
                }
                else if (op == "*")
                {
                    answer = (Convert.ToDouble(firstNum) * Convert.ToDouble(firstNum)).ToString();
                }
                else if (op == "/")
                {
                    answer = "1"; //a / a = 1
                }
                else if (op == "+/-")
                {
                    answer = (Convert.ToDouble(firstNum) * -1).ToString();
                }
            }
            else
            {
                if (op == "+")
                {
                    answer = (Convert.ToDouble(firstNum) + Convert.ToDouble(secondNum)).ToString();
                }
                else if (op == "-")
                {
                    answer = (Convert.ToDouble(firstNum) - Convert.ToDouble(secondNum)).ToString();
                }
                else if (op == "*")
                {
                    answer = (Convert.ToDouble(firstNum) * Convert.ToDouble(secondNum)).ToString();
                }
                else if (op == "/")
                {
                    answer = (Convert.ToDouble(firstNum) / Convert.ToDouble(secondNum)).ToString();
                }
                else if (op == "+/-")
                {
                    answer = (Convert.ToDouble(firstNum) * -1).ToString();
                }
            }
            firstNum = answer; //preparing for next operation
        }
        output.AnswerOutputText.text = answer;
        button.text = output.AnswerOutputText.text;
    }
}
