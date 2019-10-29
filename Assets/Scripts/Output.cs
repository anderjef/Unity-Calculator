using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Output : MonoBehaviour
{
    public Text AnswerOutputText;
    // Start is called before the first frame update
    void Start()
    {
        AnswerOutputText.text = "O";
    }
}
