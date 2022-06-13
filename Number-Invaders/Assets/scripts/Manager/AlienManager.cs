using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class AlienManager : MonoBehaviour
{

    /*
        Manage the aliens group
    */

    public static AlienManager current;                                 // Unique AlienManager
    public List<GameObject> alienList = new List<GameObject>();         // List of aliens
    
    

    public int aliensNumber;                                            // Number of aliens that we want

    [HideInInspector]
    public Vector3 leftMissileDirection;                               // Missile on the left side when we look at aliens group

    [HideInInspector]
    public Vector3 rightMissileDirection;                              // Missile on the right side when we look at aliens group


    

    public bool isInvincible = false;                                  // Are aliens invincible
    private bool hasAlreadyBeenInvicible = false;                      // Have they already been invincible


///////////////////////// Listeners ///////////////////////////////////    

    /*
        Listener for needing a new trajectory
    */
    public event Action<Boolean> OnNewTrajectory;
    public void NewTrajectory(Boolean b){
        OnNewTrajectory?.Invoke(b);
    }

    [SerializeField]
    public Boolean newTrajectory = false;
    public Boolean IsNewTrajectory{
        get => newTrajectory;
        set
        {
            newTrajectory = value;
            NewTrajectory(newTrajectory); //Fire the event
        }
    }



    /*
        Listener about if they have already come inside the game area
    */
    public event Action<Boolean> OnHasCameInGameArea;
    public void HasCameInGameArea(Boolean b){
        OnHasCameInGameArea?.Invoke(b);
    }

    [SerializeField]
    public Boolean hasCameInTheGameArea = false;
    public Boolean HasCameInTheGameArea{
        get => hasCameInTheGameArea;
        set
        {
            hasCameInTheGameArea = value;
            HasCameInGameArea(hasCameInTheGameArea); //Fire the event
        }
    }

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

        aliensNumber = MainParameters.current.NumberOfAliens;
    }

    void Start()
    {   
        MainParameters.current.OnAlienMoveChanged += CanAliensMove;                 // We set listener of is aliens moving
        CanAliensMove(MainParameters.current.CanAlienMove);                         // We do some actions if it can't move
    }

    void Update()
    {
        if (!hasAlreadyBeenInvicible){                                              // If aliens haven't been invincible yet
            CheckAliensNumber();                                                    // We check if it has to be
        } 
    }

////////////////////////////////////////////////////////////

    /*
        We disable the script Translate if it can't move, we set the position of aliens inside the game area, its rotation and we update 
        HasCameInTheGameArea
    */
    private void CanAliensMove(bool b){
        gameObject.GetComponent<Translate>().enabled = b;

        if (!b){
            gameObject.transform.position = new Vector3(50,0,20);
            gameObject.transform.Rotate(0,-90,0);
            HasCameInTheGameArea = true;
        }
    }

////////////////////////////////////////////////////////////

    /*
        Chnage direction of missiles
    */
    public void ChangeMissilesDirection(Vector3 newLeftMissileDirection, Vector3 newRightMissileDirection){
        leftMissileDirection = newLeftMissileDirection;
        rightMissileDirection = newRightMissileDirection;
    }


////////////////////////////////////////////////////////////

    /*
        Remove the alien destroyed from the list
    */
    public void RemoveAlienFromList( GameObject alien){
        alienList.Remove(alien);
        if (alienList.Count == 0){
            GameStateManager.current.Victory();
        }
    }

////////////////////////////////////////////////////////////

    /*
        Destroy the aliens' group
    */
    public void DestroyAliensGroup(){
        Destroy(gameObject);
    }

////////////////////////////////////////////////////////////

    /*
        Check how many aliens are still alive
    */
    private void CheckAliensNumber(){

        if (alienList.Count <= aliensNumber/2){
            MakeAliensInvicible();
        }
    }

////////////////////////////////////////////////////////////

    /*
        Makes alien invincible
    */
    private void MakeAliensInvicible(){
        hasAlreadyBeenInvicible = true;
        isInvincible = true;
    }
}
