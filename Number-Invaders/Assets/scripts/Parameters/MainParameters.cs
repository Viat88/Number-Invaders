using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MainParameters : MonoBehaviour
{
    /*
        Script that contains all main parameters
    */
    
    public static MainParameters current;                       // Unique MainParameters
    public float timeToChooseButton;                            // Time to choose a button


///////////////////////// LISTENERS /////////////////////////////////// 

    /*
        Listener of are aliens able to shoot missiles
    */
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


    /*
        Listener of are aliens able to shoot bombs
    */
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

    /*
        Listener of are aliens able to move
    */
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

    /*
        Listener of how many aliens we want
    */
    public event Action<int> OnNumberOfAliensChanged;
    public void NumberOfAliensChanged(int n){
        OnNumberOfAliensChanged?.Invoke(n);
    }

    [SerializeField]
    public int numberOfAliens;
    public int NumberOfAliens{
        get => numberOfAliens;
        set
        {
            numberOfAliens = value;
            NumberOfAliensChanged(numberOfAliens); //Fire the event
        }
    }


    /*
        Listener of many factors aliens' number can have
    */
    public event Action<int> OnSumFactorChanged;
    public void SumFactorChanged(int n){
        OnSumFactorChanged?.Invoke(n);
    }

    [SerializeField]
    public int sumFactor;
    public int SumFactor{
        get => sumFactor;
        set
        {
            sumFactor = value;
            SumFactorChanged(sumFactor); //Fire the event
        }
    }

    /*
        Listener what's the maximum value of aliens' number
    */
    public event Action<int> OnMaxOfAliensNumberChanged;
    public void MaxOfAliensNumberChanged(int n){
        OnMaxOfAliensNumberChanged?.Invoke(n);
    }

    [SerializeField]
    public int maxOfAliensNumber;
    public int MaxOfAliensNumber{
        get => maxOfAliensNumber;
        set
        {
            maxOfAliensNumber = value;
            MaxOfAliensNumberChanged(maxOfAliensNumber); //Fire the event
        }
    }


    /*
        Listener of what is the minimum shoot speed
    */
    public event Action<int> OnMiniShootSpeedChanged;
    public void MiniShootSpeedChanged(int n){
        OnMiniShootSpeedChanged?.Invoke(n);
    }

    [SerializeField]
    public int miniShootSpeed=50;
    public int MiniShootSpeed{
        get => miniShootSpeed;
        set
        {
            miniShootSpeed = value;
            MiniShootSpeedChanged(miniShootSpeed); //Fire the event
        }
    }

    /*
        Listener of what is the minimum shoot length
    */
    public event Action<int> OnMiniShootLengthChanged;
    public void MiniShootLengthChanged(int n){
        OnMiniShootLengthChanged?.Invoke(n);
    }

    [SerializeField]
    public int miniShootLength=5;
    public int MiniShootLength{
        get => miniShootLength;
        set
        {
            miniShootLength = value;
            MiniShootLengthChanged(miniShootLength); //Fire the event
        }
    }


    /*
        Listener of which guns are available
    */
    public event Action<List<int>> OnGunAvailableChanged;
    public void GunAvailableChanged(List<int> list){
        OnGunAvailableChanged?.Invoke(list);
    }

    [SerializeField]
    public List<int> listGunAvailable;
    public List<int> ListGunAvailable{
        get => listGunAvailable;
        set
        {
            listGunAvailable = value;
            GunAvailableChanged(listGunAvailable); //Fire the event
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


}
