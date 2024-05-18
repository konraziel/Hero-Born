using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // I'm going to need some variables that tell me about position
    public Vector3 myStartPosition = new Vector3(0, 0, 51);
    public Vector3 myEndPosition = new Vector3(0, 0, 21);
    public int speed = 4;
    public bool forward = true;

    // Update is called once per frame
    void Update()
    {

        //If we reach the end then change our direction boolean to go backward
        if (gameObject.transform.position.z <= myEndPosition.z)
        {
            forward = true;
        }
        //If we reach the begining then change our direction boolean to go forward
        if (gameObject.transform.position.z >= myStartPosition.z)
        {
            forward = false;
        }

        //If we are going forward then add the speed
        if (forward == true)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + (Time.deltaTime * speed));
        }
        //If we are going backward then subtract the speed
        if (forward == false)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - (Time.deltaTime * speed));
        }
    }
}
