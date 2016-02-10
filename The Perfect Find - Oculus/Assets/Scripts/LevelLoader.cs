using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {

    public int levelToLoad;
    private string loadPrompt;

    private GameObject gd;
    private GameData gameData;

    void Start()
    {
        gd = GameObject.Find("GameData");
        gameData = gd.GetComponent<GameData>();
    }


    // Find what door the player is standing in front of and transition to that level
    void OnTriggerStay(Collider other){
        if (Input.GetButtonDown("Select")){
            if (levelToLoad == 11)
            {
                if(gameData.L1check && gameData.L2check && gameData.L3check && gameData.L4check && gameData.L5check &&
                    gameData.L6check && gameData.L7check && gameData.L8check && gameData.L9check && gameData.L10check) {
                    Application.LoadLevel("Level " + levelToLoad.ToString());
                }
            }
            else
            {
                Application.LoadLevel("Level " + levelToLoad.ToString());
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
