using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour {

    public bool gameStart;
    [SerializeField]
    private CanvasGroup canvasGroup = null;
    [SerializeField]
    private GameObject startText;
    [SerializeField]
    private GameObject Ducks;
    [SerializeField]
    private GameObject Timer;

    private Timer startTimer;
    private float fadeSpeed = 2f;
    
    void Start() {
        startTimer = Timer.GetComponent<Timer>();
        Ducks.SetActive(false);
        canvasGroup.alpha = 0;
        startText.SetActive(false);
    }

    void Update() {
        if (gameStart) {
            StartGame();
        }
    }

    void StartGame() {
        startTimer.gameStart = true;
        StartCoroutine(OpenWindow());
        StartCoroutine(CloseWindow());
        Ducks.SetActive(true);
    }

    IEnumerator OpenWindow() {
        startText.SetActive(true);
        while (canvasGroup.alpha < 1) {
            canvasGroup.alpha += Time.deltaTime * fadeSpeed;
            yield return null;
        }
    }

    IEnumerator CloseWindow() {
        yield return new WaitForSeconds(2f);
        while (canvasGroup.alpha > 0) {
            canvasGroup.alpha -= Time.deltaTime * fadeSpeed;
            yield return null;
        }
        if (canvasGroup.alpha == 0) {
            startText.SetActive(false);
            gameStart = false;
        }
    }
}
