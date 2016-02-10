using UnityEngine;
using System.Collections;

public class MoveGubs : MonoBehaviour {

    // Keep gubs in a constant freefall
    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Respawn") || other.tag.Equals("Finish"))
        {
            other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y + 10, other.transform.position.z);
        }
    }
}
