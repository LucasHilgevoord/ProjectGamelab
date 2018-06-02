using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{

    public static bool gameStart;
    [SerializeField]
    private CanvasGroup canvasGroup = null;
    [SerializeField]
    private GameObject startText;
    [SerializeField]
    private GameObject Timer;

    private Timer startTimer;
    private float fadeSpeed = 2f;
    private bool OpenStartText;

    void Start()
    {
        startTimer = Timer.GetComponent<Timer>();
        canvasGroup.alpha = 0;
        startText.SetActive(false);
    }

    void Update()
    {
        if (gameStart && !OpenStartText)
        {
            OpenStartText = true;
            StartGame();
        }
    }

    void StartGame()
    {
        startTimer.gameStart = true;
        StartCoroutine(OpenWindow());
        StartCoroutine(CloseWindow());
    }

    IEnumerator OpenWindow()
    {
        startText.SetActive(true);
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime * fadeSpeed;
            yield return null;
        }
    }

    IEnumerator CloseWindow()
    {
        yield return new WaitForSeconds(2f);
        while (canvasGroup.alpha > 0 && startText != null)
        {
            canvasGroup.alpha -= Time.deltaTime * fadeSpeed;
            yield return null;
        }
        if (canvasGroup.alpha == 0)
        {
            startText.SetActive(false);
        }
    }
}