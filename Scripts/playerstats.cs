using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {
	
	private int level = 1, xp, xpNeeded, pastXpNeeded = 1000;
	private int health = 10000, mana = 1000;

	void Start () {
		xpNeeded = pastXpNeeded + level * 500;
	}

	void Update () {
		if(health <= 0)
			Dead();


		if(xp >= xpNeeded)
			LevelUp();
	}

	void LevelUp () {
		xp -= xpNeeded;
		xpNeeded = pastXpNeeded + level * 500;
	}

	void Dead () {

	}
}
