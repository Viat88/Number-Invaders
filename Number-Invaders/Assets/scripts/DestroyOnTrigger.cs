using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    public string tagFilter;                                // The tag filter that implies to destroy this object
    
    private void OnTriggerEnter(Collider other) 
    {
        if (gameObject.CompareTag("BombTarget")){
            if(other.CompareTag(tagFilter) && other.name == gameObject.name){
                Destroy(gameObject);                            // We destroy the object
            }
        }

        else{
            if (other.CompareTag(tagFilter))                    // If it's the good tagFilter
            {
                Destroy(gameObject);                            // We destroy the object
            }
        }
    }
}
