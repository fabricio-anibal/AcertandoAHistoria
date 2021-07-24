using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunController : MonoBehaviour
{
    Rigidbody2D rb;

    SpringJoint2D sj;

    public GameObject hook;

    public float releaseTime = 0f;

    private bool isPressed = false;

    private bool released = false;

    private void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        sj = GetComponent<SpringJoint2D>();
    }

    private void OnMouseUp()
    {
        isPressed = false;
        rb.isKinematic = false;

        StartCoroutine(Release());
    }

    private void Update()
    {
        if(isPressed)
        {
            rb.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if(rb.velocity.magnitude == 0 && released)
        {
            //Debug.Log(rb.velocity.magnitude);

            sj.enabled = true;

            transform.position = hook.transform.position;
        }
        
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseTime);

        sj.enabled = false;

        rb.velocity *= 2;

        released = true;
    }

    public void ResetLaunch()
    {
        //new WaitForSeconds(1);

        transform.position = sj.gameObject.transform.position;

        sj.enabled = true;
    }
}
