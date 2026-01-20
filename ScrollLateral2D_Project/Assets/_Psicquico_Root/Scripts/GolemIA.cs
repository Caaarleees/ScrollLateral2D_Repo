using UnityEngine;

public class EnemigoIA : MonoBehaviour
{
    [Header("Movimiento y ataque")]
    public float speed = 2f;            // Velocidad del enemigo
    public float detectionRange = 5f;   // Distancia para detectar al jugador
    public float attackRange = 1f;      // Distancia a la que ataca
    public int damage = 1;              // Da�o al jugador
    public float attackCooldown = 1f;   // Tiempo entre ataques

    private Transform player;
    private Rigidbody2D rb;
    private Animator animator;
    private float lastAttackTime;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= attackRange)
        {
            // En rango de ataque
            rb.linearVelocity = Vector2.zero;
            animator.SetBool("isMoving", false);

            if (Time.time >= lastAttackTime + attackCooldown)
            {
                Attack();
                lastAttackTime = Time.time;
            }
        }
        else if (distance <= detectionRange)
        {
            // Moverse hacia el jugador
            MoveTowardsPlayer();
        }
        else
        {
            // No detectar jugador
            animator.SetBool("isMoving", false);
            rb.linearVelocity = Vector2.zero;
        }
    }

    void MoveTowardsPlayer()
    {
        animator.SetBool("isMoving", true);

        Vector2 direction = (player.position - transform.position).normalized;
        rb.linearVelocity = direction * speed;

        // Girar sprite seg�n direcci�n
        if (direction.x > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else
            transform.localScale = new Vector3(-1, 1, 1);
    }

    void Attack()
    {
        // Activar animaci�n de ataque
        animator.SetTrigger("attack");

        // Aplicar da�o si sigue en rango
        if (Vector2.Distance(transform.position, player.position) <= attackRange)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Activar animación de ataque
            animator.SetTrigger("attack");

            // Aplicar daño
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}
