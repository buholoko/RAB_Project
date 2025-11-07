using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [Header("Clips de sonido")]
    public AudioClip jumpSound;
    public AudioClip collisionSound;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    
    public void PlayJumpSound()
    {
        if (jumpSound != null)
            audioSource.PlayOneShot(jumpSound);
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collisionSound != null)
            audioSource.PlayOneShot(collisionSound);
    }
}
