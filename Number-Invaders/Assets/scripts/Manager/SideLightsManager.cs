using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideLightsManager : MonoBehaviour
{
    /*
        Manager of sight lights
    */

    public static SideLightsManager current;                // Unique SideLightsManager

    // Gameobject of lines
    public GameObject westLine;                             
    public GameObject eastLine;
    public GameObject northLine;
    public GameObject southLine;

    // Is each line activated
    public bool westLineActivated;
    public bool eastLineActivated;
    public bool northLineActivated;
    public bool southLineActivated;

    // Delay of the flash
    public float FlashDelay;


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

    void Start(){
        AlienManager.current.OnHasCameInGameArea += DesactivateAll;             // We set the listener
    }


////////////////////////////////////////////////////////////

    /* Activate the adequate light depending on the string given */
    public void LineActivation(string side){
        DesactivateAll(true);

        if (side == "West"){
            westLineActivated = true;
            StartCoroutine( WestFlashCoroutine() );
        }
        
        if (side == "East"){
            eastLineActivated = true;
            StartCoroutine( EastFlashCoroutine() );
        }

        if (side == "North"){
            northLineActivated = true;
            StartCoroutine( NorthFlashCoroutine() );
        }

        if (side == "South"){
            southLineActivated = true;
            StartCoroutine( SouthFlashCoroutine() );
        } 
    }

////////////////////////////////////////////////////////////

    /* Desactivate all lights */
    private void DesactivateAll(bool b){

        if(b){
            westLineActivated = false;
            eastLineActivated = false;
            northLineActivated = false;
            southLineActivated = false;
        }
    }

////////////////////////////////////////////////////////////

    /* All Coroutine to make light flash */

    public IEnumerator WestFlashCoroutine(){

        while (westLineActivated){
            westLine.GetComponent<MeshRenderer>().enabled = true;
            yield return new WaitForSeconds(FlashDelay);
            westLine.GetComponent<MeshRenderer>().enabled = false;
            yield return new WaitForSeconds(FlashDelay);
        }
    }

    public IEnumerator SouthFlashCoroutine(){

        while (southLineActivated){
            southLine.GetComponent<MeshRenderer>().enabled = true;
            yield return new WaitForSeconds(FlashDelay);
            southLine.GetComponent<MeshRenderer>().enabled = false;
            yield return new WaitForSeconds(FlashDelay);
        }
    }

    public IEnumerator EastFlashCoroutine(){
        while (eastLineActivated){
            eastLine.GetComponent<MeshRenderer>().enabled = true;
            yield return new WaitForSeconds(FlashDelay);
            eastLine.GetComponent<MeshRenderer>().enabled = false;
            yield return new WaitForSeconds(FlashDelay);
        }
    }

    public IEnumerator NorthFlashCoroutine(){

        while (northLineActivated){
            northLine.GetComponent<MeshRenderer>().enabled = true;
            yield return new WaitForSeconds(FlashDelay);
            northLine.GetComponent<MeshRenderer>().enabled = false;
            yield return new WaitForSeconds(FlashDelay);
        }
        
    }
    
}
