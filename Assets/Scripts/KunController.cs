using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunController : MonoBehaviour
{
    public Rigidbody2D rb;

    public float releaseTime = 0f;

    private bool isPressed = false;

    private void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;
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
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseTime);

        GetComponent<SpringJoint2D>().enabled = false;

        rb.velocity *= 2;
    }
}
