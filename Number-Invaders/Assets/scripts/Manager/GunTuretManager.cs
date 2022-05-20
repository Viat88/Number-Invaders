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
        StopCoroutine(ShootMissileCoroutine());
    }

////////////////////////////////////////////////////////////

    public void PlayerHolding(string name){

        if (name == "Player1"){
            player1Handling = true;
            StartCoroutine(ShootMissileCoroutine());
        }

        if (name == "Player2"){
            player2Handling = true;
            StartCoroutine(ShootMissileCoroutine());
        }
    }

////////////////////////////////////////////////////////////

    private IEnumerator ShootMissileCoroutine(){

        while (player1Handling || player2Handling){
            CreateMissile();
            yield return new WaitForSeconds(delayBetweenMissiles);
            ShootMissile();
        }
    }

////////////////////////////////////////////////////////////

    private void CreateMissile(){
        currentMissile = Instantiate (missilePrefab, new Vector3(0,0,0) , new Quaternion(0,0,0,0));
        currentMissile.transform.localEulerAngles = transform.localEulerAngles;
        currentMissile.transform.parent = gameObject.transform;
        currentMissile.transform.position = new Vector3(50f, 7f , 50f);
        
        
        
    }

////////////////////////////////////////////////////////////

    private void ShootMissile(){
        currentMissile.transform.parent = null;
        currentMissile.GetComponent<Translate>().enabled = true;
    }
}
