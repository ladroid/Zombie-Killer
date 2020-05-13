using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawning : MonoBehaviour
{
    public Transform target;
    public GameObject zombie;
    float Timer;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        Timer = Time.time + 2;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = target.transform.position;
        Vector3 playerDirection = target.transform.forward;
        Quaternion playerRotation = target.transform.rotation;
        float spawnDistance = 10f;

        Vector3 spawning = playerPos + playerDirection * spawnDistance;
        if(Timer < Time.time)
        {
            Debug.Log("RANDOM RANGE -> " + spawning.x + " " + spawning.y + " " + spawning.z);
            Instantiate(zombie, spawning, playerRotation);
            Timer = Time.time + 2;
        }
    }
}
