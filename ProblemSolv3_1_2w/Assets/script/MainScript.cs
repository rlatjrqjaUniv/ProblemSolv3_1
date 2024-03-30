using System.Collections;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    //public Queue<GameObject> bulletPool = new Queue<GameObject>();
    public StackWithQueue<GameObject> bulletPool = new StackWithQueue<GameObject>();

    public GameObject bulletPrefab;
    public GameObject GreenBox;
    public GameObject RedBox;

    void Start()
    {
        for(int i=0;i<10; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);

            bulletPool.Push(bullet);
            //bulletPool.Enqueue(bullet);
        }
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //GameObject bullet = bulletPool.Dequeue();
            //GameObject bullet = bulletPool.Pop();

            GameObject bullet = bulletPool.Pop();

            bullet.transform.position = GreenBox.transform.position;
            bullet.SetActive(true);
        }
    }

    public void AddBullet(GameObject bullet)
    {
        //bulletPool.Enqueue(bullet);
        bulletPool.Push(bullet);
        //bulletQueue1.Enqueue(bullet);
    }
}
