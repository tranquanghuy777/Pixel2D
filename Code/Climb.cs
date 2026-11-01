using UnityEngine;
using UnityEngine.InputSystem;

public class Climb : MonoBehaviour
{
    public float tocDoClimb = 4f;

    private bool isClimb = false;
    private Rigidbody2D rb;
    private float gravityGoc;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gravityGoc = rb.gravityScale;
    }

    void Update()
    {
        if (isClimb)
        {
            var kb = Keyboard.current;
            if (kb == null) return;

            float verticalInput = 0f;
            if (kb.wKey.isPressed || kb.upArrowKey.isPressed) verticalInput += 1f;
            if (kb.sKey.isPressed || kb.downArrowKey.isPressed) verticalInput -= 1f;

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, verticalInput * tocDoClimb);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isClimb = true;
            rb.gravityScale = 0f;
            rb.linearVelocity = Vector2.zero;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isClimb = false;
            rb.gravityScale = gravityGoc;
        }
    }
}