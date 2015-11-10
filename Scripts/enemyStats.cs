using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class enemyStats : MonoBehaviour {

	public string name;
	public int health;
	public int attackSpeed;
	public int level;
	public int damage;
	public int armor;
	public EnemyType enemyType;
	private int caveLevel;

	public enum EnemyType {
		MeleePhysical,
		MeleeMagical,
		RangedPhysical,
		RangedMagical
	}
		
	void Start () {

	}

	void Update () {
		if (health <= 0) {
			Dead();
		} 
	}

	void Level () {
		level = Random.Range (caveLevel - 2, caveLevel + 1);
		if (level < 1) {
			level = 1;
		}
	}

	function ApplyDamage (int receiveDamage) {
		health -= receiveDamage - (armor * 10)
	}

	void Dead () {
		Destroy(gameObject);
	}
}
