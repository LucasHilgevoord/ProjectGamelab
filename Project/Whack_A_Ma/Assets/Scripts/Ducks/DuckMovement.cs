using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DuckMovement : MonoBehaviour {

    [SerializeField] private GameObject area;
    [SerializeField] private float flyingSpeed = 0.01f;
    private Vector3 center;
    private Vector3 size;
    private Vector3 pos;
    private bool isFlying;
    private bool isAlive;
    private Animator anim;
    private Rigidbody2D rb;


    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
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
                transform.right = pos - transform.position;
                transform.position = Vector3.MoveTowards(transform.position, pos, flyingSpeed);
            }

            if (Vector3.Distance(pos, transform.position) < 0.1) {
                isFlying = false;
            }
        }
    }
   
    void newPosition() {
        pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), 0);
    }

    //Testing
    void OnMouseDown() {
        isAlive = false;
        transform.right = new Vector3(0, 0, 0);
        anim.SetBool("isHit", true);
        Destroy(gameObject, 2f);
        Debug.Log("hit");
        rb.gravityScale = 1;
        anim.SetBool("isFalling", true);
    }
}
