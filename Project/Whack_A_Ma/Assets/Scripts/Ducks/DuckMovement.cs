using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DuckMovement : MonoBehaviour {

    /*
<<<<<<< HEAD
    [SerializeField] private GameObject area;
    private Vector3 center;
    private Vector3 size;
    private bool isFlying;
    [SerializeField] private float flyingSpeed = 0.01f;
    private Vector3 pos;


    // Use this for initialization
    void Start () {
        center = area.transform.position;
        size = new Vector3(area.transform.localScale.x, area.transform.localScale.y, area.transform.localScale.z);
        newPosition();

    }
	
	// Update is called once per frame
	void Update () {
        if (!isFlying) {
            newPosition();
            isFlying = true;
        } else {
            var targetRotation = Quaternion.LookRotation(pos - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1.8f * Time.deltaTime);
            //transform.LookAt(pos);

            transform.position = Vector3.MoveTowards(transform.position, pos, flyingSpeed);
        }

        if (Vector3.Distance(pos, transform.position) < 0.1){
            isFlying = false;
        }
            
    }

    void newPosition() {
        pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
    }


    void OnDrawGizmos() {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(area.transform.localPosition, size);
=======
*/
    [SerializeField]
    private GameObject area;
    [SerializeField]
    private float flyingSpeed = 0.01f;
    [SerializeField]
    private int pointValue;
    [SerializeField]
    private AudioClip quackAudio;
    private GameObject gameManager;

    private AudioSource audioSource;
    private Vector3 center;
    private Vector3 size;
    private Vector3 pos;

    private bool isFlying;
    private bool isAlive;

    private Animator anim;
    private Rigidbody2D rb;
    private Vector3 oldPos;
    private SpriteRenderer rend;
    private ScoreManager points;
    


    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        gameManager = GameObject.Find("GameManager");
        points = gameManager.GetComponent<ScoreManager>();

        isAlive = true;

        center = area.transform.position;
        size = new Vector3(area.transform.localScale.x, area.transform.localScale.y, area.transform.localScale.z);
        newPosition();
    }

    // Update is called once per frame
    void Update() {
        if (isAlive) {
            if (!isFlying) {
                newPosition();
                isFlying = true;
            } else {
                if (pos.x > oldPos.x) {
                    rend.flipX = false;
                    transform.right = pos - transform.position;
                } else {
                    rend.flipX = true;
                    transform.right = -pos - -transform.position;
                }
                transform.position = Vector3.MoveTowards(transform.position, pos, flyingSpeed);
            }

            if (Vector3.Distance(pos, transform.position) < 0.1) {
                isFlying = false;
            }
        }
    }

    void newPosition() {
        pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), 0);
        oldPos = transform.position;
    }

    //Testing
    void OnMouseDown() {
        if (isAlive) {
            isAlive = false;
            transform.right = new Vector3(0, 0, 0);
            audioSource.PlayOneShot(quackAudio);
            anim.SetBool("isHit", true);
            rb.gravityScale = 1;
            points.player1 += pointValue;
            anim.SetBool("isFalling", true);
            Destroy(gameObject, 2f);
        }
// >>>>>>> origin
    }
}
