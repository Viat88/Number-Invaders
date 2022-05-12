using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {}

    // Update is called once per frame
    void Update()
    {}

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Laser2") || other.CompareTag("Laser3") || other.CompareTag("Laser5")){
            SceneManager.LoadScene("Main Game");
        }
    }
}
