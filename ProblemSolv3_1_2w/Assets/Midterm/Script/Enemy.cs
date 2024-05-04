using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject patrolRange;
    public GameObject Player;
    Camera cam;
    FrustumPlanes fp;
    bool isTracking;
    bool isPatrol;
    public Vector3 arrivePlace;

    private void Awake()
    {
        
    }

    void Start()
    {
        patrolRange = GameObject.Find("Range");

        cam = GetComponent<Camera>();
        cam.fieldOfView = 45.0f * (1920 / 1080);

        //ī�޶� �� �� ����(���) * ������ü �밢�� ���� * 3��
        cam.farClipPlane = (transform.localScale.x + transform.localScale.z) / 2 * Mathf.Pow(3, 0.5f) * 3f;

        MoveTo();
        isTracking = false;
        isPatrol = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Player == null) 
        {
            Player = FindObjectOfType<PlayerController>().gameObject;
        }

        fp = new FrustumPlanes(cam);

        //�÷��̾� �߰�
        if (fp.IsInsideFrustum(Player.transform.position))
        {
            isTracking = true;
            isPatrol = false;
            transform.LookAt(Player.transform.position);

            transform.Translate(Vector3.forward * 2f * Time.deltaTime);
        }
        //������ ��ħ
        else if (isTracking)
        {
            isTracking = false;
            StartCoroutine(FindAround());
        }
        //�������� �ƴϰ� ���ƴٴϴ� ��
        else if (!isTracking && isPatrol)
        {
            transform.LookAt(arrivePlace);

            //���������� �� ������ ����
            if (IsArrive())
            {
                MoveTo();
            }

            transform.Translate(Vector3.forward * 2f * Time.deltaTime);
        }
    }

    void MoveTo()
    {
        float x = Random.Range(patrolRange.transform.position.x - patrolRange.transform.localScale.x / 2, patrolRange.transform.position.x + patrolRange.transform.localScale.x / 2);
        float z = Random.Range(patrolRange.transform.position.z - patrolRange.transform.localScale.z / 2, patrolRange.transform.position.z + patrolRange.transform.localScale.z / 2);

        arrivePlace = new Vector3(x, transform.position.y, z);
    }

    bool IsArrive()
    {
        if (Vector3.Distance(arrivePlace, transform.position) < 1f) return true;

        return false;
    }

    IEnumerator FindAround()
    {
        float timer = 0;
        float angle = 30f * Time.deltaTime;

        while (timer < 3) 
        {
            transform.rotation *= Quaternion.AngleAxis(-angle, Vector3.up);
            timer += Time.deltaTime;
            yield return null;
        }
        while (timer < 6)
        {
            transform.rotation *= Quaternion.AngleAxis(2*angle,Vector3.up);
            timer += Time.deltaTime;
            yield return null;
        }

        if(!isTracking) isPatrol = true;
        yield return null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(patrolRange.transform.position, patrolRange.transform.localScale);
    }
}
