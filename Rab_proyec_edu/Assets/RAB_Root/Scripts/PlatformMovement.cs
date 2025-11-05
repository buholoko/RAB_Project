using UnityEngine;

public class PlatformMoving : MonoBehaviour
{
    public float speed = 2f;          // Velocidad de movimiento
    public float height = 3f;         // Distancia máxima hacia arriba

    private Vector3 startPos;         // Posición inicial

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Movimiento vertical usando una onda senoidal
        float newY = startPos.y + Mathf.Sin(Time.time * speed) * height;
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}
