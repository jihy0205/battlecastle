using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Anim
{
	public AnimationClip idle;
	public AnimationClip runForward;
	public AnimationClip runBackward;
	public AnimationClip runLeft;
	public AnimationClip runRight;
	public AnimationClip Attack1;
	public AnimationClip Attack2;
	public AnimationClip Attack3;
	public AnimationClip Attack4;
	public AnimationClip Attack5;
	public AnimationClip Hit;
	public AnimationClip Death;
}
public class DealerCtrl : MonoBehaviour {

	public delegate void PlayerDieHandler ();
	public static event PlayerDieHandler OnPlayerDie;

	private Animator animator;
	private float h = 0.0f;
	private float v = 0.0f;
	private bool isdead = false;
	private bool attack1 = false;
	private bool attack2 = false;
	private bool attack3 = false;
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

		if (!isdead && !attack1) {
			Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);

			tr.Translate (moveDir * moveSpeed * Time.deltaTime, Space.Self);

			// 회전
			if (Input.GetMouseButton (1)) {
				tr.Rotate (Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeed);
			}

			if (v >= 0.1f && v*v>h*h) {
				_animation.CrossFade (anim.runForward.name, 0.3f);
				Debug.Log ("moving");
			} else if (v <= -0.1f && v*v>h*h) {
				_animation.CrossFade (anim.runBackward.name, 0.3f);
			} else if (h >= 0.1f && v*v<h*h) {
				_animation.CrossFade (anim.runRight.name, 0.3f);
			} else if (h <= -0.1f&& v*v<h*h) {
				_animation.CrossFade (anim.runLeft.name, 0.3f);
			} else {
				_animation.CrossFade (anim.idle.name, 0.3f);
			}

			if (Input.GetKeyDown (KeyCode.Alpha1)) {
				StartCoroutine (this.Attack1());
			}

			if (Input.GetKeyDown (KeyCode.Alpha2))
				StartCoroutine (this.Attack2());

			if (Input.GetKeyDown (KeyCode.Alpha3))
				StartCoroutine (this.Attack3());
		}
	}

	void OnTriggerEnter(Collider coll)
	{
		Debug.Log ("Player HP = " + hp.ToString ());
		if (coll.gameObject.tag == "Enemy") {
			hp -= 10;
			Debug.Log ("Player HP = " + hp.ToString ());

			if (hp <= 0) {
				hp = 0;
				PlayerDie ();
			}
		}

	}

	IEnumerator Attack1()
	{
		if (!attack1) {
			Debug.Log ("Attack1");
			attack1 = true;
			_animation.CrossFade (anim.Attack1.name, 0.3f);
			yield return new WaitForSeconds (0.8f);
		}
		attack1 = false;
	}

	IEnumerator Attack2()
	{
		Debug.Log ("Attack2");

		yield return null;
	}

	IEnumerator Attack3()
	{
		Debug.Log ("Attack3");

		yield return null;
	}

	void PlayerDie()
	{
		isdead = true;
		_animation.CrossFade (anim.Death.name, 0.3f);
		OnPlayerDie ();
		Debug.Log ("Player Die!");
	}
}