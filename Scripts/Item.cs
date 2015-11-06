using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Item : MonoBehaviour {

	[System.Serializable]
	public class ItemStats {
		public string name, description;
		public Texture2D icon;
		public Transform model;
		public Rarity rarity;
		public ItemType itemType;
		public Weapon weaponStats;
		public Armor armorStats;
		public int value, price;
		public bool stackable;

		internal int stack;

		public enum Rarity {
			Common,
			Uncommon,
			Rare,
			Mythical,
			Legendary,
			Godlike
		}

		public enum ItemType {
			Weapon,
			Armor,
			Consumables,
			Etc
		}
	}

	[System.Serializable]
	public class Weapon {
		public int damage;
		public int requriedLevel;
	}

	[System.Serializable]
	public class Armor {
		public int defence;
		public int requriedLevel;
	}

	[System.Serializable]
	public class Consumables {
		public int heal;
		public int manaRestore;
	}
}
