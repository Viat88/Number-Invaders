using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{


    private bool gunHolded = false;                                          // Is the gun holded by a player
    private bool isInvincible = false;                                       // Is the player invicible (after being touched by an alien's missile)
    public float invincibilityDelay = 3f;                                    // How long has the player to be invicible 
    public float invincibilityFlashDelay = 0.15f;                            // How fast has to be the invicibility's flash
    public GameObject gunText;                                               // Text of the gun
    public GameObject gunModel;                                              // Model of the gun



///////////////////////// START FUNCTIONS ///////////////////////////////////  

    // Start is called before the first frame update
    void Start()
    {}

    // Update is called once per frame
    void Update()
    {
        if (Player1Manager.current.gunTaken == gameObject || Player2Manager.current.gunTaken == gameObject){   // If one player is holding this gun
            gunHolded = true;                                                                                  // The gun is holded
        }

        else{                                                                                                  // If not
            gunHolded = false;                                                                                 // The gun isn't holded
        }
    }



///////////////////////// TRIGGER FUNCTIONS /////////////////////////////////  

    private void OnTriggerEnter( Collider other){
        
        if (other.CompareTag("Player1")){                                                   // If it's player 1
            Player1Manager.current.onAGun = true;                                           // Player is on a gun                                                               
            StartCoroutine (Player1Manager.current.TakeGunRoutine(gameObject));             // We check if player really wants the gun
        }


        
        if (other.CompareTag("Player2")){
            Player2Manager.current.onAGun = true;                                           // We are on a gun
            StartCoroutine (Player2Manager.current.TakeGunRoutine(gameObject));             // We check if player really wants the gun
        }

        if ((other.CompareTag("AlienMissile") || other.CompareTag("Bomb wave")) && gunHolded){
            GunTouched(other.gameObject);
        }
    }


/////////////////////


    private void OnTriggerExit( Collider other){

        if (other.CompareTag("Player1")){                                                   // If it's Player 1
            Player1Manager.current.onAGun = false;                                          // He is not on a gun yet
            StopCoroutine (Player1Manager.current.TakeGunRoutine(gameObject));              // Player didn't want the gun
        }

        if (other.CompareTag("Player2")){                                                   // If it's Player 2
            Player2Manager.current.onAGun = false;                                          // He is not on a gun yet
            StopCoroutine (Player2Manager.current.TakeGunRoutine(gameObject));              // Player didn't want the gun
        }
    }

////////////////////////////////////////////////////////////

    /* If the gun is touched by an alien missile */
    private void GunTouched(GameObject alienMissile){

        if (!isInvincible){                                                             // We check he's not invicible
            
            Destroy(alienMissile);                                                      // We destroy alien missile
            GameStateManager.current.TakeDamage();                                      // We inform GameStateManager that players have taken damage
            isInvincible = true;                                                        // He is invicible
            StartCoroutine(InvicibilityFlash());                                        // We start flash 
            StartCoroutine(HandleInvicibilityDelay());                                  // We start the timer of invicibility
        }
    }


////////////////////////////////////////////////////////////

    /* Makes the gun holded flashing */
    private IEnumerator InvicibilityFlash(){

        while (isInvincible){                                                            // While player is invicible
            gunModel.GetComponent<MeshRenderer>().enabled = false;                       
            gunText.GetComponent<MeshRenderer>().enabled = false;
            yield return new WaitForSeconds(invincibilityFlashDelay);

            gunModel.GetComponent<MeshRenderer>().enabled = true;
            gunText.GetComponent<MeshRenderer>().enabled = true; 
            yield return new WaitForSeconds(invincibilityFlashDelay);
        }
    }

////////////////////////////////////////////////////////////

    /* Handles time the player has to be invicibility */
    private IEnumerator HandleInvicibilityDelay(){

        yield return new WaitForSeconds(invincibilityDelay);                          // We wait the time of invincibility
        isInvincible = false;                                                         // Gun isn't invincible no more
    }

}
