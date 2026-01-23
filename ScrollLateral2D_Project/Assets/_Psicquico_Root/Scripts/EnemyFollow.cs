using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    //Referencia al jugador
    public Transform player;

    //Velocidad de movimiento del enemigo
    public float speed = 3f;

    private Animator animator;
    private Rigidbody2D rb;


    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Comprobamos que el jugador exista
        if (player == null) return;
        {

            //Posici�n del enemigo
            Vector3 position = transform.position;

            //Comparamos la posici�n X del jugador con la del enemigo
            if (player.position.x > position.x)
            {
                position.x += speed * Time.deltaTime;
            }
            else if (player.position.x < position.x)
            {
                position.x -= speed * Time.deltaTime;
            }
            //Aplicamos la nueva posici�n (Y y Z no cambian)
            transform.position = position;


            //Animaci�n
            bool isMoving = rb.linearVelocity.magnitude > 0.1f;
            animator.SetBool("isMoving", isMoving);

        }
    }
}
