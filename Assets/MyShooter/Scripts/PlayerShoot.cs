using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerShoot : MonoBehaviour
{
    public GameObject revolver;
    public GameObject bulletPrefab;
    public float speed = 1000f;
    public float fireRate = 2f;
    private float nextFire = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject instBullet = Instantiate(bulletPrefab, revolver.transform.position, revolver.transform.rotation);
            instBullet.transform.Rotate(new Vector3(0, 90, 90));
            instBullet.GetComponent<Rigidbody>().AddForce(revolver.transform.right * speed);
            Debug.Log("Fire!");
        }
    }
}
