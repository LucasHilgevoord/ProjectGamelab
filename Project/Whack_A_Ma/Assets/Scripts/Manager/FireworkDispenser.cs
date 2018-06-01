using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworkDispenser : MonoBehaviour {

    [SerializeField]
    private GameObject redFirework;
    [SerializeField]
    private int thrust;
    private bool hasShot;
    private AudioSource audiosrc;
    [SerializeField]
    private AudioClip launch;

	// Use this for initialization
	void Start () {
        audiosrc = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasShot) {
            hasShot = true;
            StartCoroutine(shootFirework());
        }
	}

    IEnumerator shootFirework() {
        yield return new WaitForSeconds(Random.Range(1f, 2f));
        
        GameObject firework = Instantiate(redFirework, transform);
        firework.GetComponent<Rigidbody2D>().AddForce(transform.up * thrust);
        audiosrc.PlayOneShot(launch);
        Destroy(firework, 1.8f);
        hasShot = false;
    }
}
