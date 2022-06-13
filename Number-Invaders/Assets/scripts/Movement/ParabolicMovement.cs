using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicMovement : MonoBehaviour
{
    /*
        Makes the object do a parabolic movement
    */

    private Vector3 initialPoint;
    private Vector3 targetPoint;
    public float parabolHigh;
    public float shootDelay;
    private Vector3 direction;
    private float time = 0;
    public GameObject redTargetPrefab;
    

    /* The y position is in the form: A* d*(d - x2) with d the distance from initialPoint
    */
    private float coefA;
    private float x2;
    private float d;

///////////////////////// START FUNCTIONS ///////////////////////////////////

    // Start is called before the first frame update
    void Start()
    {
        initialPoint = transform.position;
        ChooseAPoint();
        GameObject newRedTarget = Instantiate(redTargetPrefab, targetPoint, new Quaternion(0,0,0,0));
        newRedTarget.name = gameObject.name;
        PreviousCalcul();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        Vector3 pos = Vector3.Lerp(initialPoint, targetPoint, time/shootDelay);
        pos.y = yCalcul();
        transform.Translate(pos - transform.position);
    }

////////////////////////////////////////////////////////////

    private void ChooseAPoint(){
        float x = Random.value*80 + 10;                                                          // Between 20 and 80
        float z = Random.value*80 + 10;                                                          // Between 20 and 80

        targetPoint = new Vector3(x,0,z);
    }

////////////////////////////////////////////////////////////

    private void DirectionCalcul(){
        direction = targetPoint - initialPoint;
    }

    private void x2Calcul(){
        x2 = direction.magnitude;
    }

    private void ACalcul(){
        coefA = - (4 * parabolHigh)/(x2*x2);  
    }

    private void PreviousCalcul(){
        DirectionCalcul();
        x2Calcul();
        ACalcul();
    }

////////////////////////////////////////////////////////////

    private float yCalcul(){
        dCalcul();
        return coefA * d * (d - x2);
    }

////////////////////////////////////////////////////////////

    private void dCalcul(){
        Vector3 currentPointOnPlan = new Vector3(transform.position.x,0,transform.position.z);
        Vector3 initialPointOnPlan = new Vector3(initialPoint.x,0,initialPoint.z);
        d = (currentPointOnPlan - initialPointOnPlan).magnitude;
    }
}
