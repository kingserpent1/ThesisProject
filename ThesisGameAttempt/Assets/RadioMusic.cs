﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RadioMusic : MonoBehaviour 
{
<<<<<<< HEAD
    
    public GameObject textObject;
    public Text text;

    public AudioSource radioSource;
    public AudioClip radioClip;

=======
    public Manager manager;
    public GameObject textObject;
    public Text text;

>>>>>>> master
    public string[] dialogueList;
    int i = 0;

    // Use this for initialization
    void Start()
    {
        text = textObject.GetComponent<Text>();

    }

    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
<<<<<<< HEAD
            
=======
>>>>>>> master
            text.enabled = true;

            if (Input.GetKeyDown(KeyCode.E))
            {
                text.text = dialogueList[i];

                if (i < dialogueList.Length - 1)
                {
                    i++;
                }
                else if (i == dialogueList.Length - 1)
                {
                    i = 0;
                }
                
<<<<<<< HEAD
                AudioManager.instance.PlayRadio(radioSource, radioClip);
=======
                AudioManager.instance.PlayRadio(gameObject);
>>>>>>> master
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        text.enabled = false;
<<<<<<< HEAD
        text.text = "Press 'E' to Activate";
=======
>>>>>>> master
    }
}
	

