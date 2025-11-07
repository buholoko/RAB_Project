using UnityEngine;

public class ButtonActivator : MonoBehaviour
{
    [Header("Configuración del botón")]
    public string playerTag = "Player";      
    public GameObject[] platformsToActivate; 
    public float activationDelay = 0.5f;     

    private bool activated = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(playerTag) && !activated)
        {
            activated = true;
            Invoke("ActivatePlatforms", activationDelay);
        }
    }

    void ActivatePlatforms()
    {
        foreach (GameObject platform in platformsToActivate)
        {
            if (platform != null)
            {
                platform.SetActive(true);
            }
        }
    }
}
