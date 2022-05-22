using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AlienManager : MonoBehaviour
{

    public static AlienManager current;
    public bool newTrajectory = false;
    public List<GameObject> alienList = new List<GameObject>();
    [HideInInspector]
    public bool hasCameInTheGameArea = false;


    public int aliensNumber;                                            // Number of aliens that we want

    [HideInInspector]
    public Vector3 leftMissileDirection;                               // Missile on the left side when we look at aliens group

    [HideInInspector]
    public Vector3 rightMissileDirection;                              // Missile on the right side when we look at aliens group


    [HideInInspector]
    public bool canShoot = true;

    public bool isInvincible = false;
    private bool hasAlreadyBeenInvicible = false;

    

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

    void Start()
    {}

    void Update()
    {
        if (!hasAlreadyBeenInvicible){
            CheckAliensNumber();
        } 
    }

////////////////////////////////////////////////////////////


    public void ChangeAliensDirection(Vector3 newLeftMissileDirection, Vector3 newRightMissileDirection){
        leftMissileDirection = newLeftMissileDirection;
        rightMissileDirection = newRightMissileDirection;
    }


////////////////////////////////////////////////////////////

    public void RemoveAlienFromList( GameObject alien){
        alienList.Remove(alien);
        if (alienList.Count == 0){
            GameStateManager.current.Victory();
        }
    }

////////////////////////////////////////////////////////////

    public void DestroyAliensGroup(){
        Destroy(gameObject);
    }

////////////////////////////////////////////////////////////

    private void CheckAliensNumber(){

        if (alienList.Count <= aliensNumber/2){
            MakeAliensInvicible();
        }
    }

////////////////////////////////////////////////////////////

    private void MakeAliensInvicible(){
        hasAlreadyBeenInvicible = true;
        isInvincible = true;
    }
}
