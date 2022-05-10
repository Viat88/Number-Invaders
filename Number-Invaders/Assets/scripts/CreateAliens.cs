using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAliens : MonoBehaviour
{


    public float sideDistance;                      // Distance between 2 aliens one on the side of the other
    public float backDistance;                      // Distance between 2 aliens one in the back of the other

    public GameObject prefabAlien;                  // The alien prefab we will use to create aliens 

    public int aliensNumber;                        // Number of aliens that we want
    private int aliensIndex = 1;                    // Index of the alien we have to create 


///////////////////////// START FUNCTIONS /////////////////////////////////// 

    void Awake(){
        CreateAliensGroup();                        // We create aliens group before all
    }

    void Start(){}

    void Update(){}


////////////////////////////////////////////////////////////

    /* Calls CreateAlien() until we have enough aliens */
    public void CreateAliensGroup(){

        while (aliensIndex <= aliensNumber){        // While we don't have created enough aliens

            CreateAlien();                          // Create one alien
            aliensIndex +=1;                        // We go to the next alien        
        }
    }


////////////////////////////////////////////////////////////

    /* Creates a new alien:
     - on the left side of the aliens' group if its index is odd
     - on the right side of the aliens' group if its index is even
    */
    private void CreateAlien(){

        if (aliensIndex%2 == 0){            // On the left side
            GameObject newAlien = Instantiate (prefabAlien, new Vector3(sideDistance/2 ,0 , backDistance*(aliensIndex/2 -1) ), new Quaternion(0,0,0,0));
            newAlien.transform.parent = transform;
            AlienManager.current.alienList.Add(newAlien);
        }

        if (aliensIndex%2 == 1){            // On the right side
            GameObject newAlien = Instantiate (prefabAlien, new Vector3(-sideDistance/2 ,0 ,backDistance*((aliensIndex+1)/2 -1)), new Quaternion(0,0,0,0));
            newAlien.transform.parent = transform;
            AlienManager.current.alienList.Add(newAlien);
        }

        

        

    }
}
