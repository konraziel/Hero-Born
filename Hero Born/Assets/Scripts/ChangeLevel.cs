using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeLevel : MonoBehaviour
{
    int buildindex;

    // Start is called before the first frame update
    void Start()
    {
        buildindex = SceneManager.GetActiveScene().buildIndex; // Gets our current scene by its buildIndex value
        //Debug.Log("build index: " + buildindex);
    }

    void OnTriggerEnter(Collider myCollision)
    {
        // On entering the collision shape, we want to load the next scene/level
        SceneManager.LoadScene(buildindex + 1);
    }
}
