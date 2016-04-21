using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour 
{
    public bool isOpen = false;
    public string key = null;
    public GameObject door = null; 

    void Update()
    {
        if(isOpen)
        {
            isOpen = Manager.instance.DoorOpen(door, key, isOpen);
        }
        
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                isOpen = true;
            }
        }
    }
}
