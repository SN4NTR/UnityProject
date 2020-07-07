using UnityEngine;

public class FootstepsController : MonoBehaviour
{
    private AudioSource audioSource;
    private CharacterController characterController;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsGrounded())
        {
            return;
        }
        audioSource.volume = Random.Range(0.8f, 1);
        audioSource.pitch = Random.Range(0.8f, 1.1f);
        audioSource.Play();
    }

    private bool IsGrounded()
    {
        return characterController.velocity.magnitude > 2f &&
            !audioSource.isPlaying;
    }
}
