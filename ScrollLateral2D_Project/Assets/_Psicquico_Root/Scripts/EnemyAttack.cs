using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Transform player;
    public float attackDistance = 1.5f;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (player == null) return;

        // Distancia SOLO en el eje X
        float distanceX = Mathf.Abs(player.position.x - transform.position.x);

        if (distanceX <= attackDistance)
        {
            animator.SetTrigger("attack");
        }
    }
}
