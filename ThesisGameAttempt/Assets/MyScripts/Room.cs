using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Room : MonoBehaviour 
{
    public List<GameObject> entrances = new List<GameObject>();
    public bool didCollision = false;
    

    void OnCollisionStay(Collision otherRoom)
    {
        print(otherRoom);

        if (otherRoom.gameObject.tag == "Room")
        {
            print("hit");
            didCollision = true; 
        }
    }

}
