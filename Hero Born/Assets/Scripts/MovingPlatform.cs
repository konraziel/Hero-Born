using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    /* Variables to hold the minimum and maximum x, y, z values to reference for movement
     * Note that the min and max variables should correspond to the smaller and larger value on the axis you are moving on
     * So, for instance, if you want to move on the Z axis from 20 to -12: MinPosition = (0,0,-12) and MaxPosition = (0,0,20)
     */
    public Vector3 MinPosition = new Vector3(0, 0, 0);
    public Vector3 MaxPosition = new Vector3(0, 0, 0);
    public int speed = 4; // Denotes how fast the platform will be moving

    /* Enum to dictate which axis the platform should be moving on
     * Allows for more dynamic control from the inspector tab, but limits the platform to move only along one axis
     * Intended to be used from the inspector tab
     */
    public enum Direction
    {
        Z_TRAVEL, // Denotes moving along z axis
        X_TRAVEL, // Denotes moving along x axis
        Y_TRAVEL  // Denotes moving along y axis
    }
    public Direction dir = Direction.Z_TRAVEL;

    public bool positive_mov = true; // Checks if the platform should move in the positive coordinate direction

    // Update is called once per frame
    void Update()
    {

        switch(dir) // switch statement to determine which case is being used
        {
            case Direction.Z_TRAVEL:
                // If we reach the lowest allowed value on the z axis, then change our direction boolean to go to the positive direction
                if (gameObject.transform.position.z <= MinPosition.z)
                {
                    positive_mov = true;
                }
                // If we reach the highest allowed value on the z axis, then go in the negative direction
                if (gameObject.transform.position.z >= MaxPosition.z)
                {
                    positive_mov = false;
                }

                // If we are going positive then add the speed
                if (positive_mov == true)
                {
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + (Time.deltaTime * speed));
                }
                //If we are going negative then subtract the speed
                if (positive_mov == false)
                {
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - (Time.deltaTime * speed));
                }
                break;
            case Direction.X_TRAVEL:
                // If we reach the lowest allowed value on the x axis, then change our direction boolean to go to the positive direction
                if (gameObject.transform.position.x <= MinPosition.x)
                {
                    positive_mov = true;
                }
                // If we reach the highest allowed value on the x axis, then go in the negative direction
                if (gameObject.transform.position.x >= MaxPosition.x)
                {
                    positive_mov = false;
                }

                // If we are going positive then add the speed
                if (positive_mov == true)
                {
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x + (Time.deltaTime * speed), gameObject.transform.position.y, gameObject.transform.position.z);
                }
                //If we are going negative then subtract the speed
                if (positive_mov == false)
                {
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x - (Time.deltaTime * speed), gameObject.transform.position.y, gameObject.transform.position.z);
                }
                break;
            case Direction.Y_TRAVEL:
                // If we reach the lowest allowed value on the y axis, then change our direction boolean to go to the positive direction
                if (gameObject.transform.position.y <= MinPosition.y)
                {
                    positive_mov = true;
                }
                // If we reach the highest allowed value on the y axis, then go in the negative direction
                if (gameObject.transform.position.y >= MaxPosition.y)
                {
                    positive_mov = false;
                }

                // If we are going positive then add the speed
                if (positive_mov == true)
                {
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x + (Time.deltaTime * speed), gameObject.transform.position.y, gameObject.transform.position.z);
                }
                //If we are going negative then subtract the speed
                if (positive_mov == false)
                {
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x - (Time.deltaTime * speed), gameObject.transform.position.y, gameObject.transform.position.z);
                }
                break;
        }
    }
}
