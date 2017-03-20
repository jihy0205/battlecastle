using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterCtrl : MonoBehaviour {
	public enum MonsterState {idle, trace, attack, die};
	public MonsterState monsterState = MonsterState.idle;

	private Transform monsterTr;
	private Transform playerTr;
	private NavMeshAgent nvAgent;
	private Animator animator;

	public float traceDist = 10.0f;
	public float attackDist = 2.0f;
	private bool isDie = false;

	public GameObject bloodEffect;
	public GameObject bloodDecal;

	// Use this for initialization
	void Start () {
		monsterTr = this.gameObject.GetComponent<Transform> ();
		playerTr = GameObject.FindWithTag ("Player").GetComponent<Transform> ();
		nvAgent = this.gameObject.GetComponent<NavMeshAgent> ();
		animator = this.gameObject.GetComponent<Animator>();

		//nvAgent.destination = playerTr.position;
		StartCoroutine(this.CheckMonsterState());
		StartCoroutine (this.MonsterAction());

	}

	IEnumerator CheckMonsterState()
	{
		while (!isDie) {
			yield return new WaitForSeconds (0.2f);
			float dist = Vector3.Distance (playerTr.position, monsterTr.position);

			if (dist <= attackDist)
				monsterState = MonsterState.attack;
			else if (dist <= traceDist)
				monsterState = MonsterState.trace;
			else
				monsterState = MonsterState.idle;
		}
	}

	IEnumerator MonsterAction()
	{
		while (!isDie) {
			switch (monsterState) {

			case MonsterState.idle:
				animator.SetBool ("IsTrace", false);
				nvAgent.Stop ();
				break;

			case MonsterState.trace:
				nvAgent.destination = playerTr.position;
				nvAgent.Resume ();
				animator.SetBool ("IsAttack", false);
				animator.SetBool ("IsTrace", true);
				break;

			case MonsterState.attack:
				animator.SetBool ("IsAttack", true);
				break;
			}
			yield return null;
		}
	}

	void OnTriggerEnter(Collision coll)
	{
		Debug.Log ("Collision!");
		if (coll.gameObject.tag == "Player") {
			animator.SetTrigger ("IsAttack");
		}
	}
	// Update is called once per frame
	void Update () {
		
	}

	void OnPlayerDie()
	{
		StopAllCoroutines ();
		nvAgent.Stop ();
		animator.SetTrigger ("IsPlayerDie");
	}

	void OnEnable()
	{
		DealerCtrl.OnPlayerDie += this.OnPlayerDie;
	}

	void OnDisable()
	{
		DealerCtrl.OnPlayerDie -= this.OnPlayerDie;
	}
}
