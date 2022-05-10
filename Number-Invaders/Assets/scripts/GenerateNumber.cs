using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateNumber : MonoBehaviour
{

    public TextMesh alienText;                                        // The alien text that contains its number
    public int sommePower;                                            // Number of power of 2,3 or 5 we can have in maximum
    

///////////////////////// START FUNCTIONS /////////////////////////////////// 

    void Start()
    {
        int i= 0;                                                                       // Power of 2
        int j =0;                                                                       // Power of 3 
        int k=0;                                                                        // Power of 5

       while (i+j+k==0){
            i = (int) (Random.value*sommePower);                                        // Power of 2
            j = (int) (Random.value*(sommePower-i));                                    // Power of 3 
            k = (int) (Random.value*(sommePower-i-j));                                  // Power of 5
       }
        
        int alienNumber = (int) (Mathf.Pow(2, i) * Mathf.Pow(3, j) * Mathf.Pow(5, k));  // Calcul of alien's number
        alienText.text = alienNumber.ToString();                                        // Update of the alien's text
    }


    void Update(){}

////////////////////////////////////////////////////////////

}
