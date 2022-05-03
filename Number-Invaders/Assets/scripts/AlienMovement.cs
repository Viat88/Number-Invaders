using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMovement : MonoBehaviour
{

    public static AlienMovement current;
    public float movementSpeed;
    private Vector3 aliensDirection; 


////////////////////////////////////////////////////////////

    // Call before the start
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
        aliensDirection = new Vector3 (0,0,-1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(aliensDirection * movementSpeed*Time.deltaTime);
    }


////////////////////////////////////////////////////////////



}
