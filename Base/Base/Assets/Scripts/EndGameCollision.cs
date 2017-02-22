using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameCollision : MonoBehaviour {

    public string inputName;
    public string NextScene;

    void OnTriggerEnter(Collider hit)
    {
        if(hit.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(NextScene);
        }
    }

}
