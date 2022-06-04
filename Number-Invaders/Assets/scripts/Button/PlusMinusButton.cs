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


    void Start()
    {
        timeToChooseButton = MainParameters.current.timeToChooseButton;
    }


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
                if (MainParameters.current.NumberOfAliens - step >=1){
                    MainParameters.current.NumberOfAliens = MainParameters.current.NumberOfAliens - step;
                }
                
            }
        }

        if (parameter == "miniShootSpeed"){
            if (isPlus){
                MainParameters.current.MiniShootSpeed = MainParameters.current.MiniShootSpeed + step;
            } 
            else{
                if (MainParameters.current.MiniShootSpeed - step >=50){
                    MainParameters.current.MiniShootSpeed = MainParameters.current.MiniShootSpeed - step;
                }
                
            }
        }

        if (parameter == "sumFactor"){
            if (isPlus){
                MainParameters.current.SumFactor = MainParameters.current.SumFactor + step;
            } 
            else{
                if (MainParameters.current.SumFactor - step >=1){
                    MainParameters.current.SumFactor = MainParameters.current.SumFactor - step;
                }
                
            }
        }

        if (parameter == "miniShootLength"){
            if (isPlus){
                MainParameters.current.MiniShootLength = MainParameters.current.MiniShootLength + step;
            } 
            else{
                if (MainParameters.current.MiniShootLength - step >=1){
                    MainParameters.current.MiniShootLength = MainParameters.current.MiniShootLength - step;
                }
                
            }
        }
    }
}
