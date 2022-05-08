using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager current;
    private Vector3 cameraPosition;

    public AudioClip alienTouchedSound;
    public AudioClip gunTouchedSound;
    public AudioClip gunHandlingSound;
    public AudioClip reloadingSound;
    public AudioClip gunShootSound;

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

        cameraPosition = Camera.main.transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



////////////////////////////////////////////////////////////

    private void PlaySound(AudioClip clip) // 1
    {
        AudioSource.PlayClipAtPoint(clip, cameraPosition); // 2
    }

////////////////////////////////////////////////////////////

    public void PlayAlienTouchedSound(){
        PlaySound(alienTouchedSound);
    }

    public void PlayGunTouchedSound(){
        PlaySound(gunTouchedSound);
    }

    public void PlayGunHandlingSound(){
        PlaySound(gunHandlingSound);
    }

    public void PlayReloadingSound(){
        PlaySound(reloadingSound);
    }

    public void PlayGunShootSound(){
        PlaySound(gunShootSound);
    }
}
