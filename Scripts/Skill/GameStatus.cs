using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour {

    public Text HpPosionNumberText;
    public Text SpPosionNumberText;

    public int HpTotalScore = 0;
    public int SpTotalScore = 0;

    public int HpPosionNumber;
    public int SpPosionNumber;
 //   HpTotalScore += HpPosionNumber;
  //      SpTotalScore += SpPosionNumber;
	// Use this for initialization
	void Start () {
        Totalstatus();

    }
	
	// Update is called once per frame
	void Update () {

        

        
	}
    void Totalstatus()
    {
        HpTotalScore += HpPosionNumber;
        SpTotalScore += SpPosionNumber;
    }
}
