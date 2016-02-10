using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{

    public float currentTime = 30.0f;

    // Update is called once per frame
    void Update()
    {

        // UPDATE TIME
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
        }
        else
        {
            currentTime = 0;
        }

        // If time has run out, return to the main menu
        if (currentTime <= 0)
        {
            Application.LoadLevel("Level Select");
        }

    }
}
