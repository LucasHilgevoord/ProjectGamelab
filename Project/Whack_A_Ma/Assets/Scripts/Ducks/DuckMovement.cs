using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DuckMovement : MonoBehaviour {

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
    }
}
