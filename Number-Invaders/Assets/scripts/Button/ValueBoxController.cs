using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueBoxController : MonoBehaviour
{
    /*
        Controller of boxes contining values associated with plus and minus button
    */
    public TextMesh valueText;                                                      // The text of the box
    public string parameter;                                                        // parameter associated

///////////////////////// START FUNCTIONS /////////////////////////////////// 

    void Start()
    {
        int value = GetParameterValue();                                            // We get the initial value of the parameter
        ChangeValueText(value);                                                     // We update the text    
    }

////////////////////////////////////////////////////////////

    /*
        Regarding the associated parameter, we set the listener and we get the value of the parameter
    */
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

    /*
        Change the text of the box
    */
    private void ChangeValueText(int newValue){
        valueText.text = newValue.ToString();
    }
}
