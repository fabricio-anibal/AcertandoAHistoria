using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject lifeBar;

    public float life;
    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.collider.CompareTag("Floor"))
        {

            Debug.Log(collision.relativeVelocity.magnitude);

            float collisionDemage = collision.relativeVelocity.magnitude;

            float percentDamage = collisionDemage / life;

            life = Mathf.Clamp(life -= collisionDemage, 0, 500);

            

            //Debug.Log(lifeBar.transform.localScale.x);

            float newXScale = 0;

            newXScale = Mathf.Clamp(lifeBar.transform.localScale.x - (lifeBar.transform.localScale.x * percentDamage), 0, 1000);

            //Debug.Log(newXScale);

            lifeBar.transform.localScale = new Vector3(newXScale, lifeBar.transform.localScale.y, lifeBar.transform.localScale.z);

        }
    }

    void Start()
    {
        lifeBar.transform.position = new Vector3(transform.position.x, transform.position.y + 15, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
