using UnityEngine;
using System.Collections;

[RequireComponent (typeof (CharacterController))]
public class NewWorldAI : MonoBehaviour {

	//Variables
	public float range, moveSpeed;

	private Transform target;
	private Vector3 moveDirection = Vector3.zero;
	private CharacterController controller; 
	private bool escape = false;

	//Functions
	void Start() {
		target = GameObject.FindWithTag("Player").transform;
		controller = gameObject.GetComponent <CharacterController>();
	}

	void Update() {
		Movement();
	}

	void Movement() {
		float distance;
		
		distance = Vector3.Distance(transform.position, target.position);

		if(distance <= range) {
			moveDirection = transform.forward;
			moveDirection *= moveSpeed;

			moveDirection.y -= gravity * Time.deltaTime;
			controller.Move (moveDirection * Time.deltaTime);
		}

		if(escape) {

		}
	}

	void Escape(bool flee) {
		if(flee)
			escape = true;
		else 
			escape = false;
	} 
}