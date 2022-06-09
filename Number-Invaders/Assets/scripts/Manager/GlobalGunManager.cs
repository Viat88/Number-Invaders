using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGunManager : MonoBehaviour
{

    public GameObject gunPrefab;
    private List<int> availableGunList;

    void Awake(){
        
    }
    void Start()
    {
        availableGunList = MainParameters.current.ListGunAvailable;
        CreateGuns();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


////////////////////////////////////////////////////////////

    private void CreateGuns(){
        for (int i=0; i<availableGunList.Count; i++){
            CreateGun(i, availableGunList[i]);
        }
    }


    private void CreateGun(int index, int number){

        Vector3 gunPosition = GetGunPositions(index);
        GameObject newGun = Instantiate(gunPrefab, gunPosition, new Quaternion(0,0,0,0));
        newGun.name = number.ToString();
    }

    private Vector3 GetGunPositions(int index){
        if(index == 0){
            return new Vector3 (30,0,50);
        }
        if(index == 1){
            return new Vector3 (55,0,65);
        }
        if(index == 2){
            return new Vector3 (80,0,50);
        }
        return new Vector3(0,0,0);
    }
}
