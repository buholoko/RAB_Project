using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Header("Motion Settings")]
    public float speed = 2f; // velocidad de movimiento

    [Header("Horizontal limits (X)")]
    public float minX = -4f; 
    public float maxX = 4f;

    [Header("Vertical limits (Y)")]
    public float minY = -2f;
    public float maxY = 2f;

    [Header("Depth limits (Z)")]
    public float minZ = -3f;
    public float maxZ = 3f;


    [Header("Movement Type")]
    public bool moveHorizontal = true; // Movimiento en dirección X
    public bool moveVertical = false; // Movimiento en dirección Y
    public bool moveDepth = false; // Movimiento en dirección Z
    public bool startPosition = true; // Movimiento inicial, si es verdadero, irá al valor máximo; si es falso, irá al valor mínimo.
    
    private Vector3 dir;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartDirection();
    }

    // Update is called once per frame
    void Update()
    {
        MovePosition();
    }

    void StartDirection()
    {
        if (moveHorizontal)
        {
            if (startPosition)
            {
                dir = Vector3.right;
            }
            else
            {
                dir = Vector3.left;
            }
        }
        else if (moveVertical)
        {
            if (startPosition)
            {
                dir = Vector3.up;
            }
            else
            {
                dir = Vector3.down; 
            }
        }
        else if (moveDepth)
        {
            if (startPosition)
            {
                dir = Vector3.forward;
            }
            else
            {
                dir = Vector3.back;
            }
        }
    }
    void MovePosition()
    {
        transform.Translate(dir * speed * Time.deltaTime);

        if (moveHorizontal)
        {
            if (transform.position.x <= minX)
            {
                dir = Vector3.right;
            }
            else if (transform.position.x >= maxX)
            {
                dir = Vector3.left;
            }
        }
        else if (moveVertical)
        {
            if (transform.position.y <= minY)
            {
                dir = Vector3.up;
            }
            else if (transform.position.y >= maxY)
            {
                dir = Vector3.down;
            }
        }
        else if (moveDepth)
        {
            if (transform.position.z <= minZ)
            {
                dir = Vector3.forward;
            }
            else if (transform.position.z >= maxY)
            {
                dir = Vector3.back;
            }
        }
    }


}
