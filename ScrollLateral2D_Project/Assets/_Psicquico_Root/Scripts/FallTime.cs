using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float tiempoParaCaer = 3f; // Segundos antes de caer
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic; // No cae al inicio

        // Llama al método "Caer" después de tiempoParaCaer segundos
        Invoke("Caer", tiempoParaCaer);
    }

    void Caer()
    {
        rb.bodyType = RigidbodyType2D.Dynamic; // Empieza a caer
        rb.gravityScale = 1f; // Asegúrate de que tenga gravedad
    }
}
