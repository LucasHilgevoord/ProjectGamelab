using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    [SerializeField]
    private Text ScorePlayer1;
    [SerializeField]
    private Text ScorePlayer2;
    private int startingScore = 00010;

    // Use this for initialization
    void Start () {
        ScorePlayer1.text = startingScore.ToString();
        ScorePlayer2.text = startingScore.ToString();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
