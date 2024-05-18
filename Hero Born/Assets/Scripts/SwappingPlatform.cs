using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwappingPlatform : MonoBehaviour
{
    // I'm going to need some variables that tell me about position
    Vector3 CurrentPosition;
    public Vector3 PositionShift = new Vector3(0, 0, 0);
    public float time = 1;

    // Start is called before the first frame update
    void Start()
    {
        CurrentPosition = gameObject.transform.position;
        StartCoroutine(PlatformTimer());
    }

    IEnumerator PlatformTimer()
    {
        WaitForSeconds wait = new WaitForSeconds(time);
        bool switch_flag = true;
        while(true)
        {
            if (switch_flag == false)
            {
                CurrentPosition = gameObject.transform.position;
                gameObject.transform.position = new Vector3(CurrentPosition.x - PositionShift.x, CurrentPosition.y - PositionShift.y, CurrentPosition.z - PositionShift.z);
                switch_flag = true;
            }
            else if (switch_flag == true)
            {
                CurrentPosition = gameObject.transform.position;
                gameObject.transform.position = new Vector3(CurrentPosition.x + PositionShift.x, CurrentPosition.y + PositionShift.y, CurrentPosition.z + PositionShift.z);
                switch_flag = false;
            }
            yield return wait;
        }
    }
}
