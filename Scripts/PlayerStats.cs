using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {
	
	private int level = 1, xp, xpNeeded;
	private int health = 10000, mana = 1000;

	void Start () {
		xpNeeded = (level * 400) + 1000;
	}

	void Update () {
		if(health <= 0)
			Dead();


		if(xp >= xpNeeded)
			LevelUp();
	}

	void LevelUp () {
		xp -= xpNeeded;
		xpNeeded = (level * 400) + 1000;
	}

	void Dead () {

	}
}
