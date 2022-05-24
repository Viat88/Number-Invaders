using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndsCollider : MonoBehaviour
{

    private int alienNumber = 0;
    
    void Update(){
        if (alienNumber == AlienManager.current.alienList.Count){
            alienNumber = 0;

            if (AlienManager.current.hasCameInTheGameArea){
                AlienManager.current.IsNewTrajectory=true;                       // We whange the trajectory of alien's group
            }
            
            else{
                AlienManager.current.HasCameInTheGameArea = true;
            }
        }
    }


    private void OnTriggerExit(Collider other){
        if (other.CompareTag("Alien")){                                 // When an alien entered in this box
            alienNumber +=1;
        }
    }

}
