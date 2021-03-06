using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBox : MonoBehaviour
{

    /*
        Check the box when the paramater is selected or the player is on the button
    */

    public string parameter;
    public GameObject checkObject;
    private bool alreadyDone = false;


    private float timeToChooseButton;
    private bool isChecked = true;
    private bool onButton = false;
    private float time;

///////////////////////// START FUNCTIONS ///////////////////////////////////

    void Start()
    {
        timeToChooseButton = MainParameters.current.timeToChooseButton;
        CheckIfChecked();
        time = timeToChooseButton;
    }

    void Update()
    {
        time -= Time.deltaTime;
        if (time <=0 && onButton && !alreadyDone) {
            ChangeParameter();
        }
    }

///////////////////////// TRIGGER FUNCTIONS /////////////////////////////////

    private void OnTriggerEnter( Collider other){

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
        alreadyDone = false;
    }

////////////////////////////////////////////////////////////

    private void CheckIfChecked(){
        isChecked = CheckParameter();
        checkObject.SetActive(isChecked);
    }


////////////////////////////////////////////////////////////

    private bool CheckParameter(){
        if (parameter == "canShootMissile"){
            return MainParameters.current.CanShootMissile;
        }

        if (parameter == "canShootBomb"){
            return MainParameters.current.CanShootBomb;
        }

        if (parameter == "AliensMove"){
            return MainParameters.current.CanAlienMove;
        }
        else{
            return false;
        }
    }

////////////////////////////////////////////////////////////

    private void ChangeParameter(){
        alreadyDone = true;
        SoundManager.current.PlayClickSound();
        isChecked = !isChecked;
        checkObject.SetActive(isChecked);


        if (parameter == "canShootMissile"){
            MainParameters.current.CanShootMissile = isChecked;
        }

        if (parameter == "canShootBomb"){
            MainParameters.current.CanShootBomb = isChecked;
        }

        if (parameter == "AliensMove"){
            MainParameters.current.CanAlienMove = isChecked;
        }
    }

}
