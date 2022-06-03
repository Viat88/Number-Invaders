using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MainParameters : MonoBehaviour
{
    public static MainParameters current;
    public float timeToChooseButton;

    /*
    canShootMissile
    canShootBomb
    canMove

    number of aliens
    number of aliens shooting

    missileSpeed

    minimumSpeedShoot

    */


///////////////////////// LISTENERS /////////////////////////////////// 

    public event Action<Boolean> OnCanShootMissileChanged;
    public void CanShootMissileChanged(Boolean b){
        OnCanShootMissileChanged?.Invoke(b);
    }

    [SerializeField]
    private Boolean canShootMissile=true;
    public Boolean CanShootMissile{
        get => canShootMissile;
        set
        {
            canShootMissile = value;
            CanShootMissileChanged(canShootMissile); //Fire the event
        }
    }



    public event Action<Boolean> OnCanShootBombChanged;
    public void CanShootBombChanged(Boolean b){
        OnCanShootBombChanged?.Invoke(b);
    }

    [SerializeField]
    private Boolean canShootBomb=true;
    public Boolean CanShootBomb{
        get => canShootBomb;
        set
        {
            canShootBomb = value;
            CanShootBombChanged(canShootBomb); //Fire the event
        }
    }


    public event Action<Boolean> OnAlienMoveChanged;
    public void AlienMoveChanged(Boolean b){
        OnAlienMoveChanged?.Invoke(b);
    }

    [SerializeField]
    public Boolean canAlienMove=true;
    public Boolean CanAlienMove{
        get => canAlienMove;
        set
        {
            canAlienMove = value;
            AlienMoveChanged(canAlienMove); //Fire the event
        }
    }


    public event Action<int> OnNumberOfAliensChanged;
    public void NumberOfAliensChanged(int n){
        OnNumberOfAliensChanged?.Invoke(n);
    }

    [SerializeField]
    public int numberOfAliens=4;
    public int NumberOfAliens{
        get => numberOfAliens;
        set
        {
            numberOfAliens = value;
            NumberOfAliensChanged(numberOfAliens); //Fire the event
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
    {}


    void Update()
    {}

////////////////////////////////////////////////////////////

}
