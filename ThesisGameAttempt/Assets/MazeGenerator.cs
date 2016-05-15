using UnityEngine;
using System.Collections;

public class MazeGenerator : MonoBehaviour 
{
<<<<<<< HEAD
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

    
=======
    public float delay = 0.1f;
    public float offset = 0.0f;

    public GameObject prefab = null;
    public int length = 10;
    public int height = 10;
    public int width = 10;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}

    public void MazeGen()
    {
        int i = 0, k = 1, j = 0;

        for(i = 0; i < 10; i++ )
        {
            i += 1;

            for (j = 0; j < 10; j++)
            {
                offset += delay;
                StartCoroutine(BuildWithVisualization(new Vector3(i, k, j)));
            }
        }

        
    }

    IEnumerator BuildWithVisualization(Vector3 position)
    {
        yield return new WaitForSeconds(offset);
        Instantiate(prefab, position, transform.rotation);
    }
>>>>>>> master
}
