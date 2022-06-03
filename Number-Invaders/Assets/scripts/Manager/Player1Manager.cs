using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Manager : MonoBehaviour
{
    public static Player1Manager current;                      // Unique Player1Manager
    private GameObject weaponOn;
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
        time = timeToTakeGun;
    }

    // Update is called once per frame
    void Update(){
        TimeManager();
        if (time<=0 && weaponOn != null){
            TakeGun();
        }
    }

///////////////////////// TRIGGER FUNCTIONS ///////////////////////////////// 

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

    private void TimeManager(){

        if (weaponOn != null){
            time -= Time.deltaTime;
        }
    }

    public void ChangeWeaponOn(GameObject newWeaponOn){

        if (weaponOn != newWeaponOn){
            InitialiseTime();
            weaponOn = newWeaponOn;
        }
        
    }


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

        if (weaponHolded.name.Contains("Ray Gun")){
            weaponHolded.transform.parent = transform;                   // The gun is now a child of player
        }
        
        if (weaponHolded.name == "Gun Turret"){
            GunTuretManager.current.PlayerHolding("Player1");
        }
    }



}
