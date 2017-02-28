using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerSkillCollision : MonoBehaviour {

    DealerSkillCtrl dealer;
    CheerUpEffect cheerupEffect;
    
    // Use this for initialization

    public GameObject SkillEffect;


    void Start()
    {
        dealer = GetComponent<DealerSkillCtrl>();
        cheerupEffect = GetComponent<CheerUpEffect>();
    }
    void OnCollisionEnter(Collision collision)
    {
  //      dealer = GetComponent<DealerSkillCtrl>();
        Debug.Log("Heal!");
        Debug.Log(collision.collider.gameObject);
        if (collision.collider.tag == "CheerUp")
        {
            Debug.Log("Heal!!");
            cheerupEffect.cheerupOn = true;
            dealer.hp += 10;
            dealer.BarStatus();
//            Instantiate(SkillEffect, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            // dealer.hp -= 10;
            Debug.Log(dealer.name);
          

        }
    }


    
	
	// Update is called once per frame
	void Update () {
		
	}
}
