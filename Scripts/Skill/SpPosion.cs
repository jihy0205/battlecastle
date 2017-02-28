using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpPosion : MonoBehaviour
{

    public GameStatus gamestatus;
    public Text DisplayHpPosionNumber;

    public int SpTotalScore;

    // HpTotalScore += HpPosionNumber;
    //    SpTotalScore += SpPosionNumber;


    // Use this for initialization
    void Start()
    {
        gamestatus = GetComponent<GameStatus>();

    }

    // Update is called once per frame
    void Update()
    {
        //    DispScore(gamestatus.HpTotalScore);

    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "SpPosion")
        {
            Debug.Log("SPPOSION!!!");
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
        SpTotalScore += 1;
        //  DispScore(gamestatus.HpTotalScore);

        //         DisplayHpPosionNumber.text = gamestatus.HpTotalScore.ToString();
        DisplayHpPosionNumber.text = SpTotalScore.ToString();
        //      collision.gameObject.SetActive(false);

    }
    public void EatPosion()
    {
        //    HpTotalScore -= 1;
        DisplayHpPosionNumber.text = SpTotalScore.ToString();
    }
}
