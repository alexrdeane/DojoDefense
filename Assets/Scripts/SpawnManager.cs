using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    public float spawnTimer = 3f;
    public Transform spawnPoint;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Spawn", spawnTimer, spawnTimer);
    }
    void Spawn()
    {
       



        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
