using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheerUpEffect : MonoBehaviour {

    public int durabillity=100;
    public GameObject cheerUpEffect;
    public bool cheerupOn;
 //   public bool cheerupOff;

	// Use this for initialization
	void Start () {
        

		
	}
	
	// Update is called once per frame
	void Update () {

        if(cheerupOn == true)
        {
            cheerUpEffect.SetActive(true);

        }
        else if(cheerupOn == false)
        {
            cheerUpEffect.SetActive(false);
        }
		
	}
}
