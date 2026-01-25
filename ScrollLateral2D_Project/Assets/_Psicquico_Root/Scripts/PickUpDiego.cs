using UnityEngine;
using UnityEngine.SceneManagement;

public class PickupCambioEscena_DiegoACarles : MonoBehaviour
{
    [SerializeField] private string nombreEscenaDestino = "LVL_CarlesTest";

    private void OnTriggerEnter(Collider other)
    {
        // Comprobamos que el que entra en el trigger es el Player
        if (other.CompareTag("Player"))
        {

            // Cargar la escena de destino
            SceneManager.LoadScene("LVL_CarlesTest");
        }
    }
}
