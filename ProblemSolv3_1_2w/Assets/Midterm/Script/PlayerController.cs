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

        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(0, cameraAxis.transform.rotation.eulerAngles.y + 45f, 0);
            moveZ = 1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(0, cameraAxis.transform.rotation.eulerAngles.y + 45f + 180, 0);
            moveZ = 1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0, cameraAxis.transform.rotation.eulerAngles.y +135f + 180, 0);
            moveX = 1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, cameraAxis.transform.rotation.eulerAngles.y +135f, 0);
            moveX = 1f;
        }

        transform.Translate(Vector3.forward * moveZ * Time.deltaTime * moveSpeed);
        transform.Translate(Vector3.forward * moveX * Time.deltaTime * moveSpeed);
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
}
