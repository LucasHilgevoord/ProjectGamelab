using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    RaycastCheck raycastCheck;
    RaycastHit2D hit;

    private Animator anim;
    private AudioSource aS;

    public Transform mHandMesh;

    void Start()
    {
        raycastCheck = GetComponent<RaycastCheck>();
        anim = GetComponent<Animator>();
        aS = GetComponent<AudioSource>();
    }

    void Update()
    {
        mHandMesh.position = Vector3.Lerp(mHandMesh.position, transform.position, Time.deltaTime * 15.0f);
        Shoot();
    }

    void Shoot()
    {
        hit = raycastCheck.hit;

        if (raycastCheck.RaycastChecker() == "ShootAble")
        {
            Debug.Log("SHOT!!");
            StartCoroutine(OnShoot());
        }
    }

    private Vector3 screenPoint;
    private Vector3 offset;

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        transform.position = cursorPosition;
    }

    IEnumerator OnShoot()
    {
        float timer = 0f;
        float timeMultiplier = 1f;
        float duration = .5f;

        while (raycastCheck.RaycastChecker() == "ShootAble")
        {
            if (timer <= duration)
            {
                //Debug.Log(timer);
                anim.SetBool("Indicator", true);
                timer += timeMultiplier * Time.deltaTime;
            }
            else
            {
                aS.Play();
                anim.SetBool("Indicator", false);
                Destroy(hit.collider.gameObject);
            }
            yield return null;
        }

        if (raycastCheck.RaycastChecker() != "ShootAble")
        {
            anim.SetBool("Indicator", false);
        }
    }
}
