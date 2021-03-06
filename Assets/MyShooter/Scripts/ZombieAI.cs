﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAI : MonoBehaviour
{
    public Transform target;
    public Transform zombie;

    float moveSpeed = 3f;
    float rotationSpeed = 3f;
    float range = 10f;
    float range2 = 10f;
    float closestRange = 5f;
    float stop = 0;

    Animator zombieAnim;

    void Awake()
    {
        zombie = transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        zombieAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(zombie.position, target.position);

        if (distance <= range2 && distance >= range)
        {
            Debug.Log("looking...");
            zombieAnim.SetBool("run", false);
            zombieAnim.SetBool("walk", true);
            zombieAnim.SetBool("attack", false);

            zombie.rotation = Quaternion.Slerp(zombie.rotation, Quaternion.LookRotation(target.position - zombie.position),
                                               rotationSpeed * Time.deltaTime);
        }
        else if(distance <= range && distance > stop)
        {
            //Debug.Log("find target!");
            zombieAnim.SetBool("run", true);
            //zombieAnim.SetBool("attack", true);
            zombieAnim.SetBool("walk", false);
            zombieAnim.SetBool("attack", false);

            zombie.rotation = Quaternion.Slerp(zombie.rotation, Quaternion.LookRotation(target.position - zombie.position),
                                               rotationSpeed * Time.deltaTime);
            zombie.position += zombie.forward * moveSpeed * Time.deltaTime;
            
        }

        //TODO:MAKE ATTACK
        //else if (distance <= (range / 2))
        //{
        //    Debug.Log("attack!");
        //    zombieAnim.SetBool("attack", true);
        //    zombieAnim.SetBool("walk", false);
        //    zombieAnim.SetBool("walk", false);

        //}

        else if(distance <= stop)
        {
            Debug.Log("idle...");
            zombieAnim.SetBool("walk", true);
            zombieAnim.SetBool("run", false);
            zombieAnim.SetBool("attack", false);
            zombie.rotation = Quaternion.Slerp(zombie.rotation, Quaternion.LookRotation(target.position - zombie.position),
                                               rotationSpeed * Time.deltaTime);
        }
        DestroyZombie();
    }

    void DestroyZombie()
    {
        if(zombie.position.y < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
