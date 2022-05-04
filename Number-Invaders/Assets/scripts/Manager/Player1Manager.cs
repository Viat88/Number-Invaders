using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Manager : MonoBehaviour
{


    public static Player1Manager current;
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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {}



////////////////////////////////////////////////////////////

    public IEnumerator TakeGunRoutine( GameObject gunToTake){
        
        yield return new WaitForSeconds(timeToTakeGun);
        if (onAGun){
            
            if (gunTaken != null){                                      // If player already had a gun
                gunTaken.transform.parent = null;                       // We let gun on the floor before taking the new one
            }
            
            TakeGun(gunToTake);                                         // We take the new gun
        }                      
    }

////////////////////////////////////////////////////////////

    private void TakeGun(GameObject gunToTake){ 
        gunTaken = gunToTake;                    
        gunTaken.transform.parent = transform;
    }


}
