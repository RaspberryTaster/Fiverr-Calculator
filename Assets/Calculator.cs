using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Calculator : MonoBehaviour
{
    public string result;
    public TextMeshProUGUI answerBox;
    public TextMeshProUGUI resultBox;
    // Start is called before the first frame update
    void Start()
    {
     //   float number = Convert.ToSingle(result);
       // Debug.Log(number);

    }
    public int value2;
    public static char[] mathOperators = new char[] { '+', '-', '÷', '×', '=' };
    public static char[] acceptedOperators = new char[] { '+', '-' };
    // Start is called before the first frame update

    bool noNumbersAddedYet = true;

    public string firstInput;
    public string secondInput;

    public float firstInputFloat
	{
        get
		{
            return Convert.ToSingle(firstInput);
		}
	}
    public float secondInputFloat
	{
        get
		{
            return Convert.ToSingle(secondInput);
        }
	}
    public string mathOperator;
    public int index = 0;
    public void Append(string value)
    {
        if (value.Length != 1) return;

        char[] charArray = value.ToCharArray();
        if (result.Length >= 1 && IsOperator(charArray[0]) && IsAcceptedOperator(charArray[0]) && (index == 2 && char.IsDigit(result[result.Length - 1]))) return;
        if (IsOperator(charArray[0]) && !IsAcceptedOperator(charArray[0]) && noNumbersAddedYet) return;

        if (result.Length >= 1)
        {
            char c = result[result.Length - 1];
            Debug.Log(c);
            if (char.IsDigit(c) && IsOperator(charArray[0]))
            {
                index++;
            }

        }
    

        if (index == 0)
        {
            if (firstInput.Contains(".") && value == ".") return;
            firstInput += value;
        }
        else if (index == 1)
        {
            if (value == ".") return;
            mathOperator = value;
            index++;
        }
        else if(index == 2)
		{
            if (secondInput.Contains(".") && value == ".") return;
            secondInput += value;
		}

        result += value;
        answerBox.text = result;
        
        if (char.IsDigit(charArray[0]))
        {
            noNumbersAddedYet = false;
        }
    }

    bool IsOperator(char value)
	{

        foreach(char c in mathOperators)
		{
            if (value == c) return true;
		}

        return false;
	}

    bool IsAcceptedOperator(char value)
	{
        foreach (char c in acceptedOperators)
        {
            if (value == c) return true;
        }

        return false;
    }

	public void Clear()
	{
        result = "";
        index = 0;
        answerBox.text = result;
        firstInput = "";
        secondInput = "";
        mathOperator = "";
        resultBox.text = "";
    }
    public float resultNumber;
	public void Calculate()
    {
        if (firstInput.Length == 0 || mathOperator.Length == 0 || secondInput.Length == 0) return;

        switch(mathOperator)
		{
            case "÷":
                resultNumber = firstInputFloat / secondInputFloat;
                break;
            case "+":
                resultNumber = firstInputFloat + secondInputFloat;
                break;
            case "-":
                resultNumber = firstInputFloat - secondInputFloat;
                break;
            case "×":
                resultNumber = firstInputFloat * secondInputFloat;
                break;
        }

        resultBox.text = resultNumber.ToString();
    }
}
