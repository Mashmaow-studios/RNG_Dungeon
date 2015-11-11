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

	[System.Serializable]
	public class DropLoot {
		//The items the enemy can drop set by item id aka the position of the item in the item list -1
		public int[] commonDrops, uncommonDrops, rareDrops, epicDrops, legendaryDrop, godlikeDrops;
	}

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

	void ApplyDamage (int receiveDamage) {
		health -= receiveDamage - (armor * 10);
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
		
		Destroy (gameObject);
	}	
}
