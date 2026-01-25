using UnityEngine;
using UnityEngine.SceneManagement;

public class PickupCambioEscena : MonoBehaviour
{
    [SerializeField] private string nombreEscenaDestino = "LVL_FinalBoss";

    private void OnTriggerEnter(Collider other)
    {
        // Comprobamos que el que entra en el trigger es el Player
        if (other.CompareTag("Player"))
        {
            // Opcional: destruir el pick up
            Destroy(gameObject);

            // Cargar la escena del jefe final
            SceneManager.LoadScene("LVL_FinalBoss");
        }
    }
}
