using UnityEngine;

using UnityEngine.SceneManagement; // es una libreria que nos permite cargar /descargar escenas

public class SceneManagement : MonoBehaviour
{
    public void SceneLoader(int sceneToLoad)

    {

        SceneManager.LoadScene(sceneToLoad);

    }

    public void ExitGame()
    {
        Debug.Log("Hascerrado el juego.");
        Application.Quit(); //Salir de cualquier juego

    }


}
