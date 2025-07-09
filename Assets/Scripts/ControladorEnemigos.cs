using UnityEngine;
using System.Linq;

public class ControladorEnemigos : MonoBehaviour
{
    private float minX, minY, maxX, maxY;

    [SerializeField] private Transform[] puntos;
    [SerializeField] private GameObject[] enemigos;
    [SerializeField] private float tiempoEnemigos;

    private float tiempoSiguienteEnemigo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxX = puntos.Max(punto => punto.position.x);
        maxY = puntos.Max(punto => punto.position.y);
        minX = puntos.Min(punto => punto.position.x);
        minY = puntos.Min(punto => punto.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        tiempoSiguienteEnemigo += Time.deltaTime;

        if(tiempoSiguienteEnemigo >= tiempoEnemigos)
        {
            tiempoSiguienteEnemigo = 0;
            CrearEnemigo();
        }
    }

    private void CrearEnemigo()
    {
        int numeroEnemigo = Random.Range(0, enemigos.Length);
        Vector2 posiciónAleatoria = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        Instantiate(enemigos[numeroEnemigo], posiciónAleatoria, Quaternion.identity);
    }
}
