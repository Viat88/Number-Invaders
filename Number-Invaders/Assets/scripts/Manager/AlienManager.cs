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

////////////////////////////////////////////////////////////
  
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
    }

    // Update is called once per frame
    void Update()
    {
        
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

    }

////////////////////////////////////////////////////////////

    private void UpdateDirection(){

        if (side == "West"){
            transform.localEulerAngles = new Vector3(0, -90 ,0);
        }

        if (side == "East"){
            transform.localEulerAngles = new Vector3(0, 90 ,0);
        }

        if (side == "South"){
            transform.localEulerAngles = new Vector3(0, 180 ,0);
        }

        if (side == "North"){
            transform.localEulerAngles = new Vector3(0, 0 ,0);
        }
    }



////////////////////////////////////////////////////////////

    private void UpdatePosition(){

        if (side == "West"){
            transform.position = new Vector3(50 - initialDistance, 0, partOfTheSide);
        }

        if (side == "North"){
            transform.position = new Vector3(partOfTheSide,0 , 50 + initialDistance);
        }

        if (side == "East"){
            transform.position = new Vector3(50 + initialDistance, 0, partOfTheSide);
        }

        if (side == "South"){
            transform.position = new Vector3(partOfTheSide,0 , 50 - initialDistance);
        }

    }


////////////////////////////////////////////////////////////

    public void NewTrajectory(){

        ChooseSide();
        UpdateDirection();
        UpdatePosition();
    }

////////////////////////////////////////////////////////////

    private void AliensShoot(){

    }

////////////////////////////////////////////////////////////
    
}
