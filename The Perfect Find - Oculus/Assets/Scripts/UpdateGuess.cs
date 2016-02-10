using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateGuess : MonoBehaviour
{

    public GameObject gameData;
    public Reticle gameScript;
    public Text Guesses;

    // Use this for initialization
    void Start()
    {
        gameScript = gameData.GetComponent<Reticle>();
    }

    // Update is called once per frame
    void Update()
    {
        Guesses.text = gameScript.guessNum.ToString();
    }
}
