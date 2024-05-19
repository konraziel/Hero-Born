using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Vector3 CamOffset = new Vector3(0f, 1.2f, -2.6f); // This determines how far away and at what angle our camera is offset from the player at
    private Transform _target;
    void Start()
    {
        _target = GameObject.Find("Player").transform; // target the players transform
    }

    void LateUpdate()
    {
        // Set the cameras position to the desired offset, and set the camera to look at our player at all times
        this.transform.position = _target.TransformPoint(CamOffset);
        this.transform.LookAt(_target);
    }
}
