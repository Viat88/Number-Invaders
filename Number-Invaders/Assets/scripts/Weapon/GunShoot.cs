using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{

    private Vector3 previousPosition;                      // The position of the Gun during the previous frame
    private Vector3 currentPosition;                       // The position of the Gun during the current frame
    private Vector3 firstPosition;                         // The first position where the gun had a speed higher than shootSpeed
    private float shootSpeed;                              // Minimum speed of the gun to shoot
    private bool isShooting = false;                       // Is true if the speed of the gun is steel higher than shootSpeed;
    private float currentSpeed;                            // Current gun's speed
    public GameObject laserPrefab;                         // Laser's prefab
    private Vector3 direction;                             // The direction the laser has to follow
    public float shootCoolDown;                            // Time between 2 succesives player's shot
    private float shootTimer;                              // Time before player can shoot (value decrease throughout the time)
    public float minimumLengthShot;                        // The minimum length of the shot movement that player has to do
    private bool firstTime = false;                        // Tells if the first time (since player shot) that shootTimer is lower than 0
    private int laserNumber;






///////////////////////// START FUNCTIONS ///////////////////////////////////  

    void Start(){
        shootSpeed = MainParameters.current.MiniShootSpeed;
        currentPosition = transform.position;              // We get the initial position of the gun
        laserNumber = int.Parse(gameObject.transform.GetChild(0).GetComponent<TextMesh>().text);
    }

    void Update()
    {
        shootTimer -= Time.deltaTime;                      // We decrease shootTimer
        previousPosition = currentPosition;                // previousPosition is the old currentPosition
        currentPosition = transform.position;              // We get the new current position

        if (shootTimer <= 0){                              // If he can shoot
            
            if (firstTime){                                // If shootTimer<0 for the first time since player shot, we say it to player with the sound
                SoundManager.current.PlayReloadingSound(); // We play the sound
                firstTime =false;                          // It's not his first time
            }
            CheckShoot();                                  // We check that he wants to shoot
        }
        
    }


////////////////////////////////////////////////////////////


    /* Calcul the current Speed and update positions */
    private void CalculSpeed(){

        currentSpeed = Vector3.Distance(currentPosition, previousPosition) / Time.deltaTime;        // Calcul of the current speed
    }

////////////////////////////////////////////////////////////


    /* Check that the player wants to shoot */
    private void CheckShoot(){

        CalculSpeed();                                                               // We calcule the current speed and update positions
        bool isHolded = gameObject.GetComponent<GunManager>().gunHolded;

        if (currentSpeed >= shootSpeed && !isShooting && isHolded){                              // If the player is shooting and if he wasn't shooting before
                                                    
            isShooting = true;                                                       // We set that he's shooting
            firstPosition = previousPosition;                                        // We save the first position
            
        }

        // If player was already shooting and still have the good speed, we do nothing

        

        if (currentSpeed < shootSpeed && isShooting && CheckLength() && isHolded){               // The shot movement is done 
            LaserShoot();                                                            // We whoot
            isShooting = false;                                                      // Player isn't shooting anymore
            shootTimer = shootCoolDown;                                              // We set again shootTimer
        }


        // If speed wasn't enough high but player wasn't shooting, we do nothing
    }


////////////////////////////////////////////////////////////

    /* Create the laser shoot */
    private void LaserShoot(){

        firstTime = true;                                                                              // As he shot, it will be the first time shootTimer<0
        GameObject newLaser = Instantiate(laserPrefab, transform.position, new Quaternion(0,0,0,0));   // We create a new laser

        newLaser.name = laserNumber.ToString();
        newLaser.transform.rotation = Quaternion.LookRotation (direction);                             // We turn the laser in the good direction
        SoundManager.current.PlayGunShootSound();                                                      // We play shoot sound

    }


////////////////////////////////////////////////////////////

    /* Check the lenght of the player's movement to know if it's enough long*/
    private bool CheckLength(){
        direction = previousPosition - firstPosition;                                                           // Previous position is the last one
        float length = Mathf.Sqrt(direction.x*direction.x + direction.y*direction.y + direction.z*direction.z); // Calcul of movement's length
        return length >= minimumLengthShot;                                                                     // true if it's enough long

    }

////////////////////////////////////////////////////////////

    
}
