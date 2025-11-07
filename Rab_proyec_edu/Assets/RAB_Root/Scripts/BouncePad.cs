using UnityEngine;

public class BouncePad : MonoBehaviour
{
    [Header("Ajustes de rebote")]
    public float bounceForce = 20f;          // Fuerza del salto
    public string playerTag = "Player";      // Tag del jugador
    public GameObject bounceEffect;          // Efecto visual opcional

    private void OnCollisionEnter(Collision collision)
    {
        // Si el objeto que colisiona tiene el tag del jugador
        if (collision.gameObject.CompareTag(playerTag))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

            if (rb != null)
            {
                // Anula cualquier velocidad descendente antes del impulso
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

                // Aplica una fuerza hacia arriba
                rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
            }

            // Efecto visual opcional
            if (bounceEffect != null)
            {
                Instantiate(bounceEffect, transform.position, Quaternion.identity);
            }

            Debug.Log("🟧 ¡Rebote!");
        }
    }
}