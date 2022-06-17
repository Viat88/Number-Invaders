using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Manager : MonoBehaviour
{
    public static Player2Manager current;                      // Unique Player2Manager
    private GameObject weaponOn;                               // The weapon on which the player is
    [HideInInspector]
    public GameObject weaponHolded=null;                            // the gun the player has
    public float timeToTakeGun;                                // time player has to be on a gun to take it
    private float time;                                        



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
    void Start(){
        time = timeToTakeGun;                                   // We initialise time
    }

    // Update is called once per frame
    void Update(){
        time -= Time.deltaTime;                                 // we update time
        if (time<=0 && weaponOn != null){                       // If time is elapsed and player is on a gun
            TakeGun();                                          // We take the gun
        }
    }

///////////////////////// TRIGGER FUNCTIONS ///////////////////////////////// 

    /* If player exits the gun turret,he is no more on a gun and if he was holding it, he is no more holding a gun */
    private void OnTriggerExit(Collider other){
        
        if (other.name == "Gun Turret"){
            ChangeWeaponOn(null);
            if (weaponHolded.name == "Gun Turret"){
                LetGun();
            }
            GunTuretManager.current.NoPlayerHolding();
        }
    }

////////////////////////////////////////////////////////////

    /* Change the weapon on which player is with the weapon given */
    public void ChangeWeaponOn(GameObject newWeaponOn){

        if (weaponOn != newWeaponOn){
            InitialiseTime();
            weaponOn = newWeaponOn;
        }
        
    }

    /* Initialise the time variable */ 
    private void InitialiseTime(){
        time = timeToTakeGun;
    }

////////////////////////////////////////////////////////////

    /* Let the gun player is holding */
    public void LetGun(){

        if (weaponHolded != null){                                      // If player already had a gun
            weaponHolded.transform.parent = null;                       // We let gun on the floor before taking the new one
        }
    }

////////////////////////////////////////////////////////////

    /* Gives the gun to the player */
    private void TakeGun(){ 
        SoundManager.current.PlayGunHandlingSound();                     // We play the sound meaning the player has taken the gun

        LetGun();                                                        // We let the potential gun holded
        weaponHolded = weaponOn;                                         // The gun holding by player is the one he was trying to take
        weaponOn = null;

        if (weaponHolded.name == "Gun Turret"){
            GunTuretManager.current.PlayerHolding("Player2");
        }

        else{
            if (weaponHolded.CompareTag("Weapon")){
                weaponHolded.transform.parent = transform;                   // The gun is now a child of player
        }
        }
        

    
    }
}
