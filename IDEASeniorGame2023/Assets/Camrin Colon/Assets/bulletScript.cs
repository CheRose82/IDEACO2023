using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{

    public float bulletSpeed;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Invoke("destroyBullet", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * bulletSpeed * Time.deltaTime;
    }
    public void destroyBullet()
    {
        Destroy(this.gameObject);
    }
}
