using System.Collections;
using UnityEngine;
using Queue1;
using Queue2;
using Stack;

public class MainScript : MonoBehaviour
{
    //public Queue_4w<GameObject> bulletPool = new Queue_4w<GameObject>();
    public Stack<GameObject> bulletPool = new Stack<GameObject>();
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
            //GameObject bullet = bulletPool.Dequeue().value;
            GameObject bullet = bulletPool.Pop().value;
            bullet.transform.position = GreenBox.transform.position;
            bullet.SetActive(true);
        }
    }

    public void AddBullet(GameObject bullet)
    {
        //bulletPool.Enqueue(bullet);
        bulletPool.Push(bullet);
    }
}
