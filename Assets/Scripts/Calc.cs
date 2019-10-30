using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Calc : MonoBehaviour
{
    public Text output;
    public Text firstNumVariable;
    public Text secondNumVariable;
    public Text rememberSecondNumVariable;
    public Text opVariable;
    public Text rememberOpVariable;
    //public string answer = "0";
    //public string firstNum = "", secondNum = "", rememberSecondNum = ""; //the empty string represents a zero or otherwise it would be harder to determine if a second number has actually been input in the case that the user inputs a first number then hits an operator and then the enter/submit/equals button; secondNum should never be zero unless the user explicitly assigns it zero
    //public string op = "", rememberOp = ""; //operators

    public void Start()
    {
        output = GameObject.Find("OutputText").GetComponentInChildren<Text>();
        firstNumVariable= GameObject.Find("firstNumVariable").GetComponentInChildren<Text>();
        secondNumVariable = GameObject.Find("secondNumVariable").GetComponentInChildren<Text>();
        rememberSecondNumVariable = GameObject.Find("rememberSecondNumVariable").GetComponentInChildren<Text>();
        opVariable = GameObject.Find("opVariable").GetComponentInChildren<Text>();
        rememberOpVariable = GameObject.Find("rememberOpVariable").GetComponentInChildren<Text>();
        output.text = "0";
        firstNumVariable.text = "";
        secondNumVariable.text = "";
        rememberSecondNumVariable.text = "";
        opVariable.text = "";
        rememberOpVariable.text = "";
    }

    //+/- registers again after hitting an operator, second number, and ENTER
    public void onClick()
    {
        string buttonText = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;
        string answer = output.text;
        string firstNum = firstNumVariable.text;
        string secondNum = secondNumVariable.text;
        string rememberSecondNum = rememberSecondNumVariable.text;
        string op = opVariable.text;
        string rememberOp = rememberOpVariable.text;
        if (buttonText == "ENTER") //could turn this into a larger switch statement but that could lead to less readability
        {
            if (secondNum != "")
            {
                switch (op)
                {
                    case "+":
                        answer = (Convert.ToDouble(firstNum) + Convert.ToDouble(secondNum)).ToString();
                        break;
                    case "-":
                        answer = (Convert.ToDouble(firstNum) - Convert.ToDouble(secondNum)).ToString();
                        break;
                    case "x":
                        answer = (Convert.ToDouble(firstNum) * Convert.ToDouble(secondNum)).ToString();
                        break;
                    case "/":
                        answer = (Convert.ToDouble(firstNum) / Convert.ToDouble(secondNum)).ToString();
                        break;
                }
                rememberOp = op; //in case the user wants to continue performing the same operation on the new output value
                rememberSecondNum = secondNum; //in case the user wants to continue performing the same operation on the new output value
                op = ""; //op gets no value after an expression is evaluated
            }
            else //no second number input
            {
                if (op == "")
                {
                    if (rememberOp != "")
                    {
                        switch (rememberOp)
                        {
                            case "+":
                                answer = (Convert.ToDouble(firstNum) + Convert.ToDouble(rememberSecondNum)).ToString();
                                break;
                            case "-":
                                answer = (Convert.ToDouble(firstNum) - Convert.ToDouble(rememberSecondNum)).ToString();
                                break;
                            case "x":
                                answer = (Convert.ToDouble(firstNum) * Convert.ToDouble(rememberSecondNum)).ToString();
                                break;
                            case "/":
                                answer = (Convert.ToDouble(firstNum) / Convert.ToDouble(rememberSecondNum)).ToString();
                                break;
                            case "+/-":
                                answer = (Convert.ToDouble(firstNum) * -1).ToString();
                                break;
                        }
                    }
                    else
                    {
                        answer = firstNum; //no operator was ever input, so just return the first input number
                    }
                }
                else
                {
                    switch (op)
                    {
                        case "+":
                            answer = (Convert.ToDouble(firstNum) + Convert.ToDouble(firstNum)).ToString(); //aka 2*firstNum
                            break;
                        case "-":
                            answer = (Convert.ToDouble(firstNum) - Convert.ToDouble(firstNum)).ToString(); //aka 0
                            break;
                        case "x":
                            answer = (Convert.ToDouble(firstNum) * Convert.ToDouble(firstNum)).ToString();
                            break;
                        case "/":
                            answer = (Convert.ToDouble(firstNum) / Convert.ToDouble(firstNum)).ToString(); //aka 1
                            break;
                        case "+/-":
                            answer = (Convert.ToDouble(firstNum) * -1).ToString();
                            break;
                    }
                    rememberOp = op;
                    rememberSecondNum = secondNum;
                    op = ""; //op gets no value after an expression is evaluated
                }
            }
        }
        else if (buttonText == "DELETE") //aka clear everything
        {
            answer = "0";
            firstNum = "";
            secondNum = "";
            rememberSecondNum = ""; //should be unecessary
            op = "";
            rememberOp = ""; //should be unecessary
        }
        else if (buttonText == "BACKSPACE")
        {
            //for possible future implementation
        }
        else
        {
            switch (buttonText)
            {
                case "+":
                case "-":
                case "x":
                case "/":
                case "+/-":
                    if (secondNum != "") //must evaluate previous expression first; op has a value if secondNum does (and that value is not "+/-")
                    {
                        switch (op)
                        {
                            case "+":
                                answer = (Convert.ToDouble(firstNum) + Convert.ToDouble(secondNum)).ToString();
                                break;
                            case "-":
                                answer = (Convert.ToDouble(firstNum) - Convert.ToDouble(secondNum)).ToString();
                                break;
                            case "x":
                                answer = (Convert.ToDouble(firstNum) * Convert.ToDouble(secondNum)).ToString();
                                break;
                            case "/":
                                answer = (Convert.ToDouble(firstNum) / Convert.ToDouble(secondNum)).ToString();
                                break;
                        }
                        firstNum = answer; //in case the user immediately presses a new operator
                        secondNum = ""; //secondNum gets no value after an expression is evaluated
                        op = ""; //operator gets no value after an expression is evaluated (doesn't really matter as op is about to be assigned the value of the last button pressed)
                    }
                    if (firstNum == "") //must initialize firstNum if the user didn't
                    {
                        firstNum = "0";
                    }
                    if (buttonText == "+/-") //immediately resolve operation as only one input number is required
                    {
                        answer = (Convert.ToDouble(firstNum) * -1).ToString();
                        rememberOp = op;
                        op = ""; //operator gets no value after an expression is evaluated
                        rememberSecondNum = secondNum; //secondNum should be an empty string by this point
                        break;
                    }
                    rememberOp = ""; //forget any old operators
                    rememberSecondNum = ""; //forget any old second numbers
                    op = buttonText;
                    break;
                case ".":
                    if (op == "")
                    {
                        if (firstNum == "")
                        {
                            firstNum += "0"; //can't forget leading zero
                        }
                        else if (firstNum.Contains(".")) //can't have two decimals in the same number
                        {
                            answer = firstNum;
                            break;
                        }
                        firstNum += buttonText;
                        answer = firstNum;
                    }
                    else //an operator was selected, so new numbers refer to the second number input
                    {
                        if (secondNum == "")
                        {
                            secondNum += "0"; //can't forget leading zero
                        }
                        else if (secondNum.Contains(".")) //can't have two decimals in the same number
                        {
                            answer = secondNum;
                            break;
                        }
                        secondNum += buttonText;
                        answer = secondNum;
                    }
                    break;
                case "0":
                    if (op == "")
                    {
                        if (firstNum == "0" && buttonText == "0") //redundant zero clicked by the user
                        {
                            answer = firstNum; //should be unnecessary
                            break;
                        }
                        firstNum += buttonText;
                        answer = firstNum;
                    }
                    else //an operator was selected, so new numbers refer to the second number input
                    {
                        if (secondNum == "0" && buttonText == "0") //redundant zero clicked by the user
                        {
                            answer = secondNum; //should be unnecessary
                            break;
                        }
                        secondNum += buttonText;
                        answer = secondNum;
                    }
                    break;
                //could replace all the following with simply default case or could reserve default case for error checking
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    if (op == "")
                    {
                        if (firstNum == "0")
                        {
                            firstNum = buttonText;
                        }
                        else
                        {
                            firstNum += buttonText;
                        }
                        answer = firstNum;
                    }
                    else //an operator was selected, so new numbers refer to the second number input
                    {
                        if (secondNum == "0")
                        {
                            secondNum = buttonText;
                        }
                        else
                        {
                            secondNum += buttonText;
                        }
                        answer = secondNum;
                    }
                    break;
            }
        }

        Debug.Log(answer);
        output.text = answer;
        firstNumVariable.text = firstNum;
        secondNumVariable.text = secondNum;
        rememberSecondNumVariable.text = rememberSecondNum;
        opVariable.text = op;
        rememberOpVariable.text = rememberOp;
    }
}