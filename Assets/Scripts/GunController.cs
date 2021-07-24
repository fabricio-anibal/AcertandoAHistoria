using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    Rigidbody2D rb;

    SpringJoint2D sj;

    public GameObject hook;

    public float releaseTime;

    private bool isPressed = false;

    private bool released = false;

    LineRenderer lineRenderer;

    private void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;

        Vector3 directtionRay = transform.position - hook.transform.position;

        //Debug.Log(directtionRay);

        lineRenderer.enabled = true;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        sj = GetComponent<SpringJoint2D>();

        lineRenderer = gameObject.GetComponent<LineRenderer>();
    }

    private void OnMouseUp()
    {
        isPressed = false;
        rb.isKinematic = false;

        StartCoroutine(Release());

        lineRenderer.enabled = false;
    }

    private void Update()
    {
        if(isPressed)
        {
            rb.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, hook.transform.position);
            lineRenderer.startWidth = lineRenderer.endWidth = 0.5f;
            
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
        Vector3 vectorDirecao = hook.transform.position - transform.position;

        //vectorDirecao.Normalize();

        Debug.Log(vectorDirecao);

        sj.enabled = false;

        rb.velocity = vectorDirecao * 4;

        rb.angularVelocity = 200;

        yield return new WaitForSeconds(releaseTime);

        released = true;
    }

    public void ResetLaunch()
    {
        //new WaitForSeconds(1);

        transform.position = sj.gameObject.transform.position;

        sj.enabled = true;
    }
}
