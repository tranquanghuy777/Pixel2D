using UnityEngine;

public class DC_Platform : MonoBehaviour
{
    [SerializeField] private Transform PotA;
    [SerializeField] private Transform PotB;
    [SerializeField] private float speed = 2f;
    private Vector3 targetPos;
    private Transform playerTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetPos = PotA.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        if(Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            targetPos = targetPos == PotA.position ? PotB.position : PotA.position;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(null);
        }
    }
}
