using UnityEngine;

public class Shark : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public int Animator ani;
    public Quaternion angulo;
    public float grado;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      ani =  GetComponent<Animator>();
    }

    public void Comportamiento_Enemigo()
    {
        cronometro += 1 * Time.deltaTime;
        if (cronometro >=4) 
        { 
            rutina = Random.Range(0, 2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
