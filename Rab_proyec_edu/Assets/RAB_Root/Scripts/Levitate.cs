
using UnityEngine;

public class Levitate : MonoBehaviour
{
    [Header("Altura del movimiento (amplitud)")]
    public float amplitude = 0.5f; // Qué tanto sube y baja

    [Header("Velocidad de levitación")]
    public float speed = 2f; // Qué tan rápido oscila

    [Header("Altura base (opcional)")]
    public float baseHeight = 0f; // Altura inicial de referencia (0 = la altura actual)

    private float startY;

    void Start()
    {
        // Guarda la posición inicial del objeto
        startY = transform.position.y;

        // Si quieres fijar una altura base específica, activa esta línea:
        if (baseHeight != 0)
            startY = baseHeight;
    }

    void Update()
    {
        // Calcula el nuevo valor de altura usando una onda senoidal
        float newY = startY + Mathf.Sin(Time.time * speed) * amplitude;

        // Actualiza la posición del objeto
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}

