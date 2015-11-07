using UnityEngine;
using System.Collections;

public class ai2 : MonoBehaviour {
	NavMeshAgent agent;
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		agent.SetDestination(GameObject.FindGameObjectWithTag("hero").transform.position);
	}
}
