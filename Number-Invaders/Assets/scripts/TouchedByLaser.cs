using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchedByLaser : MonoBehaviour
{

    public TextMesh alienText;
    private int number;

///////////////////////// START FUNCTIONS ///////////////////////////////////  
    
    void Start(){
        number = int.Parse(alienText.text);
    }

    // Update is called once per frame
    void Update(){}


////////////////////////////////////////////////////////////

    private void OnTriggerEnter(Collider other){

        Debug.Log("ok");


        if (other.CompareTag("Laser2") && number%2 == 0){
            number = number/2;
            alienText.text = number.ToString();
        }

        if (other.CompareTag("Laser3") && number%3 == 0){
            number = number/3;
            alienText.text = number.ToString();
        }


        if (other.CompareTag("Laser5") && number%5 == 0){
            number = number/5;
            alienText.text = number.ToString();
        }


        Destroy(other.GetComponent<GameObject>());
    }
}
