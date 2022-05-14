using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneTrigger : MonoBehaviour
{

    public string sceneToLoad;
    public float timeToChooseButton;
    private bool onButton = false;
    public GameObject button;
    private MeshRenderer model;
    public Color initialColor;
    public Color hoverColor;
    private float time;


    void Start()
    {
        model = button.GetComponent<MeshRenderer>();
        model.material.color = initialColor;
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
            model.material.color = hoverColor;
            onButton = true;
            time = timeToChooseButton;
            
        }
    }

/////////////////////

    private void OnTriggerExit( Collider other){
        model.material.color = initialColor;
        if (other.CompareTag("Player1") || other.CompareTag("Player2")){
            onButton = false;
        }
    }

////////////////////////////////////////////////////////////


}
