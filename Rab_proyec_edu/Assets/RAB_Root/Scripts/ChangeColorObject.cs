using UnityEngine;

public class ColorChangeBlock : MonoBehaviour
{
    [Header("Configuración de colores")]
    public Color[] colors; // 
    private int currentIndex = 0;
    private Renderer rend;

    [Header("Configuración del jugador")]
    public string playerTag = "Player";

    void Start()
    {
        rend = GetComponent<Renderer>();

        if (colors.Length == 0)
        {
            
            colors = new Color[] { Color.red, Color.green, Color.blue, Color.yellow };
        }

        rend.material.color = colors[currentIndex];
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            // Cambia al siguiente color
            currentIndex = (currentIndex + 1) % colors.Length;
            rend.material.color = colors[currentIndex];
        }
    }
}
