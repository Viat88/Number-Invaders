using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombShockWave : MonoBehaviour
{

    /*
        Manage the shock wave produced by the bomb explosion
    */

    public float maxSize;
    private float timeScale = 0;
    public float speed;
    


///////////////////////// START FUNCTIONS ///////////////////////////////////

    // Start is called before the first frame update
    void Start()
    {}

    // Update is called once per frame
    void Update()
    {
        
        timeScale += Time.deltaTime;
        UpdateSize();
        DestroyIfMaxSize();
    }


////////////////////////////////////////////////////////////

    private void DestroyIfMaxSize(){
        if (transform.localScale.x >= maxSize){
            Destroy(gameObject);
        }
    }   
    
////////////////////////////////////////////////////////////

    private void UpdateSize(){
        float newSize = timeScale*speed;
        transform.localScale = new Vector3(newSize, newSize, newSize);
    }


    
}
