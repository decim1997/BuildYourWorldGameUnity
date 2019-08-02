using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{

    public KeyCode moveForward;
    public KeyCode moveBackward;
    public KeyCode rotateRight;
    public KeyCode rotateLeft;
    public FixedJoystick leftjoystick;
    public FixedJoystick righjoystick;
    public float vitessedeplacement = 15;
    public float vitesserotation = 10;
    Vector3 correctposition;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(transform.position.x <= -2.513355f)
        {
            correctposition = new Vector3(transform.position.x + 5, transform.position.y, transform.position.z);

            transform.position = correctposition;
            Debug.Log("border1");
        }

        if(transform.position.x >= 46.64753f)
        {
            correctposition = new Vector3(transform.position.x - 5, transform.position.y, transform.position.z);
            transform.position = correctposition;
            Debug.Log("border2");
        }

        if(transform.position.z < -11.5f)
        {
            correctposition = new Vector3(transform.position.x, transform.position.y, transform.position.z+3);
            transform.position = correctposition;
            Debug.Log("border3");
        }
        /*if(Input.GetAxis("Mouse Y")>0)
        {
            Debug.Log("Mouse is up");
        }
        if(Input.GetAxis("Mouse Y")<0)
        {
            Debug.Log("Mouse is down");
        }
        if (Input.GetAxis("Mouse X")<0)
        {
           // GetComponent<Rigidbody>().angularVelocity = new Vector3(0, -0.5f, 0);
        }
        if (Input.GetAxis("Mouse X") > 0)
        {
            //GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0.5f, 0);
        }

        if (Input.GetAxis("Mouse X") == 0)
        {
           // GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        }

        if (Input.GetKeyDown(moveForward))
        {
            GetComponent<Rigidbody>().AddRelativeForce(0, 0, 100);
        }

        if(Input.GetKeyUp(moveForward))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }


        if (Input.GetKeyDown(moveBackward))
        {
            GetComponent<Rigidbody>().AddRelativeForce(0, 0, -100);
        }

        if(Input.GetKeyUp(moveBackward))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }*/


        // GetComponent<Rigidbody>().angularVelocity = new Vector3(leftjoystick.Horizontal,leftjoystick.Vertical, 0);
        // GetComponent<Rigidbody>().angularVelocity = new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
        // GetComponent<Rigidbody>().angularVelocity = new Vector3(Input.GetAxis("Mouse Y"),0, 0);
        /*if(Input.GetKeyDown(rotateLeft))
        {
            GetComponent<Rigidbody>().angularVelocity = new Vector3(0, -0.5f, 0);
        }
        if (Input.GetKeyUp(rotateLeft))
        {
            GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        }

        if (Input.GetKeyDown(rotateRight))
        {
            GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0.5f, 0);
        }
        if (Input.GetKeyUp(rotateRight))
        {
            GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        }*/



        //GetComponent<Rigidbody>().AddRelativeForce(0, 0, -100);
        //  GetComponent<Rigidbody>().angularVelocity = new Vector3(leftjoystick.Direction.x, leftjoystick.Direction.y, 0);

        if (leftjoystick.Direction.x >0 || leftjoystick.Direction.x <0)
        {
            GetComponent<Rigidbody>().AddRelativeForce(0, 0, vitessedeplacement*leftjoystick.Direction.x);
        }
       else
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }



        GetComponent<Rigidbody>().angularVelocity = new Vector3(vitesserotation*righjoystick.Vertical,vitesserotation*righjoystick.Horizontal, 0);
    }



}
