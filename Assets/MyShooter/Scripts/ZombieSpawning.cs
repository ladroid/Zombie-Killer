using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawning : MonoBehaviour
{
    public Transform target;
    public GameObject zombie;
    float Timer;

    //static int numZombies = 10;
    //static GameObject[] zombies;

    // Start is called before the first frame update
    void Start()
    {
        //zombies = new GameObject[numZombies];
        //for (int i = 0; i < numZombies; i++)
        //{
        //    zombies[i] = (GameObject)Instantiate(zombie, Vector3.zero, Quaternion.identity);
        //    zombies[i].SetActive(false);
        //}
    }

    private void Awake()
    {
        Timer = Time.time + 2;
    }

    //static public GameObject getZombie()
    //{
    //    for (int i = 0; i < numZombies; i++)
    //    {
    //        if (!zombies[i].activeSelf)
    //        {
    //            return zombies[i];
    //        }
    //    }
    //    return null;
    //}

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Vector3.zero;

        pos.x = Random.Range(-target.transform.position.x / 2, target.transform.position.x / 2);
        pos.z = Random.Range(-target.transform.position.z / 2, target.transform.position.z / 2);
        //pos.y = pos.x > pos.z ? Random.Range(0, pos.z) : Random.Range(0, pos.x);
        pos.y = 3;
        if (Timer < Time.time)
        {
            Debug.Log("TRANSFORM -> " + target.transform.position.x + " " + target.transform.position.z);
            Debug.Log("RANDOM RANGE -> " + pos.x + " " + pos.y + " " + pos.z);
            Vector3 spawnZombie = pos;
            Instantiate(zombie, spawnZombie, Quaternion.identity);
            Timer = Time.time + 2;
        }

    }
}
