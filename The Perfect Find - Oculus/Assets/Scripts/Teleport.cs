using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {

    public int floorChange;

    // Teleport the player if they collide
    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            other.transform.position = new Vector3(0, other.transform.position.y + 1 + (11 * floorChange), -5.5f);
        }
    }

}
