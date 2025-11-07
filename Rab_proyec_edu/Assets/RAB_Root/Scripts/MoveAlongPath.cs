
using UnityEngine;

public class MoveAlongPath : MonoBehaviour
{
    [Header("Puntos del recorrido (en orden)")]
    public Transform[] waypoints;

    [Header("Velocidad de movimiento")]
    public float speed = 5f;

    [Header("Altura fija (Y)")]
    public float fixedHeight = 1f;

    private int currentWaypoint = 0;

    void Start()
    {
        if (waypoints.Length == 0)
        {
            Debug.LogError("No hay waypoints asignados al script MoveAlongPath.");
            enabled = false;
            return;
        }

        // Ajusta la altura inicial del objeto
        Vector3 startPos = transform.position;
        startPos.y = fixedHeight;
        transform.position = startPos;
    }

    void Update()
    {
        if (waypoints.Length == 0) return;

        // Calcula el destino actual
        Vector3 targetPos = waypoints[currentWaypoint].position;
        targetPos.y = fixedHeight; // Mantiene la altura fija

        // Mueve el objeto hacia el destino
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        // Si llega al punto, pasa al siguiente
        if (Vector3.Distance(transform.position, targetPos) < 0.05f)
        {
            currentWaypoint++;
            if (currentWaypoint >= waypoints.Length)
                currentWaypoint = 0; // Reinicia el recorrido (loop)
        }
    }

    // (Opcional) dibuja líneas entre los waypoints en el editor
    void OnDrawGizmos()
    {
        if (waypoints == null || waypoints.Length < 2) return;

        Gizmos.color = Color.cyan;
        for (int i = 0; i < waypoints.Length - 1; i++)
        {
            Gizmos.DrawLine(waypoints[i].position, waypoints[i + 1].position);
        }

        Gizmos.color = Color.yellow;
        foreach (Transform wp in waypoints)
        {
            Gizmos.DrawSphere(wp.position, 0.2f);
        }
    }
}

