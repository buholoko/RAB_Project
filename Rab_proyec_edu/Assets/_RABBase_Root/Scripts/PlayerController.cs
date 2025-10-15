using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Editor References")]
    public Rigidbody playerRb; //Almacén del rigidbody del jugador para movimiento físico

    [Header("Movement Parameters")]
    public float speed = 10f; //Velocidad del personaje
    public Vector2 moveInput; //Almacén del valor de los botones de movimiento

    [Header("Jump Parameters")]
    public float jumpForce = 5; //Potencia de salto del personaje
    public bool isGrounded = true; //Define si el personaje puede saltar (estar en el suelo)

    [Header("Respawn System")]
    public float fallLimit = -10f; // limite en -y que elpersonaje calcula para respawnear
    public Transform respawnPoint; // ref a la prosicion de respawn


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //CinematicMovement();
        if (transform.position.y <= fallLimit)
        {
            Respawn();
        }
    }

    void FixedUpdate()
    {
        //Update para movimientos por física
        PhysicalMovement();
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // resetear la posibilidad de salto 

        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Respawn();
           

        }
        
    }

    void CinematicMovement()
    {
        //Recordar congelar los ejes de rotación del rigidbody
        //Time.deltaTime es una marca de tiempo que normaliza el movimiento cinemático
        transform.Translate(Vector3.right * speed * moveInput.x * Time.deltaTime);
        transform.Translate(Vector3.forward * speed * moveInput.y * Time.deltaTime);
    }

    void PhysicalMovement()
    {
        //Descongelar los ejes de rotación del rigidbody
        playerRb.AddForce(Vector3.right * speed * moveInput.x);
        playerRb.AddForce(Vector3.forward * speed * moveInput.y);
    }

    void Jump()
    {
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }


    void Respawn()
    {

        // sustituir la posicion del player por la posicion del punto respawn
        transform.position = respawnPoint.position;
        // resetear la energia del aceleracion del rigibody
        playerRb.linearVelocity = new Vector3(0,0,0);


    }
    #region Input Methods

    public void OnMove(InputAction.CallbackContext context)
    {
        //Atar el almacén del input al valor de los botones de la vida real
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded == true)
        {
            isGrounded = false;
            Jump();
        }
    }


    #endregion




}
