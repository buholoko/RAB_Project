using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [Header("Configuración de la plataforma")]
    public float fallDelay = 1f;     
    public float destroyDelay = 5f;  
    public string playerTag = "Player";

    private Rigidbody rb;
    private bool isFalling = false;

    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
        rb.isKinematic = true; 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(playerTag) && !isFalling)
        {
            isFalling = true;
            Invoke("Fall", fallDelay); 
        }
    }

    void Fall()
    {
        rb.isKinematic = false; 
        Destroy(gameObject, destroyDelay); 
    }
}
