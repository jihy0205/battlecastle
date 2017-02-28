using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNavCtrl : MonoBehaviour {

    public enum EnemyState {idle, trace, attack, die, magic};
    public EnemyState enemyState = EnemyState.idle;

    public Transform enemyTr;
    public Transform playerTr;

    private UnityEngine.AI.NavMeshAgent nvAgent;
    public Animator animator;
    private bool isDie = false;

    public float traceDist = 10.0f;
    public float attackDist = 2.0f;
    public float magicDist = 4.5f;

	// Use this for initialization
	void Start () {
        enemyTr = this.gameObject.GetComponent<Transform>();
        playerTr = GameObject.FindWithTag("Dealer").GetComponent<Transform>();
        nvAgent = this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();

        StartCoroutine(this.CheckEnemyState());
        StartCoroutine(this.EnemyAction());
	}

    IEnumerator CheckEnemyState()
    {
        while(!isDie)
        {
            yield return new WaitForSeconds(0.2f);

            float dist = Vector3.Distance(playerTr.position, enemyTr.position);
            if(dist<=attackDist)
            {
                enemyState = EnemyState.attack;
            }
            else if(dist<=traceDist)
            {
                enemyState = EnemyState.trace;
            }
           
            else
            {
                enemyState = EnemyState.idle;
            }

        }

    }
    IEnumerator EnemyAction()
    {
        while(!isDie)
        {
            switch(enemyState)
            {

                case EnemyState.idle:
                    nvAgent.Stop();
                    break;

                case EnemyState.trace:
                    nvAgent.destination = playerTr.position;
                    nvAgent.Resume();
       //             animator.SetBool("Punch", false);
                    animator.SetBool("Moving", true);
                    break;

                case EnemyState.attack:
                    nvAgent.Stop();
                    
                    animator.SetBool("Punch", true);
                    break;
            }
            yield return null;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
