using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberBoxController : MonoBehaviour
{
    /*
        Controller of boxes containing numbers we want as gun in parameters scene
    */

    public TextMesh buttonText;                                 // Text of the button
    private int number;                                         // Number associated to this button
    private List<int> availableGunList;                         // The list of gun choosen

    private float timeToChooseButton;                           // Time to choose the button (from MainParameter)
    private bool isSelected = false;                            // Is the button Selected
    private bool onButton = false;                              // Is the player on the button
    private float time;                                         // Elapsed time
    private bool alreadyDone = false;                           // Is the action to select or deselect already done


    public GameObject button;                                   // The button
    private MeshRenderer model;                                 // The model of the button
    public Color initialColor;                                  // Initial color of the button
    public Color selectedColor;                                 // Color when the button is selected                       


///////////////////////// START FUNCTIONS /////////////////////////////////// 

    void Start()
    {
        // We get the model and its color
        model = button.GetComponent<MeshRenderer>();
        model.material.color = initialColor;

        // We get the number from the text of the button
        number = int.Parse(buttonText.text);

        // We get and set time variables
        timeToChooseButton = MainParameters.current.timeToChooseButton;
        time = timeToChooseButton;

        // We set the listener of GunAvailable and we set availableGunList
        MainParameters.current.OnGunAvailableChanged += UpdateAvailableGunList;
        UpdateAvailableGunList(MainParameters.current.ListGunAvailable);

        // If the number is already selected, we update the button
        if (availableGunList.Contains(number)){
            SelectBox();
        }
        
    }

    void Update()
    {
        time -= Time.deltaTime;                                     // Increase of time throughout frames

        // If time to Choose button reached, player is still on the button and we haven't done the action before:
        if (time <=0 && onButton && !alreadyDone) {

            if (isSelected){                                        // We deselecte the button if it was selected
                DeSelectNumber();
            }
            else{                                                   // If not, we select it
                SelectNumber();
            } 
        }
    }

///////////////////////// TRIGGER FUNCTIONS /////////////////////////////////

    /*
        If player 1 or 2 come on button, we update onButton and we reset time
    */
    private void OnTriggerEnter( Collider other){

        if (other.CompareTag("Player1") || other.CompareTag("Player2")){
            onButton = true;
            time = timeToChooseButton;
            
        }
    }

/////////////////////

    /*
        If player 1 or 2 get out of the button, we update onButton and alreadyDone
    */
    private void OnTriggerExit( Collider other){

        if (other.CompareTag("Player1") || other.CompareTag("Player2")){
            onButton = false;
        }
        alreadyDone = false;
    }

////////////////////////////////////////////////////////////

    /* 
        Update the variable availableGunList and deselect the button if the number isn't inside
    */
    private void UpdateAvailableGunList( List<int> newList){

        availableGunList = newList;
        if (!availableGunList.Contains(number)){
            DeselectBox();
        }
    }

////////////////////////////////////////////////////////////

    /*
        Select the number and update the button
    */
    private void SelectNumber(){

        alreadyDone = true;                         // We are doing the action
        isSelected = true;                          // The button is now selected

        SoundManager.current.PlayClickSound();      // We play the click sound
        
        SelectBox();                                // We select the box
        AddGun();                                   // And we add the gun 
    }


    /*
        Deselect the number and update the button
    */
    private void DeSelectNumber(){
        
        alreadyDone = true;                        // We are doing the action
        SoundManager.current.PlayClickSound();     // We play the click sound

        if (availableGunList.Count > 1){           // If it's not the last gun selected

            isSelected = false;                    // The button is now deselected
            DeselectBox();                         // We deselect the box
            RemoveGun();                           // And we remove the gun
        }
        
    }

////////////////////////////////////////////////////////////

    /*
        Set the color when button is selected
    */
    private void SelectBox(){
        model.material.color = selectedColor;
    }

    /*
        Set the initial color 
    */
    private void DeselectBox(){
        model.material.color = initialColor;
    }

////////////////////////////////////////////////////////////

    /*
        Add the gun to the list of gun selected
    */
    private void AddGun(){

        if (availableGunList.Count < 3){                                    // If there is not already 3 guns, we simply add it
            availableGunList.Add(number);                                   
        } 
        else{                                                               // If there is already 3 guns
            availableGunList.RemoveAt(0);                                   // We delet the first one choosen
            availableGunList.Add(number);                                   // And we had the new one
        }
        MainParameters.current.ListGunAvailable = availableGunList;         // We update the list of gun available in MainParameters
    }

////////////////////////////////////////////////////////////

    /*
        Remove the Gun frome the list of gun selected
    */
    private void RemoveGun(){

        availableGunList.Remove(number);                                    // We remove the number
        MainParameters.current.ListGunAvailable = availableGunList;         // We update the list of gun available in MainParameters
    }
    
}
