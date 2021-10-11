using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleControl : MonoBehaviour
{
	// Movement speed
	[SerializeField]
	float moveSpeed = -5f;

	// Update is called once per frame
	void Update()
	{
		// Controls movement of urchin so it slides leftward
		transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime,
			transform.position.y);

		// If obstacles go off screen to the left, destroy
		if (transform.position.x < -13f)
			Destroy(gameObject);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		// If player touches obstacle, call playerhit function
		if (col.gameObject.name.Equals("Player"))
		{
			GameControl.instance.PlayerHit();
		}

	}
}
