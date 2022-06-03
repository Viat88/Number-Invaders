using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneTrigger : MonoBehaviour
{

    public string sceneToLoad;
    private float timeToChooseButton;
    private bool onButton = false;
    private float time;

///////////////////////// START FUNCTIONS /////////////////////////////////// 

    void Start()
    {
        timeToChooseButton = MainParameters.current.timeToChooseButton;
        time = timeToChooseButton;
    }

    void Update()
    {
        time -= Time.deltaTime;
        if (time <=0 && onButton) {
            SceneManager.LoadScene(sceneToLoad);
        }
    }

///////////////////////// TRIGGER FUNCTIONS /////////////////////////////////

    private void OnTriggerEnter( Collider other){

        if (other.CompareTag("Player1") || other.CompareTag("Player2")){
            onButton = true;
            time = timeToChooseButton;
            
        }
    }

/////////////////////

    private void OnTriggerExit( Collider other){
        if (other.CompareTag("Player1") || other.CompareTag("Player2")){
            onButton = false;
        }
    }

////////////////////////////////////////////////////////////


}
