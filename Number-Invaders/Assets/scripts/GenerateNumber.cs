using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateNumber : MonoBehaviour
{

    public TextMesh alienText;
    public int sommePower;                                                              // Number of power of 2,3 or 5 we can have in maximum
    


    // Start is called before the first frame update
    void Start()
    {
        int i= 0;
        int j =0;
        int k=0;

       
        i = (int) (Random.value*sommePower);                                        // Power of 2
        j = (int) (Random.value*(sommePower-i));                                    // Power of 3 
        k = (int) (Random.value*(sommePower-i-j));                                  // Power of 5 
        


        int alienNumber = (int) (Mathf.Pow(2, i) * Mathf.Pow(3, j) * Mathf.Pow(5, k));
        alienText.text = alienNumber.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
