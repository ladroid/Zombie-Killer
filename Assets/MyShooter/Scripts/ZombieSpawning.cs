using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawning : MonoBehaviour
{
    public Transform plane;
    public GameObject zombie;
    float Timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        Timer = Time.time + 5;
    }

    // Update is called once per frame
    void Update()
    {
        if(Timer < Time.time)
        {
            Vector3 spawnZombie = new Vector3(plane.position.x, 3, plane.position.z);
            Instantiate(zombie, spawnZombie, Quaternion.identity);
            Timer = Time.time + 5;
        }
        
    }
}
