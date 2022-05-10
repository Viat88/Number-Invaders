using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Manager : MonoBehaviour
{
    public static Player2Manager current;                      // Unique Player2Manager
    public bool onAGun = false;                                // to know if player is on a gun
    public GameObject gunTaken;                                // the gun the player has
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



////////////////////////////////////////////////////////////

    /* Coroutine to take the gun */
    public IEnumerator TakeGunRoutine( GameObject gunToTake){
        
        yield return new WaitForSeconds(timeToTakeGun);                 // We wait the time needed to take a gun
        if (onAGun){                                                    // If he's still on a gun
            
            if (gunTaken != null){                                      // If player already had a gun
                gunTaken.transform.parent = null;                       // We let gun on the floor before taking the new one
            }
            
            TakeGun(gunToTake);                                         // We take the new gun
        }                      
    }

////////////////////////////////////////////////////////////

    /* Gives the gun to the player */
    private void TakeGun(GameObject gunToTake){ 
        SoundManager.current.PlayGunHandlingSound();                    // We play the sound meaning the player has taken the gun
        gunTaken = gunToTake;                                           // The gun holding by player is the one he was trying to take
        gunTaken.transform.parent = transform;                          // The gun is now a child of player
    }
}
