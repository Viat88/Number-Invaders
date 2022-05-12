using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideLightsManager : MonoBehaviour
{

    public static SideLightsManager current;
    public GameObject westLine;
    public GameObject eastLine;
    public GameObject northLine;
    public GameObject southLine;
    public bool westLineActivated;
    public bool eastLineActivated;
    public bool northLineActivated;
    public bool southLineActivated;
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
        
        
        
        
    }

////////////////////////////////////////////////////////////

    public void LineActivation(string side){
        DesactivateAll();

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

    private void DesactivateAll(){
        westLineActivated = false;
        eastLineActivated = false;
        northLineActivated = false;
        southLineActivated = false;
    }

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
