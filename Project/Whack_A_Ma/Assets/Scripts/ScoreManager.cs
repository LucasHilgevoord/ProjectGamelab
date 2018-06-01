using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    [SerializeField]
    private Text ScoreText1;
    [SerializeField]
    private Text ScoreText2;
    private int startingScore = 0;
    public int player1;
    public int player2;

    // Use this for initialization
    void Start() {
        ScoreText1.text = startingScore.ToString();
        ScoreText2.text = "0000" + startingScore;
    }

    // Update is called once per frame
    void Update() {
        if (player1 <= 9) {
            ScoreText1.text = "0000" + player1;
        } else if (player1 <= 99) {
            ScoreText1.text = "000" + player1;
        } else if (player1 <= 999) {
            ScoreText1.text = "00" + player1;
        } else if (player1 <= 999) {
            ScoreText1.text = "00" + player1;
        } else if (player1 <= 9999) {
            ScoreText1.text = "0" + player1;
        } else if (player1 <= 99999) {
            ScoreText1.text = player1.ToString();
        }







    }
}
