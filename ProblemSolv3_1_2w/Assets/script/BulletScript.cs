using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    MainScript Mscript;

    private void Start()
    {
        Mscript = FindObjectOfType<MainScript>();
    }

    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * 7f);

        Collider[] col = Physics.OverlapBox(transform.position, Vector3.right * 0.3f);
        foreach(Collider temp in col)
        {
            if(temp.gameObject.CompareTag("Target"))
            {
                HitEvent();
            }
        }
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            HitTarget();
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            HitEvent();
        }
    }

    void HitEvent()
    {
        Debug.Log("Hit!!");
        Mscript.AddBullet(this.gameObject);
        gameObject.SetActive(false);
    }
}
