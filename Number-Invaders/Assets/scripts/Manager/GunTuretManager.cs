using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTuretManager : MonoBehaviour
{

    public static GunTuretManager current;
    public GameObject player1;
    public GameObject player2;
    private bool player1Handling = false;
    private bool player2Handling = false;
    
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
}
