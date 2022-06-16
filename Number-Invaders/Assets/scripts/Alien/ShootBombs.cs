using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBombs : MonoBehaviour
{
    /*
        Manage the bomb shoot of aliens
    */

    public float delayBetweenBombsSalvo;
    public int numberOfBomb;
    public float delayBetweenSuccessiveBombs;
    public GameObject bombPrefab;
    public bool canShoot = true;

///////////////////////// START FUNCTIONS ///////////////////////////////////

    void Start()
    {
        StartCoroutine (ShootBombSalvoRoutine());
        MainParameters.current.OnCanShootBombChanged += ChangeCanShoot;
        canShoot = MainParameters.current.CanShootBomb;
    }

    void Update()
    {}


////////////////////////////////////////////////////////////

    private void ChangeCanShoot(bool b){
        canShoot = b;
        if (b){
            StartCoroutine(ShootBombSalvoRoutine());
        }
        else{
            StopCoroutine(ShootBombSalvoRoutine());
        }
    }

////////////////////////////////////////////////////////////

    private IEnumerator ShootBombSalvoRoutine(){
        while (canShoot){

            yield return new WaitForSeconds(delayBetweenBombsSalvo);

            if (AlienManager.current.hasCameInTheGameArea){
                AlienBombShoot();
            }
            
        }
    }

    private IEnumerator ShootBombsRoutine(){

        int count =0;

        while (count< numberOfBomb){

            GameObject newBomb = Instantiate(bombPrefab, transform.position, new Quaternion(0,0,0,0));
            newBomb.name = count.ToString();
            SoundManager.current.PlayBombShootSound();
            count += 1;

            yield return new WaitForSeconds(delayBetweenSuccessiveBombs);
            
        }
    }

////////////////////////////////////////////////////////////

    private void AlienBombShoot(){
        StartCoroutine(ShootBombsRoutine());
    }

}
