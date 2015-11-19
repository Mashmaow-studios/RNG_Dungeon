using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour {

	public float speed = 6.0f, jumpHeight = 8.0f, turnSpeed = 10.0f, gravity = 20.0f;
	public float mouseTurnMultiplayer = 1.0f;

	[HideInInspector]
	public bool canMove = true;

	private Vector3 moveDirection = Vector3.zero;
	private Animator animator;

	void Start () {
		animator = gameObject.GetComponent<Animator>();
	}

	void Update () {
		CharacterController controller = GetComponent<CharacterController>();

		if(Input.GetAxis("Vertical") != 0) {
			animator.SetFloat("Speed", 1.0f);
		} else {
			animator.SetFloat("Speed", 0.0f);
		}

		if(canMove && controller.isGrounded) {
			moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;

			if(Input.GetButton("Jump")) {
				moveDirection.y = jumpHeight;
			}
		}

		moveDirection.y -= gravity * Time.deltaTime;

		controller.Move(moveDirection * Time.deltaTime);
	}
}
