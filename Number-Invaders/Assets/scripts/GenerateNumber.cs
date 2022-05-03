using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateNumber : MonoBehaviour
{

    public TextMesh alienText;
    public int divider;
    


    // Start is called before the first frame update
    void Start()
    {
        int alienNumber = ((int) (Random.value * 60/divider) + 1 ) * divider;
        alienText.text = alienNumber.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
