using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{


    public static GameStateManager current;                                         // Unique GameStataManager

    /* 3 players lifes: */
    public GameObject heart1;                                                       
    public GameObject heart2;
    public GameObject heart3;

    private int numberOfLifes = 3;                                                   // Number of lifes that players have



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
    }

////////////////////////////////////////////////////////////


    /* Deletes a players' life */
    public void TakeDamage(){

        SoundManager.current.PlayGunTouchedSound();                                 // We play the sound

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
        SceneManager.LoadScene("Game Over");
    }

////////////////////////////////////////////////////////////

    public void Victory(){
        SceneManager.LoadScene("Victory");
    }

}
