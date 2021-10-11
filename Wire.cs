using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Wire : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = -5f;
    private BoxCollider2D wireCollider;
    private SpriteRenderer rend;
    public Sprite wireDefault, wireSnipped;

    // Will check if player is close enough to snip wire.
    private bool snipAllowed;


    // Start is called before the first frame update
    void Start()
    {
        // Declare variables
        wireCollider = GetComponent<BoxCollider2D>();
        rend = GetComponent<SpriteRenderer>();

        // Sets wire sprite to default wire
        rend.sprite = wireDefault;

    }

    // Update is called once per frame
    void Update()
    {
        // If player is near wire and presses key/clicks claw, call snip function
        if (snipAllowed && Input.GetKeyDown(KeyCode.Z))
            Snip();

        // Controls movement of wires so they slide leftward
        transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime,
            transform.position.y);
        // If wires go off screen to the left destroy
        if (transform.position.x < -13f)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Checks if player is close to wire and sets snip allowed to true
        if (collision.gameObject.name.Equals("Player"))
        {
            snipAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Checks if player is far from wire and sets snip allowed to false
        if (collision.gameObject.name.Equals("Player"))
        {
            snipAllowed = false;
        }
    }

    private void Snip()
    {
        // Changes wire sprite to a snipped wire, disables wire collider (can only be snipped once), and increases score
        rend.sprite = wireSnipped;
        wireCollider.enabled = false;
        GameControl.instance.IncreaseYourScore();
    }
}
