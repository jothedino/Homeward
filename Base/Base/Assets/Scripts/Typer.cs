// Attach this to UI Text
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Text))]
public class Typer : MonoBehaviour
{
    // Original code from here: https://gist.github.com/DarkDesire/fac180105122348fb1ab

    // To do: Add sound
    [Tooltip ("Arrays of text to display.")]
    public string[] msg;

    [Tooltip ("Delay before showing text.")]
    public float startDelay = .5f;

    [Tooltip("Rate of typewriter effect.")]
    public float typeDelay = 0.01f;

    [Tooltip("Loop the conversation. Otherwise, stay at last message until reset.")]
    public bool loop;

    [Tooltip("The sound to play when displaying characters.")]
    public AudioClip typeSound;

    private AudioSource audioSource;

    // This is the text component.
    private Text dialogueText;

    // Has the typing finished?
    public bool ready = true;

    // Current message in array
    private int current;

    public bool finished;

    void Start()
    {
        dialogueText = GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();
    }

    // Type the message text
    public void Talk()
    {
        gameObject.SetActive(true);
        ready = false;
        StartCoroutine(TypeIn());
    }

    // Reset message
    public void Reset()
    {
        // Clear text.
        dialogueText.text = "";
        ready = true;
        finished = false;
        current = 0;
        gameObject.SetActive(false);
    }

    // Display text like a typewriter
    public IEnumerator TypeIn()
    {
        
        // Clear text first.
        dialogueText.text = "";

        // Wait for a brief period before typing.
        yield return new WaitForSeconds(startDelay);

        // Go through each character in a message, and display one-by-one.
        for (int i = 0; i < msg[current].Length; i++)
        {
            dialogueText.text = msg[current].Substring(0, i + 1);
            audioSource.PlayOneShot(typeSound);
            yield return new WaitForSeconds(typeDelay);
        }

        // Iterate through the msg array.
        if (current < msg.Length - 1)
        {
            current++;
        }
        else
        {
            finished = true;
            // Loop messages, if desired.
            if (loop)
                current = 0;
        }

        // Signal that it's time for a new message.
        ready = true;
    }
}
