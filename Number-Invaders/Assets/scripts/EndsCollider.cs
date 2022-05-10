using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndsCollider : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Alien")){                                 // When an alien entered in this box
            AlienManager.current.NewTrajectory();                       // We whange the trajectory of alien's group
        }
    }

}
