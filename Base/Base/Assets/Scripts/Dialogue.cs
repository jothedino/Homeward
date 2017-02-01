using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    // Button for interaction
    public string actionButton;

    public string talkTag;

    // Set to your UI text for NPC. Must have Typer component.
    public Typer talkText;

    // Icon to show that lets player know it is ready to talk
    public Image talkBackground, talkIcon;
    
    // Boolean which signals that player is in range with this NPC
    private bool canTalk;


    void Update()
    {
        talkText.transform.position = new Vector3(transform.position.x, talkText.transform.position.y, talkText.transform.position.z);
        talkBackground.transform.position = new Vector3(transform.position.x, talkBackground.transform.position.y, talkBackground.transform.position.z);
        //talkIcon.transform.position = new Vector3(transform.position.x, talkIcon.transform.position.y, talkIcon.transform.position.z);

        // Continue the dialogue if the text is ready and there is still more to display.
        if (Input.GetButtonDown(actionButton) && talkText.ready && !talkText.finished && canTalk)
        {
            // SetActive is used to enable or disable a GameObject.
            // Hide Icon when talking. 
            //talkIcon.gameObject.SetActive(false);
            talkBackground.gameObject.SetActive(true);
            // Start/continue dialogue
            talkText.Talk();
        }

        
    }

    // Start talking when you walk up
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == talkTag)
        {
            talkIcon.gameObject.SetActive(true);
            canTalk = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == talkTag)
        {
            //talkIcon.gameObject.SetActive(false);
            talkBackground.gameObject.SetActive(false);
            talkText.Reset();
            canTalk = false;
        }
    }
}
