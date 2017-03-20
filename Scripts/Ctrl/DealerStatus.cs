using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DealerState
{
	Idle = 0,
	AttackRun = 1,
	Attack1 = 2,
	Attack2 = 3,
	Attack3 = 4,
	Attack4 = 5,
	Attack5 = 6,
	Hit = 7,
	Dead = 8
}
public class DealerStatus : MonoBehaviour {

	public int hp = 100;
	private int initHp;
	public int sp = 100;
	private int initSp; 

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
