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
		
		if(Input.GetButtonDown(“e”)) {
			health -= 1000;
		}
	}
	
	void LevelUp () {
		xp -= xpNeeded;
		pastXpNeeded = xpNeeded;
		xpNeeded = pastXpNeeded + level * 500;
	}
	
	void ReceiveXp (int receivedXp)  {
		xp += receivedXp;
	}
	
	void Dead () {
		Time.timeScale = 0;
	}
	
	void OnGUI () {
		if(GUI.Button(new Rect(Screen.width/2-Screen.width/6, Screen.height/2-Screen.height/6, Screen.width/3, Screen.height/3), "Restart")) {
			Time.timeScale = 1;
			Application.LoadLevel(Application.loadedLevel);
		}
		
		GUI.Label(new Rect(1, 1, 100, 100), health.ToString());
	}
}