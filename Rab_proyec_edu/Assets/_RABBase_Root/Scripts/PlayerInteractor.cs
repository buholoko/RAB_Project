using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{

    [Header("Point System")]

    public int points; //puntos actuales del jugador
    public int winPoints = 1; //Puntos necesarios para ganar

    [Header("scene Management")]
    public SceneManagement sceneManager;
    public int sceneToLoad;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      points = 0; // reseteo la puntuacion al iniciar la escena
      
    }

    // Update is called once per frame
    void Update()
    {
        if (points >= winPoints)
        {
            //condicion de vicotira
            Debug.Log("has completado el juego!");
            sceneManager.SceneLoader(sceneToLoad);


        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {

            points += 1;
            //  Destroy(other.gameObject); esto sirve para destruir los objetos pero se acumula el juego y lo relentiza
            other.gameObject.SetActive(false); // esto sirve para apagar el objeto y no genera basura 
        }
    }

}
