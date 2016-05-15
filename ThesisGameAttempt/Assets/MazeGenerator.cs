using UnityEngine;
using System.Collections;

public class MazeGenerator : MonoBehaviour 
{
    //public float delay = 0.1f;
    //public float offset = 0.0f;
    public GameObject floor = null;
    //public GameObject prefab = null;
    

    bool didInstantiate = false;
    //public void MazeGen()
    //{
    //    int i = 0, k = 1, j = 0;

    //    for(i = 0; i < 10; i++ )
    //    {
    //        i += 1;

    //        for (j = 0; j < 10; j++)
    //        {
    //            offset += delay;
    //            StartCoroutine(BuildWithVisualization(new Vector3(i, k, j)));
    //        }
    //    }   
    //}

    void OnTriggerEnter(Collider other)
    {
        GameObject tile = null;
        
        if((other.gameObject.tag == "Player") && (!didInstantiate) && (Manager.instance.tiles.Count > 0))
        {
            tile = Manager.instance.ListOfTiles();
            print(Vector3.left * floor.transform.localScale.x);
            Instantiate(tile, gameObject.transform.position + (Vector3.left * floor.transform.localScale.x/2), gameObject.transform.rotation);
            didInstantiate = true;
        }
    }

    //IEnumerator BuildWithVisualization(Vector3 position)
    //{
    //    yield return new WaitForSeconds(offset);
    //    Instantiate(prefab, position, transform.rotation);
    //}

    
}
