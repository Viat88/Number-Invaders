using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Manager : MonoBehaviour
{


    public static Player1Manager current;                      // Unique Player1Manager
    public bool onAGun = false;                                // to know if player is on a gun
    public GameObject gunHolded;                               // the gun the player has
    public float timeToTakeGun;                                // time player has to be on a gun to take it



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


    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update(){}

///////////////////////// TRIGGER FUNCTIONS ///////////////////////////////// 

    private void OnTriggerExit(Collider other){
        
        if (other.name == "Gun Turret"){
            onAGun = false;
            GunTuretManager.current.NoPlayerHolding();
        }
    }

////////////////////////////////////////////////////////////

    /* Coroutine to take the gun */
    public IEnumerator TakeGunRoutine( GameObject gunToTake){
        
        yield return new WaitForSeconds(timeToTakeGun);                 // We wait the time needed to take a gun
        if (onAGun){                                                    // If he's still on a gun
            
            LetGun();                                                   // We let the potential gun holded
            TakeGun(gunToTake);                                         // We take the new gun
        }                      
    }

////////////////////////////////////////////////////////////

    /* Let the gun player is holding */
    public void LetGun(){

        if (gunHolded != null){                                      // If player already had a gun
            gunHolded.transform.parent = null;                       // We let gun on the floor before taking the new one
        }
    }


////////////////////////////////////////////////////////////

    /* Gives the gun to the player */
    private void TakeGun(GameObject gunToTake){ 
        SoundManager.current.PlayGunHandlingSound();                     // We play the sound meaning the player has taken the gun
        gunHolded = gunToTake;                                           // The gun holding by player is the one he was trying to take
        if (gunToTake.name.Contains("Ray Gun")){
            gunHolded.transform.parent = transform;                          // The gun is now a child of player
        }
        
        if (gunToTake.name == "Gun Turret"){
            GunTuretManager.current.PlayerHolding("Player1");
        }
    }



}
