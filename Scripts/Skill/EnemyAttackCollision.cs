using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackCollision : MonoBehaviour {

    CheerUpEffect cheerup;
    DealerSkillCtrl dealer;
    
    // Use this for initialization
    void Start () {
        cheerup = GetComponent<CheerUpEffect>();
        dealer = GetComponent<DealerSkillCtrl>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Enemy")
        {
            Debug.Log("EnemyCollision");
            if(cheerup.cheerupOn==true)
            {
                cheerup.durabillity -= 20;
                Debug.Log("-----------");
                Debug.Log(cheerup.durabillity);
                if(cheerup.durabillity <= 0)
                {
                    
                    cheerup.cheerupOn = false;
                    cheerup.durabillity = 100;
                }
            }
            else if(cheerup.cheerupOn == false)
            {
                Debug.Log("dealer.hp");
                Debug.Log(dealer.hp);
                dealer.hp -= 10;
                dealer.BarStatus(); 
                
            }


        }
    }
}
