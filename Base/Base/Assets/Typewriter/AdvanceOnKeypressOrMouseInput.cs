using UnityEngine;
using System.Collections;

// Attach this to the GameObject that has your Typewriter script
public class AdvanceOnKeypressOrMouseInput : MonoBehaviour {

    public string inputButton;

	void Update () {
		if(Input.GetButtonUp(inputButton)) {
			GetComponent<Typewriter>().Advance();
		}
	}
}
