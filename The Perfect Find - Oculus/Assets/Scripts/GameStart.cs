using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour
{

    public GameObject Player;
    public OVRPlayerController playerScript;
    public GameObject TimeControl;
    public Timer timeScript;
    public GameObject gub;

    // Use this for initialization
    void Start()
    {

        playerScript = Player.GetComponent<OVRPlayerController>();
        timeScript = TimeControl.GetComponent<Timer>();

    }

    // Update is called once per frame
    void Update()
    {

        timeScript.currentTime = 30.0f;

        // Start the current level
        if (Input.GetButtonDown("Select"))
        {
            playerScript.Acceleration = 0.3f;
            Instantiate(gub, new Vector3(0, 0, 0), Quaternion.identity);
            Destroy(gameObject);
        }

    }
}
