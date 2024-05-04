using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject ground;
    MapGenerator mapGen;

    public GameObject Spawn;
    public GameObject Goal;

    public GameObject Player;

    public GameObject FinishUI;

    private void Awake()
    {
        if(instance == null) instance = this;
        else Destroy(instance);
    }

    void Start()
    {
        mapGen = ground.GetComponent<MapGenerator>();
        mapGen.MakeMap();

        Spawn.transform.position = mapGen.PlayerSpawnPoint;
        Goal.transform.position = mapGen.PlayerEndPoint;

        Instantiate(Player, Spawn.transform.position+Vector3.up, Quaternion.identity);
    }

    void Update()
    {
        
    }

    internal void Clear()
    {
        FinishUI.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
