using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {

    int zoom = 20;
    int normal = 60;
    float smooth = 5;
    private bool isZoomed;
    public float fieldOfView;
    public Camera mainCam;
    public string inputButton;

	// Use this for initialization
	void Start () {
        isZoomed = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonUp(inputButton))
        {
            isZoomed = !isZoomed;
        }
        if (isZoomed == true)
        {
            mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, zoom, Time.deltaTime * smooth);
        }
        else
        {
            mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, normal, Time.deltaTime * smooth);
        }

    }
}
