using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int vidas = 3;

    public HUD hud;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PerderVida()
    {
        vidas -= 1;
        if (vidas == 0)
        {
            SceneManager.LoadScene("GameOver");
        }

        hud.DesactivarVida(vidas);
    }

    public bool RecuperarVida()
    {        
        if (vidas == 3)
        {
            return false;
        }
        hud.ActivarVida(vidas);
        vidas += 1;

        return true;
    }
}
