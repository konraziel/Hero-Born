using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // I'm going to need some variables that tell me about position
    public Vector3 MinPosition = new Vector3(0, 0, 0);
    public Vector3 MaxPosition = new Vector3(0, 0, 0);
    public int speed = 4;

    public enum Direction
    {
        Z_TRAVEL,
        X_TRAVEL,
        Y_TRAVEL
    }
    public Direction dir = Direction.Z_TRAVEL;

    public bool positive_mov = true;

    // Update is called once per frame
    void Update()
    {

        switch(dir)
        {
            case Direction.Z_TRAVEL:
                //If we reach the end then change our direction boolean to go forwards
                if (gameObject.transform.position.z <= MinPosition.z)
                {
                    positive_mov = true;
                }
                //If we reach the begining then change our direction boolean to go backwards
                if (gameObject.transform.position.z >= MaxPosition.z)
                {
                    positive_mov = false;
                }

                //If we are going positive_mov then add the speed
                if (positive_mov == true)
                {
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + (Time.deltaTime * speed));
                }
                //If we are going backward then subtract the speed
                if (positive_mov == false)
                {
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - (Time.deltaTime * speed));
                }
                break;
            case Direction.X_TRAVEL:
                //If we reach the end then change our direction boolean to go forwards
                if (gameObject.transform.position.x <= MinPosition.x)
                {
                    positive_mov = true;
                }
                //If we reach the begining then change our direction boolean to go backwards
                if (gameObject.transform.position.x >= MaxPosition.x)
                {
                    positive_mov = false;
                }

                //If we are going positive_mov then add the speed
                if (positive_mov == true)
                {
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x + (Time.deltaTime * speed), gameObject.transform.position.y, gameObject.transform.position.z);
                }
                //If we are going backward then subtract the speed
                if (positive_mov == false)
                {
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x - (Time.deltaTime * speed), gameObject.transform.position.y, gameObject.transform.position.z);
                }
                break;
            case Direction.Y_TRAVEL:
                //If we reach the end then change our direction boolean to go forwards
                if (gameObject.transform.position.y <= MinPosition.y)
                {
                    positive_mov = true;
                }
                //If we reach the begining then change our direction boolean to go backwards
                if (gameObject.transform.position.y >= MaxPosition.y)
                {
                    positive_mov = false;
                }

                //If we are going positive_mov then add the speed
                if (positive_mov == true)
                {
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x + (Time.deltaTime * speed), gameObject.transform.position.y, gameObject.transform.position.z);
                }
                //If we are going backward then subtract the speed
                if (positive_mov == false)
                {
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x - (Time.deltaTime * speed), gameObject.transform.position.y, gameObject.transform.position.z);
                }
                break;
        }
    }
}
