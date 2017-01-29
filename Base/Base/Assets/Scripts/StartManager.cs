using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    // This string is set in the Inspector and is used to set which scene to switch to after the level is cleared.
    public string nextScene;

    public float startDelay = .5f;

    // This method 
    public void StartGame()
    {
        // 0 indicates fresh start. No bool in playerprefs
        PlayerPrefs.SetInt("Reset", 0);

        // StartCoroutine is used to call a IEnumerator coroutine.
        StartCoroutine(WaitThenStart());
    }

    // This method changes scenes when the level is cleared.
    public void ContinueGame()
    {

        // 1 indicates continue. No bool in playerprefs
        PlayerPrefs.SetInt("Reset", 1);
        // StartCoroutine is used to call a IEnumerator coroutine.
        StartCoroutine(WaitThenContinue());
    }

    // This switches to the next level. Set nextScene in the inspector and add to Build settings.
    IEnumerator WaitThenStart()
    {
        // Wait for a number of seconds.
        yield return new WaitForSeconds(startDelay);

        // PlayerPrefs can be used to save simple data like int, float, or string.


        // Load the desired scene.
        SceneManager.LoadScene(nextScene);
    }

    IEnumerator WaitThenContinue()
    {
        // Wait for a number of seconds.
        yield return new WaitForSeconds(startDelay);

        // PlayerPrefs can be used to save simple data like int, float, or string.


        // Load the desired scene.
        SceneManager.LoadScene(PlayerPrefs.GetString("CurrentLevel"));
    }
}
