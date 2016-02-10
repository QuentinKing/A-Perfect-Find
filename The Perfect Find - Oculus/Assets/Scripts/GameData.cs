using UnityEngine;
using System.Collections;

public class GameData : MonoBehaviour {

    // Keep track of levels completed

    public bool L1check = false;
    public bool L2check = false;
    public bool L3check = false;
    public bool L4check = false;
    public bool L5check = false;
    public bool L6check = false;
    public bool L7check = false;
    public bool L8check = false;
    public bool L9check = false;
    public bool L10check = false;

    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }

}
