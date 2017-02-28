using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour {

    DealerSkillCtrl dealerobj;
    public int EnemyHp;
    public int AbsorbHp;
  //  GameObject playerObj; 
	// Use this for initialization
	void Start () {
        dealerobj = GameObject.Find("DealerPlayer").GetComponent<DealerSkillCtrl>();
    }
	
	// Update is called once per frame
	void Update () {
        if(EnemyHp<0)
        {
            Debug.Log(EnemyHp);
            Destroy(this.gameObject);
        }
		
	}

    void OnTriggerEnter(Collider coll)
    {


        if (coll.tag == "Longsword" && dealerobj.attack == true)
        {
            EnemyHp -= 10;
            //            Debug.Log("LongSwrod");

        }
        else if (coll.tag == "FireBall")
        {
            EnemyHp -= 10;
            //     Debug.Log("fire");
        }
        else if (coll.tag == "HpAbsorb")
        {
            dealerobj.hp += 10;
            dealerobj.BarStatus();
            EnemyHp -= 10;
            Debug.Log("HpAbsorb");
            dealerobj.hp += AbsorbHp;
        }
        else if (coll.tag == "Stone") 
        {
            EnemyHp -= 200;
            Debug.Log("Stone!");
        }

    }
}
