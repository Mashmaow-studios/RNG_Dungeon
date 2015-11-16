using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Weapon : MonoBehaviour {
	
	public Transform theSystem;
	public int damage = 1000;
	public float length = 20;
	public LayerMask colliderMask;

	private Animator animator;
	private AnimatorTransitionInfo armsTransitionInfo;
	private bool attacking = false;

	void Start () {
		animator = gameObject.GetComponentInParent<Animator>();
	}

	void Update () {
		armsTransitionInfo = animator.GetAnimatorTransitionInfo(0);

		if(Input.GetMouseButton(0)) {
			Attack();
		}

		if(armsTransitionInfo.nameHash == Animator.StringToHash("Swing -> idle")) {
			attacking = false;
		}

		if(attacking)
			HitCheck();
	}

	void Attack () {
		animator.SetInteger("AttackAnimation", Random.Range(0, 2));
		animator.SetTrigger("Attack");
		attacking = true;
	}

	void HitCheck () {
		Ray ray = new Ray(theSystem.position, theSystem.up);
		RaycastHit hit;
		
		if(Physics.Raycast(ray, out hit, length, colliderMask)) {
			if(hit.distance < length) {
				if(hit.transform.tag == "Enemy")
					hit.transform.SendMessage("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);
			}
		}
	}
}