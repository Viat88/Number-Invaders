using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchedByLaser : MonoBehaviour
{

    public TextMesh alienText;                                                              // Alien's text containing its number
    private int number;                                                                     // Number of the alien
    public float destroyDelay;                                                              // The time destroying alien takes

///////////////////////// START FUNCTIONS ///////////////////////////////////  
    
    void Start(){
        number = int.Parse(alienText.text);
    }

    // Update is called once per frame
    void Update(){

        if (number == 1){
            DestroyAlien();
        }
    }


////////////////////////////////////////////////////////////

    private void OnTriggerEnter(Collider other){


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

        if (other.CompareTag("Laser2") || other.CompareTag("Laser3") || other.CompareTag("Laser5")){
            SoundManager.current.PlayAlienTouchedSound();
        }
        
    }

////////////////////////////////////////////////////////////

    private void DestroyAlien(){

        AlienManager.current.RemoveAlienFromList(gameObject);
        Destroy(gameObject, destroyDelay);
        TweenScale tweenScale = gameObject.AddComponent<TweenScale>();; // 1
        tweenScale.targetScale = 0; // 2
        tweenScale.timeToReachTarget = destroyDelay; // 3

    }
}
