using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [Header("Camera Switch")]
    [SerializeField]
    private GameObject sky;
    [SerializeField]
    private GameObject webcamPlane;
    private bool camSwitch;

    [SerializeField]
    private Texture2D CursorNormal;


    void Update() {
        if (Input.GetKeyDown(KeyCode.Keypad0))
            SwitchCamera();
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
        if (Input.GetKeyDown("r"))
            Application.LoadLevel(Application.loadedLevel);

        Cursor.SetCursor(this.CursorNormal, Vector2.zero, CursorMode.Auto);
    }

    void SwitchCamera() {
        if (!camSwitch) {
            sky.SetActive(false);
            webcamPlane.SetActive(true);
            camSwitch = true;
        } else {
            sky.SetActive(true);
            webcamPlane.SetActive(false);
            camSwitch = false;
        }
    }
}
