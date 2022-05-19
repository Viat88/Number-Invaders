using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AlienManager : MonoBehaviour
{

    public static AlienManager current;
    private string side;
    private float partOfTheSide;
    public int initialDistance;
    public List<GameObject> alienList = new List<GameObject>();
    [HideInInspector]
    public bool hasCameInTheGameArea = false;


    private Vector3 leftMissileDirection;                               // Missile on the left side when we look at aliens group
    private Vector3 rightMissileDirection;                              // Missile on the right side when we look at aliens group
    public int alienShootingNumber;
    public GameObject missilePrefab;
    public float timeBetweenAlienShoot;
    private bool canShoot = true;


    public GameObject bombPrefab;
    public int numberOfBomb;
    public float delayBetweenSuccessiveBombs;
    public float delayBetweenBombsSalvo;

    

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
        NewTrajectory();
        StartCoroutine (ShootMissileRoutine());
        StartCoroutine (ShootBombSalvoRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (alienList.Count < alienShootingNumber){                                             // If there is less alien than alienShootingNumber
            alienShootingNumber = alienList.Count;                                              // We make just shoot all aliens
        }
    }


////////////////////////////////////////////////////////////


    
    private void ChooseSide(){

        float random = Random.value;
        

        // If West side
        if (random < 0.25){
            side = "West";
            partOfTheSide = Random.value*60 + 20; // to have it between 20 and 80
        }

        // If North side
        if ( random>=0.25 && random < 0.5 ){
            side = "North";
            partOfTheSide = Random.value*60 + 20; // to have it between 20 and 80
        }

        // If East side
        if ( random>=0.5 && random < 0.75 ){
            side = "East";
            partOfTheSide = Random.value*60 + 20; // to have it between 20 and 80
        }

        // If South side
        if ( random>=0.75 ){
            side = "South";
            partOfTheSide = Random.value*60 + 20; // to have it between 20 and 80
        }

        SideLightsManager.current.LineActivation(side);
    }

////////////////////////////////////////////////////////////

    private void UpdateDirection(){

        Vector3 aliensAngle = new Vector3();

        if (side == "West"){
            aliensAngle = new Vector3(0, -90 ,0);
        }

        if (side == "East"){
            aliensAngle = new Vector3(0, 90 ,0);
        }

        if (side == "South"){
            aliensAngle = new Vector3(0, 180 ,0);
        }

        if (side == "North"){
            aliensAngle = new Vector3(0, 0 ,0);
        }

        transform.localEulerAngles = aliensAngle;
    }



////////////////////////////////////////////////////////////

    private void UpdatePosition(){

        if (side == "West"){
            transform.position = new Vector3(50 - initialDistance, 0, partOfTheSide);
            leftMissileDirection = new Vector3(0,0,0);
            rightMissileDirection = new Vector3(0,180,0);
        }

        if (side == "North"){
            transform.position = new Vector3(partOfTheSide,0 , 50 + initialDistance);
            leftMissileDirection = new Vector3(0,-90,0);
            rightMissileDirection = new Vector3(0,90,0);
        }

        if (side == "East"){
            transform.position = new Vector3(50 + initialDistance, 0, partOfTheSide);
            leftMissileDirection = new Vector3(0,180,0);
            rightMissileDirection = new Vector3(0,0,0);
        }

        if (side == "South"){
            transform.position = new Vector3(partOfTheSide,0 , 50 - initialDistance);
            leftMissileDirection = new Vector3(0,90,0);
            rightMissileDirection = new Vector3(0,-90,0);
        }

    }


////////////////////////////////////////////////////////////

    public void NewTrajectory(){

        hasCameInTheGameArea = false;
        ChooseSide();
        UpdateDirection();
        UpdatePosition();
    }

////////////////////////////////////////////////////////////

    private void AliensMissileShoot(){

        SoundManager.current.PlayAlienShootSound();

        List<int> listIndexAliensShooting = GiveListAliensShooting();          // We get all index of aliens shooting

        for (int i=0; i<listIndexAliensShooting.Count;i++){
            int j = listIndexAliensShooting[i];
            if (j%2 == 0){
                ShootMissile(leftMissileDirection, alienList[j]);
            }
            else{
                ShootMissile(rightMissileDirection, alienList[j]);
            }
        }



    }

////////////////////////////////////////////////////////////
    
    private List<int> GiveListAliensShooting(){

        List<int> listIndexAliensShooting = new List<int>();                    // List of index representing aliens containing by alienList which will shoot

        while (listIndexAliensShooting.Count < alienShootingNumber){            // While there's not the good amount of alien shooting

            int randomIndex = Random.Range(0,alienList.Count);                  // We take a random index
            if ( !listIndexAliensShooting.Contains(randomIndex) ){              // We check it hasn't already chosen
                
                listIndexAliensShooting.Add(randomIndex);                       // We had the index
            }
        }

        return listIndexAliensShooting;

    }

////////////////////////////////////////////////////////////

    public void ShootMissile(Vector3 missileAngle, GameObject alien){

        GameObject newMissile = Instantiate (missilePrefab, alien.transform.position , new Quaternion(0,0,0,0));
        newMissile.transform.localEulerAngles = missileAngle;
    }


////////////////////////////////////////////////////////////

    private IEnumerator ShootMissileRoutine() 
    {
        while (canShoot) // 2
        {   
            if (hasCameInTheGameArea){
                AliensMissileShoot(); 
            }
            
            yield return new WaitForSeconds(timeBetweenAlienShoot); 
        } 
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

    private IEnumerator ShootBombSalvoRoutine(){
        while (canShoot){
            if (hasCameInTheGameArea){
                AlienBombShoot();
            }
            yield return new WaitForSeconds(delayBetweenBombsSalvo);
        }
    }

    private IEnumerator ShootBombsRoutine(){

        int count =0;

        while (count< numberOfBomb){
            Vector3 bombPosition = transform.position;
            bombPosition.y=5;
            GameObject newBomb = Instantiate(bombPrefab, bombPosition, new Quaternion(0,0,0,0));
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
