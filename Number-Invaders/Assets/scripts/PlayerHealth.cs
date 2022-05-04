using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{


    public static PlayerHealth current;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    private int numberOfLifes = 3;  



///////////////////////// START FUNCTIONS ///////////////////////////////////  

    void Awake() 
    {
        if (current == null)
        {
            current = this;
        }
        else
        {
            Destroy(obj: this);
        }
    }

    void Start()
    {}

    void Update()
    {}


////////////////////////////////////////////////////////////

    public void TakeDamage(){

        if (numberOfLifes == 3){
            heart1.SetActive(false);
        }

        if (numberOfLifes == 2){
            heart2.SetActive(false);
        }

        if (numberOfLifes == 1){
            heart3.SetActive(false);
        }

        numberOfLifes -=1; 
    }

}
