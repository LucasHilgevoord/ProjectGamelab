using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    [SerializeField]
    private float maxTime;
    private float timeLeft;
    [SerializeField]
    private Text timerText;
    public bool gameStart;

    // Use this for initialization
    void Start() {
        timeLeft = maxTime;
        timerText.text = "-=" + Mathf.RoundToInt(timeLeft) + "=-";
    }

    // Update is called once per frame
    void Update() {
        if (gameStart) {
            if (timeLeft > 9) {
                timerText.text = "-=" + Mathf.RoundToInt(timeLeft) + "=-";
                timeLeft -= Time.deltaTime;
                if (timeLeft < 0) {
                    Debug.Log("Tijd is op");
                }
            }
            if (timeLeft <= 9.5f && timeLeft >= 0) {
                timerText.text = "-=0" + Mathf.RoundToInt(timeLeft) + "=-";
                timeLeft -= Time.deltaTime;
                if (timeLeft < 0) {
                    Debug.Log("Tijd is op");
                }
            }
        }
    }
}
