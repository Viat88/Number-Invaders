using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusMinusButton : MonoBehaviour
{

    public bool isPlus;
    public string parameter;
    public int step;


    public float timeToChooseButton;
    private float time;
    private bool onButton = false;


///////////////////////// START FUNCTIONS /////////////////////////////////// 

    // Start is called before the first frame update
    void Start()
    {
        timeToChooseButton = MainParameters.current.timeToChooseButton;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <=0 && onButton) {
            ChangeParameter();
            time = timeToChooseButton;
        }
    }

///////////////////////// TRIGGER FUNCTIONS ///////////////////////////////// 

    private void OnTriggerEnter(Collider other){

        if (other.CompareTag("Player1") || other.CompareTag("Player2")){
            onButton = true;
            time = timeToChooseButton;
        }
    }

/////////////////////

    private void OnTriggerExit( Collider other){
        if (other.CompareTag("Player1") || other.CompareTag("Player2")){
            onButton = false;
        }
    }


////////////////////////////////////////////////////////////

    private void ChangeParameter(){
        SoundManager.current.PlayClickSound();

        if (parameter == "numberOfAliens"){
            if (isPlus){
                MainParameters.current.NumberOfAliens = MainParameters.current.NumberOfAliens + step;
            } 
            else{
                if (MainParameters.current.NumberOfAliens - step >= 0){
                    MainParameters.current.NumberOfAliens = MainParameters.current.NumberOfAliens - step;
                }
                
            }
        }
    }
}
