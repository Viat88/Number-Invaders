using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInvincibility : MonoBehaviour
{
    /*
        Only set the invincibility when MainParameters asks
    */

    public GameObject invincibilitySphere;

    void Update()
    {
        invincibilitySphere.SetActive(AlienManager.current.isInvincible);
    }
}
