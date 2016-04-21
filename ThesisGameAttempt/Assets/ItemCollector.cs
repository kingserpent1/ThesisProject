using UnityEngine;
using System.Collections;

public class ItemCollector : MonoBehaviour 
{
    public GameObject item = null;
    public string itemName; 
    
	// Use this for initialization
    public void OnTriggerStay(Collider other)
    {
        //print("here");
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Manager.instance.inventory[Manager.instance.invenPlacer] = itemName;
                Manager.instance.invenPlacer++;
                Destroy(item);
                Destroy(gameObject);
            }
        }
    }
}
