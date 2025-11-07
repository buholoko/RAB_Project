using UnityEngine;

public class PressureButton : MonoBehaviour
{
    [Header("Configuración del botón")]
    public float radius = 5f;         
    public float liftForce = 10f;      
    public string activatorTag = "Player"; 
    public GameObject liftEffect;      

    private bool hasActivated = false; 

    private void OnTriggerEnter(Collider other)
    {
        
        if (!hasActivated && other.CompareTag(activatorTag))
        {
            ActivateLift();
            hasActivated = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.CompareTag(activatorTag))
        {
            hasActivated = false;
        }
    }

    void ActivateLift()
    {
        
        if (liftEffect != null)
        {
            Instantiate(liftEffect, transform.position, Quaternion.identity);
        }

       
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearby in colliders)
        {
            Rigidbody rb = nearby.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddForce(Vector3.up * liftForce, ForceMode.Impulse);
            }
        }

        Debug.Log("🟩 Botón activado: ¡Objetos levantados!");
    }

   
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
