using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    [Header("Configuración")]
    public int hitsToBreak = 3;       
    public string playerTag = "Player"; 

    private int hitCount = 0;         

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag(playerTag))
        {
            hitCount++;
            Debug.Log($"Golpe #{hitCount} recibido");

           
            if (hitCount >= hitsToBreak)
            {
                Break();
            }
        }
    }

    void Break()
    {
       
        Destroy(gameObject);
    }
}
