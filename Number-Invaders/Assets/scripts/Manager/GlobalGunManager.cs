using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGunManager : MonoBehaviour
{
    /*
        Manage all guns
    */

    public GameObject gunPrefab;                                                // Prefab of guns
    private List<int> availableGunList;                                         // List of gun available

///////////////////////// START FUNCTIONS ///////////////////////////////////

    void Start()
    {
        availableGunList = MainParameters.current.ListGunAvailable;            // We set ListGunAvailable
        CreateGuns();                                                          // We create guns
    }


////////////////////////////////////////////////////////////

    /*
        Creates guns
    */
    private void CreateGuns(){
        for (int i=0; i<availableGunList.Count; i++){
            CreateGun(i, availableGunList[i]);
        }
    }

    /*
        Create a gun with its number and its index (to know position)
    */
    private void CreateGun(int index, int number){

        Vector3 gunPosition = GetGunPositions(index);
        GameObject newGun = Instantiate(gunPrefab, gunPosition, new Quaternion(0,0,0,0));
        newGun.name = number.ToString();
    }

    /*
        Gives the position of the gun according to its index
    */
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
