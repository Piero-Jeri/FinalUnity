using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public GameObject BulletPrefab;
    private Rigidbody2D Rigidbody2D;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    public float fuerzaGolpe;
    private bool mirandoDerecha = true;
    private bool Grounded;
    private Animator animator;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        //Horizontal = Input.GetAxisRaw("Horizontal");
        Movement();
        MovementProcess();

        Debug.DrawRay(transform.position, Vector3.down * 1.1f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 1.1f))
        {
            Grounded = true;
        }
        else Grounded = false;
    }

    /*private void FixedUpdate()
    {
        Rigidbody2D.Velocity = new Vector2(Horizontal, Rigidbody2D.linearVelocity.y);
    }*/

    public void Movement()
    {

        //Animator.SetBool("IsRunning", Rigidbody2D.angularVelocity != 0.0f);

        if (Input.GetKeyDown(KeyCode.W) && Grounded)
            Jump();

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void MovementProcess()
    {
        float inputMovimiento = Input.GetAxis("Horizontal");

        if (inputMovimiento != 0f)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }

        animator.SetBool("IsJumping", !Grounded);


        OrientationGestion(inputMovimiento);
    }

    void OrientationGestion(float inputMovimiento)
    {
        if ((mirandoDerecha == true && inputMovimiento < 0) || (mirandoDerecha == false && inputMovimiento > 0))
        {
            mirandoDerecha = !mirandoDerecha;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
        }
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * jumpForce);
    }

    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = Vector3.right;
        else direction = Vector3.left;

        GameObject Bullet = Instantiate(BulletPrefab, transform.position + direction * 0.2f, Quaternion.identity);
        Bullet.GetComponent<BullletScripts>().setDirection(direction);
    }
    /*public void AplicarGolpe(Vector2 posicionEnemigo)
    {
        Vector2 direccionGolpe = (transform.position.x < posicionEnemigo.x) ? new Vector2(-1, 1) : new Vector2(1, 1);

        Rigidbody2D.AddForce(direccionGolpe * fuerzaGolpe, ForceMode2D.Impulse); 
    }*/
}
