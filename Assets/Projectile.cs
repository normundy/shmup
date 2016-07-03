﻿using UnityEngine;

public class Projectile : MonoBehaviour
{

    public int speed = 500;
	public int damage = 10;

    Rigidbody2D rbody;

    // Use this for initialization
    void Start()
    {
        rbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        rbody.velocity = this.transform.up * Time.deltaTime * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Health health = other.gameObject.GetComponent<Health>();

        // check whether the colliding object can be damaged
        if (health)
        {
            health.Damage(damage);
            Destroy(this.gameObject);
        }   
    }
}