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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            Debug.Log("Hit!!");
            Mscript.AddBullet(this.gameObject);
            gameObject.SetActive(false);
        }
    }
}
