using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager current;                 // Unique SoundManager
    private Vector3 cameraPosition;                     // camera's position to play the sound at this points

    public AudioClip alienTouchedSound;                 // Sound when an alien is touched by a gun's laser
    public AudioClip gunTouchedSound;                   // Sound when a gun is touched by an alien's missile
    public AudioClip gunHandlingSound;                  // Sound to tell player that he has taken the gun he's on
    public AudioClip reloadingSound;                    // Sound to tell player that he can shoot
    public AudioClip gunShootSound;                     // Sound when a player shoot
    public AudioClip alienDestructionSound;             // Sound when an alien is destructe (= when its number is equal to 1)
    public AudioClip gameOverSound;                     // Sound when the game is lost
    public AudioClip alienShootSound;                   // Sound when an alien shoots a missile

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
    void Start(){}

    // Update is called once per frame
    void Update(){}


////////////////////////////////////////////////////////////


    /* Play the sound entered */
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

    public void PlayAlienDestructionSound(){
        PlaySound(alienDestructionSound);
    }

    public void PlayGameOverSound(){
        PlaySound(gameOverSound);
    }

    public void PlayAlienShootSound(){
        PlaySound(alienShootSound);
    }
}
