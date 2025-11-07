using UnityEngine;

public class BouncePad : MonoBehaviour
{
    [Header("Ajustes de rebote")]
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
    public float bounceForce = 20f;          
    public string playerTag = "Player";     
    public GameObject bounceEffect;          
=======
=======
>>>>>>> 04a1c26aaf3a93612d8754802d05769785fe270f
=======
>>>>>>> 04a1c26aaf3a93612d8754802d05769785fe270f
=======
>>>>>>> a8ba3f5bb9fe1b2325630dafe6fa158633f87c53
=======
>>>>>>> a8ba3f5bb9fe1b2325630dafe6fa158633f87c53
=======
>>>>>>> a8ba3f5bb9fe1b2325630dafe6fa158633f87c53
    public float bounceForce = 10f;          // Fuerza del salto
    public string playerTag = "Player";      // Tag del jugador
    public GameObject bounceEffect;          // Efecto visual opcional
>>>>>>> 04a1c26aaf3a93612d8754802d05769785fe270f

    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag(playerTag))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

            if (rb != null)
            {
               
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

                
                rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
            }

            
        }
    }
}