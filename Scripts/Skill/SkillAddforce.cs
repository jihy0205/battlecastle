using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAddforce : MonoBehaviour {

    public GameObject skilleffect;
    public GameObject skillPos;
    public float speed = 1000.0f;
	// Use this for initialization
	void Start () {
        skilleffect.GetComponent<Rigidbody>().AddForce(skillPos.transform.forward * speed);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
