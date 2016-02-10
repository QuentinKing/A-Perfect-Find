using UnityEngine;
using System.Collections;

public class ConstantMove : MonoBehaviour {
    public Transform[] movePoints;
    public float moveSpeed;
    private int currentPoint;

	// Use this for initialization
	void Start () {
        transform.position = movePoints[0].position;
        currentPoint = 0;
	}
	
	// Update is called once per frame
	void Update () {

        // Sets current target
        if (transform.position == movePoints[currentPoint].position)
        {
            if (currentPoint == 1)
            {
                currentPoint = 0;
            }
            else {
                currentPoint = 1;
            }
        }

        if (currentPoint > movePoints.Length) {
            currentPoint = 0;
        }

        // Move to position
        transform.position = Vector3.MoveTowards(transform.position, movePoints[currentPoint].position, moveSpeed * Time.deltaTime);
	}
}
