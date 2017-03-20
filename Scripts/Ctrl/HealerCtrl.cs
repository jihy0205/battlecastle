using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealerCtrl : MonoBehaviour {

	private float h = 0.0f;
	private float v = 0.0f;
	public int hp = 100;

	Vector3 MouseGap;
	private Transform tr;
	public float moveSpeed = 10.0f;
	public float rotationSpeed = 100.0f;

	public Anim anim;
	public Animation _animation;

	// Use this for initialization
	void Start () {
		tr = GetComponent<Transform> ();
		_animation = GetComponentInChildren<Animation> ();
		_animation.clip = anim.idle;
		_animation.Play ();
	}

	// Update is called once per frame
	void Update () {
		h = Input.GetAxis ("Horizontal");
		v = Input.GetAxis ("Vertical");

		int trRotationValue = 0;

		Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);

		tr.Translate (moveDir * moveSpeed * Time.deltaTime, Space.Self);

		// 회전
		if (Input.GetMouseButton (1)) {
			tr.Rotate (Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeed);
		}

		if (v >= 0.1f) {
			_animation.CrossFade (anim.runForward.name, 0.3f);
			Debug.Log ("moving");
		} else if (v <= -0.1f) {
			_animation.CrossFade (anim.runBackward.name, 0.3f);
		} else if (h >= 0.1f) {
			_animation.CrossFade (anim.runRight.name, 0.3f);
		} else if (h <= -0.1f) {
			_animation.CrossFade (anim.runLeft.name, 0.3f);
		} else {
			_animation.CrossFade (anim.idle.name, 0.3f);
		}


	}

	void OnTriggerEnter(Collider coll)
	{
		Debug.Log ("Player HP = " + hp.ToString ());
		if (coll.gameObject.tag == "Enemy") {
			hp -= 10;
			Debug.Log ("Player HP = " + hp.ToString ());

			if (hp <= 0)
				PlayerDie ();
		}

	}

	void PlayerDie()
	{
		_animation.Play (anim.Death.name);
		Debug.Log ("Player Die!");
	}
}