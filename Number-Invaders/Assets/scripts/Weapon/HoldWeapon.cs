using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldWeapon : MonoBehaviour
{
    private string player;

///////////////////////// START FUNCTIONS /////////////////////////////////// 

    // Start is called before the first frame update
    void Start()
    {
        GetPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

///////////////////////// TRIGGER FUNCTIONS ///////////////////////////////// 

    private void OnTriggerEnter( Collider other){

        if (other.CompareTag("Weapon")){

            if (player == "Player1"){                                                           // If it's player 1 
                Player1Manager.current.ChangeWeaponOn(other.gameObject);
            }

            if (player == "Player2"){                                                           // If it's player 2
                Player2Manager.current.ChangeWeaponOn(other.gameObject);
            }
        }
    }


/////////////////////

    private void OnTriggerExit( Collider other){

        if (player == "Player1"){                                                           // If it's Player 1
            Player1Manager.current.ChangeWeaponOn(null);                                    // He is not on a gun yet
            
            
        }

        if (player == "Player2"){                                                           // If it's Player 2
            Player2Manager.current.ChangeWeaponOn(null);                                    // He is not on a gun yet
        }
    }

////////////////////////////////////////////////////////////

    private void GetPlayer(){
        player = gameObject.tag;
    }
}
