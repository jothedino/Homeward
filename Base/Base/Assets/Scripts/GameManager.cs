using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    //keeping track of score
    public int score;
    public Text ScoreText;

	// Use this for initialization
	void Start () {
        score = 0;

	
	}
    //updates score only when theres a change
    public void Score(int points)
    {
        score += points;
        ScoreText.text = "Score: " + score.ToString("000");
    }
}
