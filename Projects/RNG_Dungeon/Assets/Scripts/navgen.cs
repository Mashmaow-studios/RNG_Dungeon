using UnityEngine;
using UnityEditor;
using System.Collections;

public class navgen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		NavMeshBuilder.BuildNavMesh ();
	}
}	
