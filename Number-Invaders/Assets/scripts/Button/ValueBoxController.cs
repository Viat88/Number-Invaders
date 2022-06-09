using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueBoxController : MonoBehaviour
{
    public TextMesh valueText;
    public string parameter;

///////////////////////// START FUNCTIONS /////////////////////////////////// 

    void Start()
    {
        int value = GetParameterValue();
        ChangeValueText(value);       
    }

////////////////////////////////////////////////////////////

    private int GetParameterValue(){
        
        if (parameter == "numberOfAliens"){
            MainParameters.current.OnNumberOfAliensChanged += ChangeValueText;
            return MainParameters.current.NumberOfAliens;
            
        }
        if (parameter == "miniShootSpeed"){
            MainParameters.current.OnMiniShootSpeedChanged += ChangeValueText;
            return MainParameters.current.MiniShootSpeed;
        }

        if (parameter == "sumFactor"){
            MainParameters.current.OnSumFactorChanged += ChangeValueText;
            return MainParameters.current.SumFactor;
        }

        if (parameter == "miniShootLength"){
            MainParameters.current.OnMiniShootLengthChanged += ChangeValueText;
            return MainParameters.current.MiniShootLength;
        }

        if (parameter == "maxAlienNumber"){
            MainParameters.current.OnMaxOfAliensNumberChanged += ChangeValueText;
            return MainParameters.current.MaxOfAliensNumber;
        }

        
        return -1;
    }
    

////////////////////////////////////////////////////////////

    private void ChangeValueText(int newValue){
        valueText.text = newValue.ToString();
    }
}
