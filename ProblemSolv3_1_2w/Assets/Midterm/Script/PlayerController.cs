using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed=3f;
    public GameObject cameraAxis;
    bool isRotating=false;

    void Start()
    {
        cameraAxis = GameObject.Find("Axis");
    }

    void Update()
    {
        float moveX = 0;
        float moveZ = 0;

        if (Input.GetKeyDown(KeyCode.O) && !isRotating)
        {
            StartCoroutine(RotateCamera(90f));
        }
        if (Input.GetKeyDown(KeyCode.P) && !isRotating)
        {
            StartCoroutine(RotateCamera(-90f));
        }

        moveX = Mathf.Abs(Input.GetAxis("Horizontal"));
        moveZ = Mathf.Abs(Input.GetAxis("Vertical"));

        GetRotation();

        transform.Translate(Vector3.forward * Mathf.Clamp01(moveX+moveZ) * Time.deltaTime * moveSpeed);
    }

    IEnumerator RotateCamera(float angle)
    {
        isRotating = true;
        Quaternion startRotation = cameraAxis.transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(0, startRotation.eulerAngles.y + angle, 0);
        float elapsedTime = 0f;

        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime * 1f;
            cameraAxis.transform.rotation = Quaternion.Slerp(startRotation, targetRotation, elapsedTime);
            yield return null;
        }

        cameraAxis.transform.rotation = targetRotation;
        isRotating = false;
    }

    void GetRotation()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(0, cameraAxis.transform.rotation.eulerAngles.y + 45f, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(0, cameraAxis.transform.rotation.eulerAngles.y + 45f + 180, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0, cameraAxis.transform.rotation.eulerAngles.y + 45f + 270, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, cameraAxis.transform.rotation.eulerAngles.y + 45 + 90, 0);
        }

        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(0, cameraAxis.transform.rotation.eulerAngles.y + 90f, 0);
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(0, cameraAxis.transform.rotation.eulerAngles.y, 0);
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(0, cameraAxis.transform.rotation.eulerAngles.y + 180, 0);
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(0, cameraAxis.transform.rotation.eulerAngles.y -90, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            Debug.Log("target");
            
        }

        if (collision.gameObject.CompareTag("Respawn"))
        {
            Debug.Log("respawn");
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            Debug.Log("finish");
            GameManager.instance.Clear();
        }
    }
}
