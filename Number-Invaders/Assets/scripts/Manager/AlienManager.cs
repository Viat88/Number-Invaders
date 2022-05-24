using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class AlienManager : MonoBehaviour
{

    public static AlienManager current;
    public List<GameObject> alienList = new List<GameObject>();
    
    


    public int aliensNumber;                                            // Number of aliens that we want

    [HideInInspector]
    public Vector3 leftMissileDirection;                               // Missile on the left side when we look at aliens group

    [HideInInspector]
    public Vector3 rightMissileDirection;                              // Missile on the right side when we look at aliens group


    

    public bool isInvincible = false;
    private bool hasAlreadyBeenInvicible = false;


///////////////////////// Listeners ///////////////////////////////////    

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
    }

    void Start()
    {   
        MainParameters.current.OnAlienMoveChanged += CanAliensMove;
        CanAliensMove(MainParameters.current.CanAlienMove);
    }

    void Update()
    {
        if (!hasAlreadyBeenInvicible){
            CheckAliensNumber();
        } 
    }

////////////////////////////////////////////////////////////

    private void CanAliensMove(bool b){
        gameObject.GetComponent<Translate>().enabled = b;

        if (!b){
            gameObject.transform.position = new Vector3(50,0,20);
            HasCameInTheGameArea = true;
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
