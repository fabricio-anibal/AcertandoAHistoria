using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{
    Rigidbody2D rb;

    SpringJoint2D sj;

    public GameObject hook;

    private bool isPressed = false;

    private bool released = false;

    private Vector3 vectorDirecao;

    LineRenderer lineRenderer;

    public Canvas ForceBar;

    public ForcebarController forcebarController;

    public KillerController killerController;

    public Button resetButton;

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

        forcebarController.maxForce(100);

        resetButton.onClick.AddListener(ResetLaunch);

    }

    private void OnMouseUp()
    {
        isPressed = false;
        rb.isKinematic = false;

        Release();

        lineRenderer.enabled = false;
    }

    private void Update()
    {

        //if(isp)


        if(isPressed)
        {
            VetorDirecao();

            var distancia = hook.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);

            float magnetude = distancia.magnitude;

            //Debug.Log(magnetude);

            if (magnetude <= 20)
            {
                rb.simulated = true;

                rb.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            else
            {
                //Debug.Log(magnetude);

                rb.simulated = false;
            }



            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, hook.transform.position);
            lineRenderer.startWidth = lineRenderer.endWidth = 0.5f;

            
        }

       


        if (rb.velocity.magnitude == 0 && released)
        {
            //Debug.Log(rb.velocity.magnitude);

            ResetLaunch();
        }

        

    }

    void VetorDirecao()
    {
        vectorDirecao = hook.transform.position - transform.position;

        Debug.Log(vectorDirecao.magnitude+3);



        forcebarController.force(Mathf.Clamp( (int)(vectorDirecao.magnitude + 3) * (100/20), 0, 100));
    }

    void Release()
    {
        rb.simulated = true;

        killerController.UpdateAnimation(1);

        vectorDirecao = hook.transform.position - transform.position;

        //vectorDirecao.Normalize();

        ForceBar.enabled = false;

        //Debug.Log(vectorDirecao);

        sj.enabled = false;

        rb.velocity = vectorDirecao * (forcebarController.slider.value)/10;

        rb.angularVelocity = 200;

        

        released = true;
    }

    public void ResetLaunch()
    {
        //new WaitForSeconds(1);

        killerController.UpdateAnimation(0);

        ForceBar.enabled = true;

        sj.enabled = true;

        transform.position = hook.transform.position;

        rb.velocity = Vector3.zero;

        rb.angularVelocity = 5;
    }
}
