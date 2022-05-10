using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenScale : MonoBehaviour
{
    public float targetScale;                                                       // Scale to reach
    public float timeToReachTarget;                                                 // The time it has to take to reach the target
    private float startScale;                                                       // From which value it has to start
    private float percentScaled;                                                    // useful for Lerp function

    

    void Start()
    {
       startScale = transform.localScale.x; 
    }

    void Update()
    {
        if (percentScaled < 1f)                                                     // While it hasn't reach the target scale
        {
            percentScaled += Time.deltaTime / timeToReachTarget;                    
            float scale = Mathf.Lerp(startScale, targetScale, percentScaled); 
            transform.localScale = new Vector3(scale, scale, scale); 
        }
    }
}
