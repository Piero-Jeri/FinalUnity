using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.TextCore.Text;

public class BullletScripts : MonoBehaviour
{

    public float speed;
    private Rigidbody2D Rigidbody2D;
    private Vector3 Direction;


    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D.linearVelocity = Direction * speed;

        if (Direction.x >= 0.0f)
        {
            transform.localScale = new Vector3(-0.5f, 0.5f, 1.0f);
        }
        else
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 1.0f);
        }
    }

    public void setDirection(Vector3 direction)
    {
        Direction = direction;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Enemigo Enemy = collision.collider.GetComponent<Enemigo>();
        if (Enemy != null)
        {
            Destroy(gameObject);
        }
    }
}
