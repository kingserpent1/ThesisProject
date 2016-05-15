using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapGenerator : MonoBehaviour
{
    public List<GameObject> rooms;
    public int numberOfRoomsToGenerate = 2;


    public GameObject currentRoom = null;
    public GameObject newRoom;
    public GameObject randomEntrance;
    public GameObject randomEntranceCurrent;

    //DeadEnd
    public GameObject deadEnd = null;
    public GameObject deadEndEntrance = null;

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public static MapGenerator _instance = null;

    public static MapGenerator instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(MapGenerator)) as MapGenerator;

                if (_instance == null)
                {
                    GameObject obj = new GameObject("AudioManager");
                    _instance = obj.AddComponent(typeof(MapGenerator)) as MapGenerator;
                }

                _instance.Init();
            }

            return _instance;
        }
    }

    public void Create() { }

    private void Init() { }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 










    // Use this for initialization
    void Start()
    {
        currentRoom = GameObject.Instantiate(rooms[Random.Range(0, rooms.Count)]);
        //currentRoom = rooms[Random.Range(0, rooms.Count - 1)];
        
    }

    // Update is called once per frame
    public GameObject GenerateNextSection(GameObject entrance)
    {

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
             
            newRoom = GameObject.Instantiate(rooms[Random.Range(0, rooms.Count)]);
            //newRoom = rooms[Random.Range(0, rooms.Count - 1)];
            Room room = newRoom.GetComponent<Room>();

            randomEntrance = room.entrances[Random.Range(0, room.entrances.Count)];
            randomEntrance.GetComponent<Entrance>().triggerEntered = true;
           
            currentRoom = entrance.transform.parent.gameObject;
           
            //Set the entrance as parent
            randomEntrance.transform.parent = null;
            newRoom.transform.parent = randomEntrance.transform;
            //Camera.main.transform.parent = randomEntrance.transform;

            //randomEntranceCurrent = currentRoom.GetComponent<Room>().entrances[Random.Range(0, currentRoom.GetComponent<Room>().entrances.Count)];
            randomEntranceCurrent = entrance;
            //set the entrance 180 degrees opposite so that they face eachother. 
            //then set the position of the entrance to the random  entrance current = the existing room
            randomEntrance.transform.rotation = randomEntranceCurrent.transform.rotation * Quaternion.Euler(0, 180, 0);
            randomEntrance.transform.position = randomEntranceCurrent.transform.position;

            newRoom.transform.parent = null;
            randomEntrance.transform.parent = newRoom.transform;

            //Remove entrances
            room.entrances.Remove(randomEntrance);
            currentRoom.GetComponent<Room>().entrances.Remove(randomEntranceCurrent);
            //currentRoom = newRoom;
        //}
            return newRoom;
    }

    public void DeadEnd(GameObject entrance)
    {
        deadEnd = deadEndEntrance.transform.parent.gameObject;
        
        //Change entrance to parent
        deadEndEntrance.transform.parent = null;
        deadEnd.transform.parent = deadEndEntrance.transform;

        deadEndEntrance.transform.rotation = entrance.transform.rotation * Quaternion.Euler(0, 180, 0);
        deadEndEntrance.transform.position = entrance.transform.position;

        //change room to parent
        deadEnd.transform.parent = null;
        deadEndEntrance.transform.parent = deadEnd.transform.parent;

    }
}
