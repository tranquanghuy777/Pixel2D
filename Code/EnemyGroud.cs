
using UnityEngine;

public class EnemyGround : MonoBehaviour
{
    [Header("Di chuyen")]
    [SerializeField] private float speed = 3f;
    [SerializeField] private float amplitude = 3f;

    [Header("Nguoi choi")]
    [SerializeField] private Transform player;
    [SerializeField] private float detectionRange = 4f;

    [Header("Huong Sprite")]
    [SerializeField] private bool spriteFacesRight = true;

    private Vector3 startPos;
    private bool movingRight = true;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Chua gan Player thi chi di tuan tra
        if (player == null)
        {
            Patrol();
            return;
        }

        // Khoang cach theo chieu ngang
        float distanceX = Mathf.Abs(
            player.position.x - transform.position.x
        );

        // Player o ngoai pham vi: quay lai tuan tra
        if (distanceX > detectionRange)
        {
            Patrol();
            return;
        }

        // Player trong pham vi: quay mat ve phia Player
        float directionX = player.position.x - transform.position.x;
        FlipTowards(directionX);

        // Duoi theo Player, chi di chuyen theo truc X
        Vector3 targetPos = new Vector3(
            player.position.x,
            transform.position.y,
            transform.position.z
        );

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPos,
            speed * Time.deltaTime
        );
    }

    void Patrol()
    {
        float leftBound = startPos.x - amplitude;
        float rightBound = startPos.x + amplitude;

        if (movingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            FlipTowards(1f);

            if (transform.position.x >= rightBound)
                movingRight = false;
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            FlipTowards(-1f);

            if (transform.position.x <= leftBound)
                movingRight = true;
        }
    }

    void FlipTowards(float directionX)
    {
        if (Mathf.Abs(directionX) < 0.001f)
            return;

        Vector3 scale = transform.localScale;

        float direction = spriteFacesRight ? 1f : -1f;

        if (directionX < 0)
            direction *= -1f;

        scale.x = Mathf.Abs(scale.x) * direction;
        transform.localScale = scale;
    }
}
