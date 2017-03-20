using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealerSkillCtrl : MonoBehaviour {

	public int hp;
	public int sp;

	private int initHp;
	private int initSp;

	public GameObject[] skill = new GameObject[5];
	public Transform skillPos;
	public int damage = 20;

	public float speed = 1000.0f;

	public bool attack;

	public Animation _animation;
	public Anim SkillAnim;
	// Use this for initialization
	void Start () {
		initHp = hp;
		initSp = sp;
		_animation = GetComponentInChildren<Animation> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			_animation.CrossFade (SkillAnim.Attack1.name, 0.3f);
			Debug.Log ("Skill 1");
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			_animation.CrossFade (SkillAnim.Attack2.name, 0.3f);
			Debug.Log ("Skill 2");
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			_animation.CrossFade (SkillAnim.Attack3.name, 0.3f);
			Debug.Log ("Skill 3");
		}
		if (Input.GetKeyDown (KeyCode.Alpha4)) {
			_animation.CrossFade (SkillAnim.Attack4.name, 0.3f);
			Debug.Log ("Skill 4");
		}
		if (Input.GetKeyDown (KeyCode.Alpha5)) {
			_animation.CrossFade (SkillAnim.Attack5.name, 0.3f);
			Debug.Log ("Skill 5");
		}
	}

	void FireBall() {
		
	}

	void Meteor() {
	
	}
}
