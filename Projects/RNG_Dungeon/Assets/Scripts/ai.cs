using UnityEngine;
using System.Collections;
public class ai : MonoBehaviour {
	bool inrange = false;
	float speed = 1.0f;
	private Rigidbody br;

	void Start () {
		br = GetComponent<Rigidbody>();
	}

	void OnTriggerEnter(Collider player) {
		inrange = true;	
	}

	void OnTriggerExit(Collider player){
		inrange = false;
	}

	void FixedUpdate() {
		if (inrange == true) {
			Debug.Log("In Range");
			Vector3 target = GameObject.FindGameObjectWithTag("hero").transform.position;
			Vector3 current = GetComponent<Rigidbody>().position;
			Vector3 movement = target - current;
			br.AddForce(movement * speed);
		} else {
			Debug.Log("nope");
			br.velocity = new Vector3(0.0f,0.0f,0.0f);
		}
	}
}