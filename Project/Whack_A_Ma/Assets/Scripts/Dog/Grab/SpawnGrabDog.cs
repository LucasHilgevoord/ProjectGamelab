using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGrabDog : MonoBehaviour {

    [SerializeField]
    private GameObject holdDog;
    private Vector3 tmpPoint;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Bird")
        {
            if (!other.GetComponent<DuckMovement>().isAlive && GameObject.Find("HoldDog(Clone)") == null) {
                tmpPoint = other.transform.position;
                GameObject dog = (GameObject)Instantiate(holdDog, new Vector3(tmpPoint.x, -2.6f,0), Quaternion.identity);
                Destroy(dog, 1.5f);
                Debug.Log(tmpPoint);
                Debug.Log(dog.transform.position);
            }
        }
    }
}
