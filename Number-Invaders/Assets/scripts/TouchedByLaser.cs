using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchedByLaser : MonoBehaviour
{

    public TextMesh alienText;                                                 // Alien's text containing its number
    private int number;                                                        // Number of the alien
    public float destroyDelay;                                                 // The time destroying alien takes
    private bool firstTime = true;                                             // Boolean to know if we have already played the destruction's sound

///////////////////////// START FUNCTIONS ///////////////////////////////////  
    
    void Start(){
        number = int.Parse(alienText.text);                                     // We save the alien's number
    }

    // Update is called once per frame
    void Update(){

        if (number == 1 && firstTime){                                          // If the alien's number is one and we haven't played destruction sound yet
            firstTime = false;                                                  // We have already played it
            DestroyAlien();                                                     // We destroy the alien
        }
    }


///////////////////////// TRIGGER FUNCTIONS /////////////////////////////////

    private void OnTriggerEnter(Collider other){

        if (other.CompareTag("Laser")){

            SoundManager.current.PlayAlienTouchedSound();
            Debug.Log(other.gameObject.name);
            int laserNumber = int.Parse(other.gameObject.name);
            if ( number%laserNumber == 0){
                number = number/laserNumber;
                alienText.text = number.ToString();
            }
        }
    }

////////////////////////////////////////////////////////////

    /* Destroy the alien */
    private void DestroyAlien(){

        SoundManager.current.PlayAlienDestructionSound();                       // We play the sound
        AlienManager.current.RemoveAlienFromList(gameObject);                   // We remove the alien from the list of alien
        Destroy(gameObject, destroyDelay);                                      // We destroy it after waiting destroyDelay delay
        TweenScale tweenScale = gameObject.AddComponent<TweenScale>();          // new tweenScale to make reducing animation
        tweenScale.targetScale = 0;                                             // We set the target of the tweenScale to 0
        tweenScale.timeToReachTarget = destroyDelay;                            // And the time to destroyDelay

    }
}
