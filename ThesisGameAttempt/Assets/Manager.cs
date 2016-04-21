using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class Manager : MonoBehaviour
{
    public AudioSource dialogue = null;
    public bool isOpen = false;
    public string[] inventory;
    public int invenPlacer = 0;
    public string[] items;
    


    public static Manager _instance = null;

    public static Manager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(Manager)) as Manager;

                if (_instance == null)
                {
                    GameObject obj = new GameObject("Manager");
                    _instance = obj.AddComponent(typeof(Manager)) as Manager;
                }

                _instance.Init();
            }

            return _instance;
        }
    }
    
    public void Create() { }
    
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    
    public void Init()
    {
        invenPlacer = 0;

        for (int i = 0; i < items.Length; ++i)
        {
            items[i] = "key " + i.ToString();
        }




    }

    public void PlayDialogue(GameObject name)
    {
        dialogue = name.GetComponent<AudioSource>();
        if (!dialogue.isPlaying)
        {
            dialogue.Play();
        }
    }


    public void CollectionSystem(string name)
    {
        if (inventory.Length > invenPlacer)
        {
            inventory[invenPlacer] = name;
            invenPlacer++;
        }
    }

    public bool DoorOpen(GameObject door, string key, bool isOpen)
        {
            bool isMove = false;
            //door.transform.position = vector3.lerp(door.transform.position, door.transform.position + new vector3(0, 1, 0), 1.0f * time.deltatime);
            //if (door.transform.position.y > 5.5f)
            //{
            //    return false;
            //}
            for (int i = 0; inventory.Length > i; i++)
            {
                if (inventory[i] == key)
                {
                    isMove = true;
                }

            }

            if(isMove)
            { 
                door.transform.position = Vector3.Lerp(door.transform.position, door.transform.position + new Vector3(0, 1, 0), 1.0f * Time.deltaTime); 
            }
           
            
            if (door.transform.position.y > 5.5f)
            {
                return false;
            }
            return true;
        }



}
