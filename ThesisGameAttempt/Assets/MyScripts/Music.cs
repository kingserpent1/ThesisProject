using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class Music : MonoBehaviour
{
    public AudioMixerSnapshot primary;
    public AudioMixerSnapshot mid;
    public AudioMixerSnapshot epic;

    public int playerScore = 0;

    public float fadeTime = 1.0f;
    // Use this for initialization


    // Update is called once per frame
    void Update()
    {

        if (playerScore > 10)
        {
            mid.TransitionTo(fadeTime);
        }
        if (playerScore > 20)
        {
            epic.TransitionTo(fadeTime);
        }
        if (playerScore > 30)
        {
            primary.TransitionTo(fadeTime);
        }

        //if( Input.GetKeyDown("1"))
        //{
        //    primary.TransitionTo(fadeTime);

        //}
        //else if(Input.GetKeyDown("2"))
        //{
        //    mid.TransitionTo(fadeTime);
        //}
        //else if(Input.GetKeyDown("3"))
        //{
        //    epic.TransitionTo(fadeTime);
        //}
    }
}