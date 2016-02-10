using UnityEngine;
using System.Collections;

public class ShowComplete : MonoBehaviour {

    public int level;
    private GameObject gd;
    private GameData gameData;

    void Start() {
        gd = GameObject.Find("GameData");
        gameData = gd.GetComponent<GameData>();
    }

	// Update is called once per frame
	void Update () {

        // Update to show user what levels have been completed
        if (level == 1) { if (gameData.L1check) { gameObject.GetComponent<Renderer>().material.color = Color.green; } }
        if (level == 2) { if (gameData.L2check) { gameObject.GetComponent<Renderer>().material.color = Color.green; } }
        if (level == 3) { if (gameData.L3check) { gameObject.GetComponent<Renderer>().material.color = Color.green; } }
        if (level == 4) { if (gameData.L4check) { gameObject.GetComponent<Renderer>().material.color = Color.green; } }
        if (level == 5) { if (gameData.L5check) { gameObject.GetComponent<Renderer>().material.color = Color.green; } }
        if (level == 6) { if (gameData.L6check) { gameObject.GetComponent<Renderer>().material.color = Color.green; } }
        if (level == 7) { if (gameData.L7check) { gameObject.GetComponent<Renderer>().material.color = Color.green; } }
        if (level == 8) { if (gameData.L8check) { gameObject.GetComponent<Renderer>().material.color = Color.green; } }
        if (level == 9) { if (gameData.L9check) { gameObject.GetComponent<Renderer>().material.color = Color.green; } }
        if (level == 10) { if (gameData.L10check) { gameObject.GetComponent<Renderer>().material.color = Color.green; } }

    }
}
