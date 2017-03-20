using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameraman : MonoBehaviour {

	public Transform Target;
	public bool smoothMove;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (smoothMove)
			transform.position += (Target.position - transform.position) / 16;
		else
			transform.position = Target.position;
	}
}
