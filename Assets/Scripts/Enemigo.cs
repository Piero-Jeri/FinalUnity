using UnityEngine;

public class Enemigo : MonoBehaviour
{
    private int health = 3;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.PerderVida();

            //other.gameObject.GetComponent<PlayerController>().AplicarGolpe();
        }
    }
    public void Hit()
    {
        health = health - 1;
        if (health == 0) Destroy(gameObject);
    }
}
