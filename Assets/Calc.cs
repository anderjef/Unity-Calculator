using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Calc : MonoBehaviour
{

	//public TextMeshPro text;
	public GameObject output;
	private TextMeshProUGUI outputText;

	//private double current = 0.0;
	//private double previous = 0.0;
    string text = "";


	private bool isNegative = false;

	public void button0() {
		text += "0";
        outputText.SetText(text);
	}

	public void button1() {
        text += "1";
        outputText.SetText(text);

    }

	public void button2() {
        text += "2";
        outputText.SetText(text);
    }

    public void button3() {
        text += "3";
        outputText.SetText(text);
    }

    public void button4() {
        text += "4";
        outputText.SetText(text);
    }

    public void button5() {
        text += "5";
        outputText.SetText(text);
    }

    public void button6() {
        text += "6";
        outputText.SetText(text);
    }

	public void button7() {
        text += "1";
        outputText.SetText(text);
    }

	public void button8() {
        text += "8";
        outputText.SetText(text);
    }

	public void button9() {
        text += "9";
        outputText.SetText(text);
    }

	public void buttonAdd() {
        text += "+";
        outputText.SetText(text);
    }

	public void buttonMinus() {
        text += "-";
        outputText.SetText(text);
    }

	public void buttonMult() {
        text += "*";
        outputText.SetText(text);
    }

	public void buttonDivide() {
        text += "/";
        outputText.SetText(text);
    }

	public void buttonDecimal() {
        text += ".";
        outputText.SetText(text);
    }

	public void buttonEnter() {
        //calculator logic
	}

	public void buttonDelete() {
        text = text.Remove(text.Length - 1);
        outputText.SetText(text);
    }

	public void buttonPlusMinus() {
		isNegative = !isNegative;
	}

    // Start is called before the first frame update
    void Start()
    {
    	outputText = output.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*void SetOutput(double value) {
    	outputText.SetText(value.ToString());
    }*/
}
