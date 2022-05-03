using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAliens : MonoBehaviour
{


    public float sideDistance; //Distance between 2 aliens one on the side of the other
    public float backDistance; //Distance between 2 aliens one in the back of the other

    public GameObject prefabAlien2;
    public GameObject prefabAlien3;
    public GameObject prefabAlien5;

    public int aliensNumber;
    private int aliensIndex = 1;  //At which alien are we



    void Awake(){
        CreateAliensGroup();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }


////////////////////////////////////////////////////////////

    public void CreateAliensGroup(){

        while (aliensIndex <= aliensNumber){

            float random = Random.value;

            if (random < 0.33){
                CreateAlien(prefabAlien2, 2);
            }

            if (random >= 0.33 && random<0.66){
                CreateAlien(prefabAlien3, 3);
            }

            if (random >= 0.66){
                CreateAlien(prefabAlien5, 5);
            }

            aliensIndex +=1;
        }
    }


////////////////////////////////////////////////////////////

    private void CreateAlien(GameObject alienPrefab, int divider){

        if (aliensIndex%2 == 0){
            GameObject newAlien = Instantiate (alienPrefab, new Vector3(sideDistance/2 ,0 , backDistance*(aliensIndex/2 -1) ), new Quaternion(0,0,0,0));
            newAlien.transform.parent = transform;
            AlienManager.current.alienList.Add(newAlien);
        }

        if (aliensIndex%2 == 1){
            GameObject newAlien = Instantiate (alienPrefab, new Vector3(-sideDistance/2 ,0 ,backDistance*((aliensIndex+1)/2 -1)), new Quaternion(0,0,0,0));
            newAlien.transform.parent = transform;
            AlienManager.current.alienList.Add(newAlien);
        }

        

        

    }
}
