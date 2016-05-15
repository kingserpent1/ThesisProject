using UnityEngine;
using System.Collections;

public class Entrance : MonoBehaviour 
{
    public GameObject room = null;
    public bool triggerEntered = false;
    

    void OnTriggerEnter(Collider entrance)
    {
        if((entrance.gameObject.tag == "Player") && (!triggerEntered))
        {
            //gameObject.transform.parent.gameObject.tag = "CurrentRoom";

            triggerEntered = true;
            room = MapGenerator.instance.GenerateNextSection(gameObject);
            
            if (room.GetComponent<Room>().didCollision)
            {
                Destroy(room);
                MapGenerator.instance.DeadEnd(gameObject);
            }

            gameObject.transform.parent.gameObject.tag = "Room";
            
        }
    }

    
}
