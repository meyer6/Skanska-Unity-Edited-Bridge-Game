using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingElementScript : MonoBehaviour
{

    //NGI to be attached to the building element
    public int weight;
    public int cost;
    public int carbonDioxide;
    public float tensileStrength;

    //follow mouse only when first created, then drop.
    public bool stuckInMiddle;
    public bool followMouse;
    public float mouseX;

    public float minSpeed = 0.001f;
    //public bool rotate;
    public float lowerBound = -5.0f;


    // Start is called before the first frame update
    void Start()
    {
        stuckInMiddle = true;
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        followMouse = false;
    }

    // Update is called once per frame
    void Update()
    {
        //once an element created it at first follows mouse, released after left click
        if (Input.GetMouseButtonDown(0)) 
        {
            if (stuckInMiddle)
            {
                followMouse = true;
            }
            else
            {
                followMouse = false;
                gameObject.GetComponent<Rigidbody>().useGravity = true;
            }
            stuckInMiddle = false;

            
        }
        //when element first created follow mouse and rotate 45 degs when space pressed
        if (stuckInMiddle)
        {
            
            mouseX = GameObject.Find("Game Manager").GetComponent<GameManager>().mousePosition.x;

            if (mouseX < 0)
            {
                mouseX *= -1;
            }
            if (mouseX < 0.4f)
            {
                mouseX = 0.4f;
            }else if (mouseX > 2.5f)
            {
                mouseX = 2.5f;
            }
            float y = gameObject.transform.localScale.y;
            float z = gameObject.transform.localScale.z;
            gameObject.transform.localScale = new Vector3(mouseX, y, z);
            gameObject.transform.position = new Vector3(0, 2, -7);

        }
        if (followMouse)
        {
            Debug.Log("Mouse");
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.down * 2 * minSpeed;
            gameObject.transform.position = GameObject.Find("Game Manager").GetComponent<GameManager>().mousePosition;
            if (Input.GetKey("a")) 
            {
                gameObject.transform.Rotate(0, 0, 1, Space.World);
            }
            else if (Input.GetKey("d"))
            {
                gameObject.transform.Rotate(0, 0, 359, Space.World);
            }
        }
        else //when element released move according to physics model, if stationary then freeze in place
        {
            if (gameObject.GetComponent<Rigidbody>().velocity.magnitude < minSpeed)
            {

                //gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            }
        }

        if (transform.position.y < lowerBound)
        {
            Destroy(gameObject);
        }
    }
}
