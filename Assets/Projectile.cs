﻿using UnityEngine;

public class Projectile : MonoBehaviour
{

	public int speed = 500;
	public int damage = 1;

	Rigidbody2D rbody;
	Team team;

	// Use this for initialization
	void Start ()
	{
		rbody = gameObject.GetComponent<Rigidbody2D> ();
		team = gameObject.GetComponent<Team> ();
	}

	// Update is called once per frame
	void Update ()
	{

	}

	void FixedUpdate ()
	{
		rbody.velocity = this.transform.right * Time.deltaTime * speed;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		Health health = other.gameObject.GetComponent<Health> ();
		Team otherTeam = other.GetComponent<Team> ();

		// check whether the colliding object can be damaged and can not harm objects that are on the same team
		if (health && health.enabled && team && this.team.IsEnemy (otherTeam))
		{
			health.Damage (damage);
			Destroy (this.gameObject);
		}
	}
}
