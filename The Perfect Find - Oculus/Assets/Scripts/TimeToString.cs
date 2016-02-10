using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeToString : MonoBehaviour
{

    public GameObject TimeControl;
    public Timer timeScript;
    public Text theTime;

    // Use this for initialization
    void Start()
    {

        timeScript = TimeControl.GetComponent<Timer>();

    }

    // Update is called once per frame
    void Update()
    {

        theTime.text = string.Format("{0:0.0}", timeScript.currentTime);

    }
}