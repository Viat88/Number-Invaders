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
        MainParameters.current.OnNumberOfAliensChanged += ChangeValueText;
    }

////////////////////////////////////////////////////////////

    private int GetParameterValue(){
        
        if (parameter == "numberOfAliens"){
            return MainParameters.current.NumberOfAliens;
        }
        return -1;
    }
    

////////////////////////////////////////////////////////////

    private void ChangeValueText(int newValue){
        valueText.text = newValue.ToString();
    }
}
