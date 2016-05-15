using UnityEngine;
using System.Collections;

public class FootSteps : MonoBehaviour 
{
    public AudioSource src;
    public AudioClip[] clips;

    public void Walk()
    {
        AudioManager.instance.PlayFootSteps(src, clips);
    }

}
