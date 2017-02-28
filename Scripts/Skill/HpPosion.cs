using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpPosion : MonoBehaviour {

    public GameStatus gamestatus;
    public Text DisplayHpPosionNumber;

    public int HpTotalScore;

   // HpTotalScore += HpPosionNumber;
    //    SpTotalScore += SpPosionNumber;
    
   
	// Use this for initialization
	void Start () {
        gamestatus = GetComponent<GameStatus>();
		
	}
	
	// Update is called once per frame
	void Update () {
    //    DispScore(gamestatus.HpTotalScore);
		
	}
    void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Posion")
        {
            DispScore();
            /*       //        gamestatus.HpPosionNumber += 1;
                   //        HpTotalScore += gamestatus.HpPosionNumber;
                   HpTotalScore += 1;
                   //  DispScore(gamestatus.HpTotalScore);

                   //         DisplayHpPosionNumber.text = gamestatus.HpTotalScore.ToString();
                   DisplayHpPosionNumber.text = HpTotalScore.ToString();*/
            collision.gameObject.SetActive(false);

        }

    }
    public void DispScore()
    {
        //  DisplayHpPosionNumber.text = totalscore.ToString();
        //        gamestatus.HpPosionNumber += 1;
        //        HpTotalScore += gamestatus.HpPosionNumber;
        HpTotalScore += 1;
        //  DispScore(gamestatus.HpTotalScore);

        //         DisplayHpPosionNumber.text = gamestatus.HpTotalScore.ToString();
        DisplayHpPosionNumber.text = HpTotalScore.ToString();
  //      collision.gameObject.SetActive(false);

    }
    public void EatPosion()
    {
    //    HpTotalScore -= 1;
        DisplayHpPosionNumber.text = HpTotalScore.ToString();
    }
}
