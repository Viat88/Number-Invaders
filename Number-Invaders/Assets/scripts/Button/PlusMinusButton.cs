using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusMinusButton : MonoBehaviour
{
    /*
        Manage button plus or minus in parameters scene
    */

    public bool isPlus;                                             // Is it the button plus
    public string parameter;                                        // Which parameter is associated
    public int step;                                                // What is step of the button 


    private float timeToChooseButton;                               // Time to choose button (given by MainParameters)                           
    private float time;                                             // Elapsed time
    private bool onButton = false;                                  // Is the player on the button


///////////////////////// START FUNCTIONS /////////////////////////////////// 


    void Start()
    {
        timeToChooseButton = MainParameters.current.timeToChooseButton;             // We set timeToChooseButton
    }


    void Update()
    {
        time -= Time.deltaTime;                                                     // We update time
        if (time <=0 && onButton) {                                                 // If timeToChooseButton last and player on the button
            ChangeParameter();                                                      // We update the parameter
            time = timeToChooseButton;                                              // We reinitialise time
        }
    }

///////////////////////// TRIGGER FUNCTIONS ///////////////////////////////// 

    /*
        If plyaer 1 or 2 on the button, we update onButton and we reinitialise time
    */
    private void OnTriggerEnter(Collider other){

        if (other.CompareTag("Player1") || other.CompareTag("Player2")){
            onButton = true;
            time = timeToChooseButton;
        }
    }

/////////////////////

    /*
        If player 1 or 2 quit the button, we update onButton
    */
    private void OnTriggerExit( Collider other){
        if (other.CompareTag("Player1") || other.CompareTag("Player2")){
            onButton = false;
        }
    }


////////////////////////////////////////////////////////////
    /*
        Update the value of the parameter (if it's possible) with the step defined 
    */
    private void ChangeParameter(){

        SoundManager.current.PlayClickSound();                                          // We play the sound

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

        if (parameter == "maxAlienNumber"){
            if (isPlus){
                MainParameters.current.MaxOfAliensNumber = MainParameters.current.MaxOfAliensNumber + step;
            } 
            else{
                if (MainParameters.current.MaxOfAliensNumber - step >=25){
                    MainParameters.current.MaxOfAliensNumber = MainParameters.current.MaxOfAliensNumber - step;
                }
                
            }
        }
    }
}
