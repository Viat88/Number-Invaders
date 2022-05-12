using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{


    public static GameStateManager current;                                         // Unique GameStataManager

    /* 3 players lifes: */
    public GameObject heart1;                                                       
    public GameObject heart2;
    public GameObject heart3;

    private int numberOfLifes = 3;                                                   // Number of lifes that players have
    public GameObject gameOverAlienPrefab;                                           // Prefab of game over alien
    private bool alreadyPlayed;

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
    void Start(){}

    // Update is called once per frame
    void Update(){
        if (AlienManager.current.alienList.Count == 0 && !alreadyPlayed){
            SoundManager.current.PlayWinningSound();
            alreadyPlayed = true;
        }
    }

////////////////////////////////////////////////////////////


    /* Deletes a players' life */
    public void TakeDamage(){

        if (numberOfLifes == 3){                        // We just delete one heart
            heart1.SetActive(false);
        }

        if (numberOfLifes == 2){                        // We just delete one heart
            heart2.SetActive(false);
        }

        if (numberOfLifes == 1){                        // We delete the last heart and we start GameOver
            heart3.SetActive(false);
            GameOver();
        }

        numberOfLifes -=1;                              // They have one life less
    }

////////////////////////////////////////////////////////////

    /* Start game over */
    private void GameOver(){
        AlienManager.current.DestroyAliensGroup();
        SoundManager.current.PlayGameOverSound();                                                                       // Starts Game over sound
        CreateGameOverMenuAlien();
        //gameOverAlien.transform.localEulerAngles = new Vector3 (30,-30,-10);                                           // Turns it
        //Time.timeScale = 0;                                                                                             // Stops the game
        
    }

////////////////////////////////////////////////////////////

    private void CreateGameOverMenuAlien(){
        GameObject gameOverAlien = Instantiate(gameOverAlienPrefab, new Vector3(50, 5, 50), new Quaternion(0,0,0,0));   // Creates Game over alien
    }

}
