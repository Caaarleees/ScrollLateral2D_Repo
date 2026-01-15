using UnityEngine;

public class FallDetecter : MonoBehaviour
{
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic; 
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // jugador debe tener tag "Player"
        {
            rb.bodyType = RigidbodyType2D.Dynamic; 
            rb.gravityScale = 1f;
            rb.angularVelocity = Random.Range(-200f, 200f); // Giro opcional
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            rb.bodyType = RigidbodyType2D.Static; 
        }
    }
}
