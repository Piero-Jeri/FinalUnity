using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    private Vector3 Direction;
    [SerializeField] private float speed;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Rigidbody2D.linearVelocity = Direction * speed;
    }

    public void setDirection(Vector3 direction)
    {
        Direction = direction;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController Character = collision.collider.GetComponent<PlayerController>();
        if(Character != null)
        {
            GameManager.Instance.PerderVida();
            destroyEnemyBullet();
        }
    }

    public void destroyEnemyBullet()
    {
        Destroy(gameObject);
    }
}
