using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{

    public BoxCollider2D BGcollider;
    public Rigidbody2D rb;

    private float width;
    private float scrollspeed = -5f;

    void Start()
    {
        // Declare variables
        BGcollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        width = BGcollider.size.x;
        BGcollider.enabled = false;

        rb.velocity = new Vector2(scrollspeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // If background reaches left side of camera, reset it to the right so it looks like it is infinite
        if(transform.position.x < -width + 1)
        {
            Vector2 resetPosition = new Vector2(width * 2f, 0);
            transform.position = (Vector2)transform.position + resetPosition;
        }
    }

    /*void ResetObstacle()
    {
        transform.GetChild(0).localPosition = new Vector3(0, Random.Range(-3, 4), 0);
    }*/
}
