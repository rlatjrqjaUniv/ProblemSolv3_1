using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    public Queue<GameObject> bulletPool = new Queue<GameObject>();
    public GameObject bulletPrefab;
    public GameObject GreenBox;
    public GameObject RedBox;

    void Start()
    {
        for(int i=0;i<10; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletPool.Enqueue(bullet);
        }
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject bullet = bulletPool.Dequeue().value;
            bullet.transform.position = GreenBox.transform.position;
            bullet.SetActive(true);
        }
    }

    public void AddBullet(GameObject bullet)
    {
        bulletPool.Enqueue(bullet);
    }
}
