using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootMissile : MonoBehaviour
{
    /*
        Manage the missile shoot of aliens
    */

    public float timeBetweenAlienShoot;
    public int partAliensShooting;
    private int alienShootingNumber;
    public GameObject missilePrefab;
    public bool canShoot = true;

///////////////////////// START FUNCTIONS ///////////////////////////////////

    void Start()
    {
        StartCoroutine (ShootMissileRoutine());
        MainParameters.current.OnCanShootMissileChanged += ChangeCanShoot;
        canShoot = MainParameters.current.CanShootMissile;
        NumberAliensShootingCalcul();
    }

    void Update()
    {
        NumberAliensShootingCalcul();
    }

////////////////////////////////////////////////////////////

    private void NumberAliensShootingCalcul(){
        alienShootingNumber = (int) (AlienManager.current.alienList.Count / partAliensShooting)+1;
    }

////////////////////////////////////////////////////////////
    private void ChangeCanShoot(bool b){
        canShoot = b;
        if (b){
            StartCoroutine(ShootMissileRoutine());
        }
        else{
            StopCoroutine(ShootMissileRoutine());
        }
    }

////////////////////////////////////////////////////////////
    private IEnumerator ShootMissileRoutine() 
    {
        while (canShoot)
        {   
            yield return new WaitForSeconds(timeBetweenAlienShoot); 
            
            if (AlienManager.current.hasCameInTheGameArea){
                AliensMissileShoot(); 
            }
            
            
        } 
    }

////////////////////////////////////////////////////////////

    private void AliensMissileShoot(){

        SoundManager.current.PlayAlienShootSound();

        List<int> listIndexAliensShooting = GiveListAliensShooting();          // We get all index of aliens shooting

        for (int i=0; i<listIndexAliensShooting.Count;i++){
            int j = listIndexAliensShooting[i];
            if (j%2 == 0){
                ShootAMissile(AlienManager.current.leftMissileDirection, AlienManager.current.alienList[j]);
            }
            else{
                ShootAMissile(AlienManager.current.rightMissileDirection, AlienManager.current.alienList[j]);
            }
        }
    }
////////////////////////////////////////////////////////////

    private List<int> GiveListAliensShooting(){

        List<int> listIndexAliensShooting = new List<int>();                    // List of index representing aliens containing by alienList which will shoot

        while (listIndexAliensShooting.Count < alienShootingNumber){            // While there's not the good amount of alien shooting

            int randomIndex = Random.Range(0,AlienManager.current.alienList.Count);                  // We take a random index
            if ( !listIndexAliensShooting.Contains(randomIndex) ){              // We check it hasn't already chosen
                
                listIndexAliensShooting.Add(randomIndex);                       // We had the index
            }
        }

        return listIndexAliensShooting;

    }

////////////////////////////////////////////////////////////

    public void ShootAMissile(Vector3 missileAngle, GameObject alien){

        GameObject newMissile = Instantiate (missilePrefab, alien.transform.position , new Quaternion(0,0,0,0));
        newMissile.transform.localEulerAngles = missileAngle;
    }


}
