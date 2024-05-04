using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int scaleX;
    public int scaleY;
    int[,] map;

    public GameObject wall1;
    public GameObject wall2;

    public Vector3 PlayerSpawnPoint;
    public Vector3 PlayerEndPoint;

    private void Awake()
    {
        //wall1 = Resources.Load<GameObject>("Assets/Midterm/Prefabs/WallMid.prefab");
        //wall2 = Resources.Load<GameObject>("Assets/Midterm/Prefabs/WallHigh.prefab");
    }

    public void MakeMap()
    {
        map = new int[scaleX, scaleY];

        StreamReader sr = new StreamReader("Assets/Midterm/MapInfo.csv");
        if (sr != null)
        {
            for (int i = 0; i < scaleY; i++)
            {
                string[] lineX = sr.ReadLine().Split(",");

                for (int j = 0; j < scaleX; j++)
                {
                    map[j,i] = int.Parse(lineX[j]);
                }
            }
        }

        for (int i = 0; i < scaleY; i++)
        {
            for (int j = 0; j < scaleX; j++)
            {
                float sizeX = gameObject.transform.localScale.x * (10f / scaleX);
                float sizeZ = gameObject.transform.localScale.z * (10f / scaleY);

                float posX = (-gameObject.transform.localScale.x / 2f * 10) + j * sizeX;
                float posZ = (-gameObject.transform.localScale.z / 2f * 10) + i * sizeZ;

                GameObject wall = null;
                if (map[j, i] == 1) wall = Instantiate(wall1);
                else if (map[j, i] == 2) wall = Instantiate(wall2);
                else if (map[j, i] == 3) PlayerSpawnPoint = new Vector3((posX + wall1.transform.localScale.x * 2.0f), 0, -(posZ + wall1.transform.localScale.z * 2.0f));
                else if (map[j, i] == 4) PlayerEndPoint = new Vector3((posX + wall1.transform.localScale.x * 2.0f), 0, -(posZ + wall1.transform.localScale.z * 2.0f));

                if (wall != null)
                {
                    wall.transform.localScale = new Vector3(sizeX, wall.transform.localScale.y, sizeZ);
                    wall.transform.position = new Vector3((posX + wall.transform.localScale.x / 2), wall.transform.position.y, -(posZ + wall.transform.localScale.z / 2));
                    wall.transform.parent = gameObject.transform;
                }
            }
        }
    }

    void Update()
    {
        
    }
}
