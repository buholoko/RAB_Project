using UnityEngine;

public class BouncePad : MonoBehaviour
{
    [Header("Ajustes de rebote")]
    public float bounceForce = 20f;          
    public string playerTag = "Player";     
    public GameObject bounceEffect;          

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