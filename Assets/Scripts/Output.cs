using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Output : MonoBehaviour
{
    public Text AnswerOutputText;

    void Start()
    {
        AnswerOutputText.text = "O";
    }
}
