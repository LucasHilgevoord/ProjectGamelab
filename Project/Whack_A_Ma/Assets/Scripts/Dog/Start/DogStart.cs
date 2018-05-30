using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogStart : MonoBehaviour {

    public Animator anim;
    [SerializeField]
    private GameObject dog;
    private SpriteRenderer rend;
    private GameStart gameStart;
    [SerializeField]
    private GameObject GameStartObject;

    // Use this for initialization
    void Start() {
        anim = GetComponentInChildren<Animator>();
        rend = GetComponentInChildren<SpriteRenderer>();
        gameStart = GameStartObject.GetComponent<GameStart>();
    }

    // Update is called once per frame
    void Update() {

    }

    public void Walk() {
        anim.SetBool("isWalking", true);
        anim.SetBool("isSniffing", false);
    }

    public void Sniff() {
        anim.SetBool("isSniffing", true);
        anim.SetBool("isWalking", false);
    }

    public void Jump() {
        anim.SetBool("isJumping", true);
    }

    public void Fall() {
        rend.sortingOrder = 3;
        Destroy(gameObject, 2f);
        gameStart.gameStart = true;

    }
}
