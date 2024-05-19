using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwappingPlatform : MonoBehaviour
{
    // Variables to let us know current platform position as well as how we want to shift the platform
    Vector3 CurrentPosition;
    public Vector3 PositionShift = new Vector3(0, 0, 0);
    public float time = 1; // Denotes how often, in seconds, the switch happens

    // Start is called before the first frame update
    void Start()
    {
        // On start get current transform position and start coroutine for the platform timer
        CurrentPosition = gameObject.transform.position;
        StartCoroutine(PlatformTimer());
    }

    // Used to replicate a timer which triggers the position swap of the platform on some constant interval, set by the time variable
    IEnumerator PlatformTimer()
    {
        // This acts as our timer and flag to determine which position the platform is at
        WaitForSeconds wait = new WaitForSeconds(time);
        bool switch_flag = true;

        while(true) // Loop should be constantly going while the current scene is in play
        {
            if (switch_flag == false)
            {
                // Records current position, and then reverts position shift based on current position
                CurrentPosition = gameObject.transform.position;
                gameObject.transform.position = new Vector3(CurrentPosition.x - PositionShift.x, CurrentPosition.y - PositionShift.y, CurrentPosition.z - PositionShift.z);
                switch_flag = true;
            }
            else if (switch_flag == true)
            {
                // Records current position, and then performs position shift based on current position
                CurrentPosition = gameObject.transform.position;
                gameObject.transform.position = new Vector3(CurrentPosition.x + PositionShift.x, CurrentPosition.y + PositionShift.y, CurrentPosition.z + PositionShift.z);
                switch_flag = false;
            }
            yield return wait; // Pause the loop for some amount of seconds
        }
    }
}
