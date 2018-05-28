using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthIndicator : MonoBehaviour
{
    private Animator anim;

    // 1. On hold, let a value count up.
    // 2. Indicate the bar to fill up.
    // 3. On release, reset.

    private float countIndicator = 0f;
    private float countingSpeed = 1f;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update ()
    {
        Debug.Log(countIndicator);
        Timer();
	}

    void Timer()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            countIndicator += countingSpeed * Time.deltaTime;
            anim.SetBool("Indicator", true);
        }
        else
        {
            countIndicator = 0f;
            anim.SetBool("Indicator", false);
        }
    }
}
