using UnityEngine;
using System.Collections;

public class TriggerEscalera : MonoBehaviour
{
    public Transform[] plataformas;
    public float[] alturasSubida;   // UNA ALTURA POR PLATAFORMA
    public float velocidad = 2f;
    public float retrasoEntrePlataformas = 0.1f;

    private bool activado = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !activado)
        {
            activado = true;
            StartCoroutine(ActivarEscalera());
        }
    }

    IEnumerator ActivarEscalera()
    {
        for (int i = 0; i < plataformas.Length; i++)
        {
            Transform plataforma = plataformas[i];

            float altura = alturasSubida[i];

            Vector3 inicio = plataforma.position;
            Vector3 destino = inicio + Vector3.up * altura;

            float t = 0f;
            while (t < 1f)
            {
                t += Time.deltaTime * velocidad;
                plataforma.position = Vector3.Lerp(inicio, destino, t);
                yield return null;
            }

            yield return new WaitForSeconds(retrasoEntrePlataformas);
        }
    }
}
