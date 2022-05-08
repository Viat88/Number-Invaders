using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{


    public static GameStateManager current;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    private int numberOfLifes = 3;
    public GameObject gameOverAlienPrefab;

///////////////////////// START FUNCTIONS ///////////////////////////////////

    void Awake() 
    {
        if (current == null)
        {
            current = this;
        }
        else
        {
            Destroy(obj: this);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

////////////////////////////////////////////////////////////

    public void TakeDamage(){

        if (numberOfLifes == 3){
            heart1.SetActive(false);
        }

        if (numberOfLifes == 2){
            heart2.SetActive(false);
        }

        if (numberOfLifes == 1){
            heart3.SetActive(false);
            GameOver();
        }

        numberOfLifes -=1; 
    }

////////////////////////////////////////////////////////////

    private void GameOver(){
        SoundManager.current.PlayGameOverSound();
        GameObject gameOverAlien = Instantiate(gameOverAlienPrefab, new Vector3(35, 5, 19), new Quaternion(0,0,0,0));
        gameOverAlien.transform.localEulerAngles = new Vector3 (30,-30,-10);
        Time.timeScale = 0;
        
    }

}
