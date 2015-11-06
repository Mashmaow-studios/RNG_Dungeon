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

	private NavMeshAgent navAgent;
	private Animator animator;
	private Transform player;
	private Projector projector;
	private bool justActivated = true;
	private int maxHealth;

	internal bool enraged = false;

	void Start () {
		navAgent = GetComponent<NavMeshAgent>();
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

	public void Movement (Vector3 targetPosition) {
		navAgent.SetDestination(targetPosition);
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
