using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public GameObject target = null;
    public float speed = 30.0f;

    public Transform targetOrig;
    //keep track of time
    public float delayTime = 2.0f;
    public float time = 0.0f;

    //	private Vector3 position;
    //If it hits wall then False
    private bool isRotating = true;
    //direction rotating TRUE/RIGHT, FALSE/LEFT
    private bool direction = true;
    //0 = any direction, NoRightRotation = 2, NoLeftRotation = 1
    private int stop = 0;
    // Use this for initialization
    private float offset = 0.0f;
    //	private int  i = 0;
    void Start()
    {
        targetOrig = target.transform;
        transform.LookAt(target.transform);
        offset = Vector3.Distance(transform.position, transform.parent.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //position = transform.position;
        //time += Time.deltaTime;
        //		if ((time > delayTime) || (transform.position != position)) 
        //		{
        //			time = 0.0f;
        //			stop = 0;
        //		}
        //Movement leads to s
        if (isRotating)
        {
            //LEFT 
            if (Input.mousePosition.x < Screen.width - Screen.width * 0.92f)
            {
                transform.RotateAround(target.transform.position, Vector3.up, speed * Time.deltaTime);
                direction = true;
                stop = 0;
            }
            //			else if(stop == 1)
            //			{
            //				transform.position = Vector3.Lerp(transform.position, transform.position + transform.forward, 2.0f * Time.deltaTime);
            //				print("camera forward");
            //			}
            //RIGHT
            if (Input.mousePosition.x > Screen.width - Screen.width * 0.08f)
            {
                transform.RotateAround(target.transform.position, -Vector3.up, speed * Time.deltaTime);
                direction = false;
                stop = 0;
            }
            //			else if (stop == 2)
            //			{
            //				transform.position = Vector3.Lerp(transform.position, transform.position - transform.forward, 2.0f * Time.deltaTime);
            //				print("camera forward");
            //			}
            //DOWN
            if ((Input.mousePosition.y < Screen.height - Screen.height * 0.92f) && (transform.position.y > 0.5f) && (Vector3.Distance(transform.position, target.transform.position) > 2f))
            {
                transform.position = Vector3.Lerp(transform.position, transform.position - transform.up, 1.0f * Time.deltaTime);
                transform.position = Vector3.Lerp(transform.position, transform.position + transform.forward, 1.0f * Time.deltaTime);
                transform.LookAt(target.transform);
            }
            //UP
            if ((Input.mousePosition.y > Screen.height - Screen.height * 0.08f) && (transform.position.y < 3))
            {
                transform.position = Vector3.Lerp(transform.position, transform.position + transform.up, 1.0f * Time.deltaTime);
                transform.position = Vector3.Lerp(transform.position, transform.position - transform.forward, 1.0f * Time.deltaTime);
                //target.transform.position = Vector3.Lerp (target.transform.position, targetOrig.position, 0.5f * Time.deltaTime);
                transform.LookAt(target.transform);
            }
            if ((offset > Vector3.Distance(transform.position, transform.parent.position) && (stop == 0)))
            {
                transform.position = Vector3.Lerp(transform.position, transform.position - transform.forward, 1.0f * Time.deltaTime);
            }
        }
        else
        {
            if (direction)
            {
                transform.position = Vector3.Lerp(transform.position, transform.position + transform.forward, 2.0f * Time.deltaTime);

                //transform.RotateAround (target.transform.position, -Vector3.up, speed * Time.deltaTime);
                stop = 1;
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, transform.position + transform.forward, 2.0f * Time.deltaTime);

                //transform.RotateAround (target.transform.position, Vector3.up, speed * Time.deltaTime);
                stop = 2;
            }
        }
    }



    void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag != "Player") && (other.gameObject.name != "Collapse") && (other.gameObject.tag != "Door"))
        {
            isRotating = false;
        }

    }
    void OnTriggerExit(Collider other)
    {
        isRotating = true;
    }
}
