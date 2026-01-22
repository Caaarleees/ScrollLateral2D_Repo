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
        if (player != null)
        {

            //Dirección hacia el jugador
            Vector3 direction = player.position - transform.position;

            //Movimiento del enemigo hacia el jugador
            transform.position += direction.normalized * speed * Time.deltaTime;


             
        }
    }
}
