using UnityEngine;
using System.Collections;

public class ai2 : MonoBehaviour {
	NavMeshAgent agent;
	// Use this for initialization
	void Start () {
		//inits the agent
		agent = GetComponent<NavMeshAgent> ();
	}
	void Update () {
		// sets the player as the target.
		agent.SetDestination(GameObject.FindGameObjectWithTag("hero").transform.position);
	}
}
