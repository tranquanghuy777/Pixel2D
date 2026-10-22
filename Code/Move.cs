using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    public Rigidbody2D rb;
    public float tocDo=4;
    public float traiPhai;
    public Animator ani;
    private float jum = 5f;
    [SerializeField] private Transform check;
    [SerializeField] private LayerMask San;
    [SerializeField] private bool isGround;
    private AudioManager audioManager;
    void Start()
    {
        audioManager = FindAnyObjectByType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.aKey.isPressed)
        {
            traiPhai = -1;
            
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            traiPhai=1;
            
        }
        else
        {
            traiPhai = 0;
        }
        rb.linearVelocity = new Vector2(tocDo*traiPhai, rb.linearVelocity.y);
        if ( traiPhai == 1)
        {
            transform.localScale = new Vector3(1,1,1);
        }
        else if(traiPhai == -1)
        {
            transform .localScale = new Vector3(-1,1,1);
        }
        ani.SetFloat("chay",Mathf.Abs(traiPhai));
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            ani.SetTrigger("CT");
        }
        Nhay();
    }
    private void Nhay()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame&&isGround)
        {
            audioManager.PlayJumpSound();
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jum);
        }
        isGround = Physics2D.OverlapCircle(check.position, 0.2f, San);
    }
}
