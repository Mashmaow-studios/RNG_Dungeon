using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyController : Item {

	[System.Serializable]
	public class DropLoot {
		//The items the enemy can drop set by item id aka the position of the item in the item list -1
		public int[] commonDrops, uncommonDrops, rareDrops, epicDrops, legendaryDrop, godlikeDrops;
	}

	public int health = 1000, range = 2;
	public int lvl = 1;
	public bool aggressiv = false;
	public DropLoot dropLoot;

// Awesome Dynamic AI movement peramiters
  public float agroRange = 10000f;
	public float agroBuffer = 2000f;
	public float speed = 2f;

	private Animator animator;
	private Transform player;
	private Projector projector;
	private bool justActivated = true;
	private int maxHealth;

	internal bool enraged = false;

	void Start () {
		animator = GetComponent<Animator>();
		player = GameObject.FindWithTag("Player").transform;
		projector = GetComponentInChildren<Projector>();
		maxHealth = health;
	}


	void Update () {
		if(aggressiv)
			analizePlayerData();

		if(health < maxHealth)
			enraged = true;

		if(health <= 0)
			Dead();

		if(Input.GetMouseButtonDown(0))
			Target(0);
	}

	void OnMouseDown () {
		Target(1);
	}

	//Checks if the target gets selected or not
	void Target (int clicked) {
		if(clicked == 1) {
			projector.enabled = true;
			justActivated = true;
		} else if(clicked == 0 && !justActivated) {
			projector.enabled = false;
		} else if(clicked == 0 && justActivated) {
			justActivated = false;
		}
	}

	void analizePlayerData () {
		float distance;

		//Checks the distance between player and this object
		distance = Vector3.Distance(transform.position, player.position);

		if(distance > 50 && enraged) {
			animatorManager("Speed", 1, 0, false);
			Movement(transform.position);
			enraged = false;
		}

		if(distance < 20 && distance > range && !enraged){
			enraged = true;
		}

		if(enraged) {
			if(animator.GetFloat("Speed") != 1)
				animatorManager("Speed", 1, 1, false);

			Movement(player.position);
		}

		if(distance <= range){
			Movement(transform.position);

			animatorManager("Attack", 2, 0, true);
		}
		else
		{
			animatorManager("Attack", 2, 0, false);
		}

	}
   // Where the magic happens
  public void FixedUpdate() {
		// Getting current position for player and Mr.badguy.
		Vector3 playerPos = player;
		Vector3 enemyPos = GetComponent<Rigidbody>().position;
		// Getting a Vector length for Mr.badguy to move to.
		float xMov = playerPos.x - enemyPos.x;
		float zMov = playerPos.z - enemyPos.z;
		Vector3 movement = new Vector3(xMov,0f,zMov);
		// If Player is in range and not TOO close, move to player (No navmesh, we want it Dynamic!)
		if (Vector3.Distance(playerPos,enemyPos) < agroRange & Vector3.Distance(playerPos,enemyPos) > agroBuffer )
		{
			GetComponent<Rigidbody>().velocity = movement * speed;
		}
    else
		{
			// If at destination, slow down.
			GetComponent<Rigidbody>().AddForce(-GetComponent<Rigidbody>().velocity);
		}
	}

	void animatorManager (string animation, int type, int value, bool boolValue) {
		if(type == 1)
			animator.SetFloat(animation, value);

		if(type == 2)
			animator.SetBool(animation, boolValue);
	}

	void Dead () {
		int lootDrop = 0;
		int dropAmount = 0;

		dropAmount = Random.Range(0, 4);

		for(int i = 0; i < dropAmount; i++) {
		lootDrop = Random.Range(0, 10001);

			if(lootDrop <= 5 && dropLoot.godlikeDrops.Length > 0) {

			}
			else if(lootDrop <= 50 && dropLoot.legendaryDrop.Length > 0) {

			}
			else if(lootDrop <= 250 && dropLoot.epicDrops.Length > 0) {

			}
			else if(lootDrop <= 1000 && dropLoot.rareDrops.Length > 0) {

			}
			else if(lootDrop <= 3000 && dropLoot.uncommonDrops.Length > 0) {

			}
			else {

			}
		}

		Destroy(gameObject);
	}
}
