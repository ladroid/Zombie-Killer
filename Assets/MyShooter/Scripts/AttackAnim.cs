using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnim : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetMouseButtonDown(0))
       {
            Debug.Log("attack true");
            anim.SetBool("attack", true);
            anim.Play("Axe_Anim");
       }
       else if(Input.GetMouseButtonUp(0))
       {
            Debug.Log("atack false");
            anim.SetBool("attack", false);
       }
    }
}
