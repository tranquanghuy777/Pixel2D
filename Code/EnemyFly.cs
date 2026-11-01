
using UnityEngine;

public class EnemyFly : MonoBehaviour
{
    [Header("Di chuyen")]
    [SerializeField] private float speed = 3f;
    [SerializeField] private float amplitude = 3f;

    [Header("Nguoi choi")]
    [SerializeField] private Transform player;
    [SerializeField] private float detectionRange = 4f;
    [SerializeField] private float attackRange = 1.5f;

    [Header("Huong Sprite")]
    [SerializeField] private bool spriteFacesRight = true;

    private Vector3 startPos;
    private bool movingRight = true;
    private bool chasing = false;

    private Animator anim;

    void Start()
    {
        startPos = transform.position;
        anim = GetComponent<Animator>();

        if (anim == null)
        {
            Debug.LogError("Quai vat chua co Animator!", this);
        }
    }

    void Update()
    {
        if (player == null)
        {
            if (anim != null)
                anim.SetBool("TanCong", false);

            Patrol();
            return;
        }

        float distance = Vector2.Distance(
            transform.position,
            player.position
        );

        // Phat hien nguoi choi
        if (distance <= detectionRange)
        {
            chasing = true;
        }
        // Nguoi choi da ra khoi pham vi
        else
        {
            chasing = false;
        }

        if (chasing)
        {
            // Quay dau ve phia nguoi choi
            FlipTowards(
                player.position.x - transform.position.x
            );

            // Du gan de tan cong
            if (distance <= attackRange)
            {
                if (anim != null)
                    anim.SetBool("TanCong", true);

                // Dung lai khi tan cong
            }
            else
            {
                if (anim != null)
                    anim.SetBool("TanCong", false);

                // Duoi theo nguoi choi
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    player.position,
                    speed * Time.deltaTime
                );
            }
        }
        else
        {
            // Khong con thay nguoi choi
            if (anim != null)
                anim.SetBool("TanCong", false);

            // Quay lai tuan tra
            Patrol();
        }
    }

    void Patrol()
    {
        float leftBound = startPos.x - amplitude;
        float rightBound = startPos.x + amplitude;

        if (movingRight)
        {
            transform.position +=
                Vector3.right * speed * Time.deltaTime;

            FlipTowards(1f);

            if (transform.position.x >= rightBound)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.position +=
                Vector3.left * speed * Time.deltaTime;

            FlipTowards(-1f);

            if (transform.position.x <= leftBound)
            {
                movingRight = true;
            }
        }
    }

    void FlipTowards(float directionX)
    {
        if (directionX == 0)
            return;

        Vector3 scale = transform.localScale;

        // Sprite goc quay sang phai
        float direction = spriteFacesRight ? 1f : -1f;

        if (directionX < 0)
            direction *= -1f;

        scale.x = Mathf.Abs(scale.x) * direction;

        transform.localScale = scale;
    }
}
