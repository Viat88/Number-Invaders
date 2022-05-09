using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{


    private bool gunHolded = false;

    private bool isInvincible = false;
    public float invincibilityDelay = 3f;
    public float invincibilityFlashDelay = 0.15f;
    public GameObject alienText;
    public GameObject alien;



///////////////////////// START FUNCTIONS ///////////////////////////////////  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player1Manager.current.gunTaken == gameObject || Player2Manager.current.gunTaken == gameObject){
            gunHolded = true;                                                                                   // The gun is holded
        }

        else{
            gunHolded = false;                                                                                  // The gun isn't holded
        }
    }



////////////////////////////////////////////////////////////

    private void OnTriggerEnter( Collider other){
        
        if (other.CompareTag("Player1")){      // If it's player 1
            Player1Manager.current.onAGun = true;                                           // We are on a gun                                                               
            StartCoroutine (Player1Manager.current.TakeGunRoutine(gameObject));             // We check if player really wants the gun
        }


        
        if (other.CompareTag("Player2")){
            Player2Manager.current.onAGun = true;                                           // We are on a gun
            StartCoroutine (Player2Manager.current.TakeGunRoutine(gameObject));             // We check if player really wants the gun
        }

        if (other.CompareTag("AlienMissile") && gunHolded){
            GunTouched(other.gameObject);
        }
    }


////////////////////////////////////////////////////////////


    private void OnTriggerExit( Collider other){

        if (other.CompareTag("Player1")){                                                   // If it's one of the 2 players
            Player1Manager.current.onAGun = false;                                          // We are not on a gun yet
            StopCoroutine (Player1Manager.current.TakeGunRoutine(gameObject));
        }

        if (other.CompareTag("Player2")){                                                   // If it's one of the 2 players
            Player2Manager.current.onAGun = false;                                          // We are not on a gun yet
            StopCoroutine (Player2Manager.current.TakeGunRoutine(gameObject));
        }
    }

////////////////////////////////////////////////////////////

    private void GunTouched(GameObject alienMissile){

        if (!isInvincible){                                                             // We check he's not invicible
            SoundManager.current.PlayGunTouchedSound();                                 // We play the sound
            Destroy(alienMissile);                                                      // We destroy alien missile
            GameStateManager.current.TakeDamage();                                      // We inform GameStateManager that players have taken damage
            isInvincible = true;                                                        // He is no more invicible
            StartCoroutine(InvicibilityFlash());
            StartCoroutine(HandleInvicibilityDelay());
        }
    }


////////////////////////////////////////////////////////////

    private IEnumerator InvicibilityFlash(){

        while (isInvincible){
            alien.GetComponent<MeshRenderer>().enabled = false;
            alienText.GetComponent<MeshRenderer>().enabled = false;
            yield return new WaitForSeconds(invincibilityFlashDelay);
            alien.GetComponent<MeshRenderer>().enabled = true;
            alienText.GetComponent<MeshRenderer>().enabled = true; 
            yield return new WaitForSeconds(invincibilityFlashDelay);
        }
    }

////////////////////////////////////////////////////////////

    private IEnumerator HandleInvicibilityDelay(){

        yield return new WaitForSeconds(invincibilityDelay);
        isInvincible = false;
    }

}
