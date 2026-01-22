using UnityEngine;

public class MovimientoPlayer_Test : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(x, y, 0);
        transform.position += movimiento * speed * Time.deltaTime;
    }
}
