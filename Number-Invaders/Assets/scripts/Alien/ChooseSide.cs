using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseSide : MonoBehaviour
{

    private string side;
    private float partOfTheSide;
    public int initialDistance;
    private GameObject aliensGroup;


///////////////////////// START FUNCTIONS ///////////////////////////////////

    void Start()
    {
        aliensGroup = AlienManager.current.gameObject;
        NewTrajectory(true);
        AlienManager.current.OnNewTrajectory += NewTrajectory;
    }

    void Update()
    {}


////////////////////////////////////////////////////////////

    private void ChooseTheSide(){

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
            AlienManager.current.ChangeAliensDirection(new Vector3(0,0,0), new Vector3(0,180,0));
        }

        if (side == "East"){
            aliensAngle = new Vector3(0, 90 ,0);
            AlienManager.current.ChangeAliensDirection(new Vector3(0,180,0), new Vector3(0,0,0));
        }

        if (side == "South"){
            aliensAngle = new Vector3(0, 180 ,0);
            AlienManager.current.ChangeAliensDirection(new Vector3(0,90,0), new Vector3(0,-90,0));
        }

        if (side == "North"){
            aliensAngle = new Vector3(0, 0 ,0);
            AlienManager.current.ChangeAliensDirection(new Vector3(0,-90,0), new Vector3(0,90,0));
        }

        aliensGroup.transform.localEulerAngles = aliensAngle;
    }

////////////////////////////////////////////////////////////

    private void UpdatePosition(){

        if (side == "West"){
            aliensGroup.transform.position = new Vector3(50 - initialDistance, 0, partOfTheSide);
        }

        if (side == "North"){
            aliensGroup.transform.position = new Vector3(partOfTheSide,0 , 50 + initialDistance);
        }

        if (side == "East"){
            aliensGroup.transform.position = new Vector3(50 + initialDistance, 0, partOfTheSide);
        }

        if (side == "South"){
            aliensGroup.transform.position = new Vector3(partOfTheSide,0 , 50 - initialDistance);
        }

    }

////////////////////////////////////////////////////////////  

    public void NewTrajectory(bool b){

        if (b){
            AlienManager.current.hasCameInTheGameArea = false;
            ChooseTheSide();
            UpdateDirection();
            UpdatePosition();
            AlienManager.current.IsNewTrajectory = false;
        }
        
        
    }

////////////////////////////////////////////////////////////

}
