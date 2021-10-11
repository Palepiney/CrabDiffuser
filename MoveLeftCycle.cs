using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftCycle : MonoBehaviour {

	// Move speed of object and waypoints outside of camera to the right and left for spawning and deletion
	[SerializeField]
	float moveSpeed = 5f;
	[SerializeField]
	float leftWayPointX = -8f, rightWayPointX = 8f;

	// Update is called once per frame
	void Update () {
		// Moves object to the left with move speed
		transform.position = new Vector2 (transform.position.x + moveSpeed * Time.deltaTime,
			transform.position.y);
		// Resets object offscreen if it goes past left waypoint
		if (transform.position.x < leftWayPointX)
			transform.position = new Vector2 (rightWayPointX, transform.position.y);
	}
}
