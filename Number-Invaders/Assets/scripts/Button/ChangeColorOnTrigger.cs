using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorOnTrigger : MonoBehaviour
{
    /*
        Chnage the color of the button when a player touches it
    */

    public GameObject button;
    private MeshRenderer model;
    public Color initialColor;
    public Color hoverColor;

///////////////////////// START FUNCTIONS /////////////////////////////////// 


    void Start()
    {
        model = button.GetComponent<MeshRenderer>();
        model.material.color = initialColor;
    }


///////////////////////// TRIGGER FUNCTIONS /////////////////////////////////

    private void OnTriggerEnter( Collider other){

        if (other.CompareTag("Player1") || other.CompareTag("Player2")){
            model.material.color = hoverColor;            
        }
    }

/////////////////////

    private void OnTriggerExit( Collider other){
        
        if (other.CompareTag("Player1") || other.CompareTag("Player2")){
            model.material.color = initialColor;
        }
    }

}
