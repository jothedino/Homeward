// This script creates a shared sound Manager for playing sounds. Uses Unity 5.2+

using UnityEngine;
using System.Collections;

// Add AudioSource component if it is missing
[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{

    // Variables in this space can be used anywhere in this script.
    // Private variables can be used only in this script.
    // AudioSource type refers to the Audio Source component.
    private AudioSource audioSource;

    // Multiple variables of the same type can be declared on the same line, separated by commas.
    // Public variables can be used outside of this script and are shown in the component's Inspector pane.
    // AudioClip type is used to hold audio files for playback with the Audio Source component.
    public AudioClip playerMovingClip, playerJumpClip, playerShootClip, playerDamageClip, enemyDamageClip, healthPickupClip, keyPickupClip;

    private bool isMoving;

    // Use this for initialization
    void Start()
    {
        // Find the AudioSource component attached to this gameobject and store reference to it in audioSource variable.
        audioSource = GetComponent<AudioSource>();
        // Make sure Audio Source is set to loop for the player move script.
        audioSource.loop = true;
    }

    // Public methods can be used outside of this script.

    // Player sounds

    public void PlayerMoving()
    {
        // Use the AudioSource method PlayOneShot() to play a short AudioClip.
        //audioSource.PlayOneShot(playerMovingClip);
        if (isMoving == false)
        {
            isMoving = true;
            audioSource.clip = playerMovingClip;
            audioSource.Play();
        }
    }

    public void PlayerIdle()
    {
        isMoving = false;
        audioSource.Stop();
    }

    public void PlayerJump()
    {
        audioSource.PlayOneShot(playerJumpClip);
    }

    public void PlayerShoot()
    {
        audioSource.PlayOneShot(playerShootClip);
    }

    public void PlayerDamage()
    {
        audioSource.PlayOneShot(playerDamageClip);
    }

    // Enemy sounds

    public void EnemyDamage()
    {
        audioSource.PlayOneShot(enemyDamageClip);
    }

    // Collectibles sounds

    public void HealthPickup()
    {
        audioSource.PlayOneShot(healthPickupClip);
    }

    public void KeyPickup()
    {
        audioSource.PlayOneShot(keyPickupClip);
    }
}
