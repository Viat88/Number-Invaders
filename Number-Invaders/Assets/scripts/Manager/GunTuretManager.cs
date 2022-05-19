using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTuretManager : MonoBehaviour
{

    public static GunTuretManager current;
    public GameObject player1;
    public GameObject player2;
    private bool player1Handling = true;
    
///////////////////////// START FUNCTIONS ///////////////////////////////////

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
    }
}
