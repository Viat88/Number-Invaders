using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTuretManager : MonoBehaviour
{

    public static GunTuretManager current;
    public GameObject player1;
    public GameObject player2;
    public bool player1Handling = false;
    private bool player2Handling = false;
    public GameObject missilePrefab;
    public float delayBetweenMissiles;
    private GameObject currentMissile;

    
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
        StartCoroutine(ShootMissileCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

////////////////////////////////////////////////////////////

    private void Rotate(){
        if (player1Handling){
            transform.rotation = Quaternion.LookRotation(player2.transform.position - transform.position);
        }

        if (player2Handling){
            transform.rotation = Quaternion.LookRotation(player1.transform.position - transform.position);
        }
    }

////////////////////////////////////////////////////////////

    public void NoPlayerHolding(){
        player1Handling = false;
        player2Handling = false;
    }

////////////////////////////////////////////////////////////

    public void PlayerHolding(string name){

        if (name == "Player1"){
            player1Handling = true;
        }

        if (name == "Player2"){
            player2Handling = true;
        }
    }

////////////////////////////////////////////////////////////

    private IEnumerator ShootMissileCoroutine(){

        while (true){
            CreateMissile();
            yield return new WaitForSeconds(delayBetweenMissiles);
            //ShootMissile();
        }
    }

////////////////////////////////////////////////////////////

    private void CreateMissile(){
        currentMissile = Instantiate (missilePrefab, new Vector3(0,0,0) , new Quaternion(0,0,0,0));
        currentMissile.transform.parent = gameObject.transform;
        currentMissile.transform.position = new Vector3(-0.01f ,0.8f ,-0.2f);
        currentMissile.transform.localEulerAngles = transform.localEulerAngles;
        
    }

////////////////////////////////////////////////////////////

    private void ShootMissile(){
        currentMissile.GetComponent<Translate>().enabled = true;
    }
}
