using UnityEngine;
using System.Collections;

public class WorldMusic : MonoBehaviour 
{
    public AudioSource worldSound = null;
    public AudioClip worldClip = null;

	// Use this for initialization
	void Awake () 
    {
        AudioManager.instance.PlayWorldMusic(worldSound, worldClip);
	}
	
	// Update is called once per frame
	void Update () 
    {
        //AudioManager.instance.StopWorldMusic();
	}
}
