using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTuretManager : MonoBehaviour
{
    /*
        Manager of the gun turret
    */

    public static GunTuretManager current;                              // Unique GunTuretManager
    public GameObject player1;                                          // Player 1
    public GameObject player2;                                          // Player 2
    private bool player1Handling = false;                               // Is player 1 holding the gun turret
    private bool player2Handling = false;                               // Is player 2 holding the gun turret
    public GameObject missilePrefab;                                    // Prefab of missiles shot by gun turret
    public float delayBetweenMissiles;                                  // Delay between two shot of missiles
    private GameObject currentMissile;                                  // The missile currently waiting on the gun turret

    
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

    void Update()
    {
        Rotate();                                                       // We update the direction of the gun turret
    }

////////////////////////////////////////////////////////////
    /*
        Turn the gun turret in the direction of Player 1 if Player 2 is holding it and the inverse
    */
    private void Rotate(){
        if (player1Handling){
            transform.rotation = Quaternion.LookRotation(player2.transform.position - transform.position);
        }

        if (player2Handling){
            transform.rotation = Quaternion.LookRotation(player1.transform.position - transform.position);
        }
    }

////////////////////////////////////////////////////////////

    /* We say that no players are holding the gun turret */
    public void NoPlayerHolding(){
        player1Handling = false;
        player2Handling = false;
        StopCoroutine(ShootMissileCoroutine());
    }

////////////////////////////////////////////////////////////

    /* We get which player is holding the gun turret */
    public void PlayerHolding(string name){

        if (name == "Player1"){
            player1Handling = true;
            StartCoroutine(ShootMissileCoroutine());
        }

        if (name == "Player2"){
            player2Handling = true;
            StartCoroutine(ShootMissileCoroutine());
        }
    }

////////////////////////////////////////////////////////////

    /* Coroutine to shoot missiles */
    private IEnumerator ShootMissileCoroutine(){

        while (player1Handling || player2Handling){
            CreateMissile();
            yield return new WaitForSeconds(delayBetweenMissiles);
            ShootMissile();
        }
    }

////////////////////////////////////////////////////////////

    /* Create a new missile and place it properly */
    private void CreateMissile(){
        currentMissile = Instantiate (missilePrefab, new Vector3(0,0,0) , new Quaternion(0,0,0,0));
        currentMissile.transform.localEulerAngles = transform.localEulerAngles;
        currentMissile.transform.parent = gameObject.transform;
        currentMissile.transform.position = new Vector3(50f, 7f , 50f);
    }

////////////////////////////////////////////////////////////

    /* Shoots the missile */
    private void ShootMissile(){
        currentMissile.transform.parent = null;
        currentMissile.GetComponent<Translate>().enabled = true;
    }
}
