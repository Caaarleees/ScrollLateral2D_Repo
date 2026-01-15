using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Lights : MonoBehaviour
{
    public float velocidad = 2f;      // rápido late
    public float intensidadMin = 0.5f; // Intensidad mínima
    public float intensidadMax = 1.5f; // Intensidad máxima

    private Light2D luz;

    void Start()
    {
        luz = GetComponent<Light2D>();
    }

    void Update()
    {
        luz.intensity = Mathf.Lerp(intensidadMin, intensidadMax, (Mathf.Sin(Time.time * velocidad) + 1f) / 2f);
    }
}
