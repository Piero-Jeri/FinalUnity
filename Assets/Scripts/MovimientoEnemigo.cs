using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    private Rigidbody2D rbd2;
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float distancia;
    [SerializeField] private LayerMask queEsSuelo;


    private void Start()
    {
        rbd2 = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rbd2.linearVelocity = new Vector2(velocidadMovimiento * transform.right.x, rbd2.linearVelocity.y);

        RaycastHit2D informaciónSuelo = Physics2D.Raycast(transform.position, transform.right, distancia, queEsSuelo);

        if (informaciónSuelo)
        {
            Girar();
        }
    }

    private void Girar()
    {
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.right * distancia);
    }
}
