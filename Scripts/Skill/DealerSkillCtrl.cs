using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DealerSkillCtrl : MonoBehaviour {

    public int hp;
    public int sp;

    private int initHp;
    private int initSp;

    public Image imgHpbar;
    public Image imgSpbar;

    public GameObject[] skill = new GameObject[5];
    public Transform skillPos;
    public int damage = 20;

    public Animator anim;
    public float speed = 1000.0f;

    public bool attack;
    public HpPosion hpPosion;
    public SpPosion spPosion;

	// Use this for initialization
	void Start () {

        initHp = hp;
        initSp = sp;

        hpPosion = GetComponent<HpPosion>();
        spPosion = GetComponent<SpPosion>();


    //    GetComponent<Rigidbody>().AddForce(transform.forward * speed);
		
	}
	
	// Update is called once per frame
	void Update () {
        // if(Input.GetAxis("Horizontal"))
        if(Input.GetButtonUp("Horizontal"))
        {
            anim.SetBool("Run", true);
            anim.SetBool("Swing", false);
            anim.SetBool("Cut", false);
            attack = false;
        }
        if(Input.GetButtonUp("Vertical"))
        {
            anim.SetBool("Run", true);
            anim.SetBool("Swing", false);
            anim.SetBool("Cut", false);
            attack = false;
        }
        if(Input.GetButtonUp("FireBall")) //4
        {
            anim.SetBool("Magic", true);
            anim.SetBool("Cut", false);
            anim.SetBool("Run", false);
            anim.SetBool("Swing", false);
            //        Debug.Log(Input.GetButtonUp("FireBall"));
            Fireball(4);
        }
        if(Input.GetButtonUp("Swing")) //button 1
        {
            anim.SetBool("Cut", false);
            anim.SetBool("Run", false);
            anim.SetBool("Swing", true);
            anim.SetBool("Magic", false);
            attack = true;
           
           
        }
        if(Input.GetButtonUp("Cut")) //button 2
        {
            anim.SetBool("Swing", false);
            anim.SetBool("Run", false);
            anim.SetBool("Cut", true);

            anim.SetBool("Magic", false);
            attack = true;
           
        }
        if(Input.GetButtonUp("Meteor"))
        {
            Meteor(5);

        }
        if(Input.GetButtonUp("HpPosion"))
        {
            Debug.Log("HPPOSION!!");
            HpPosion();
        }
        if(Input.GetButtonUp("SpPosion"))
        {
            Debug.Log("SPPOSION!");
            SpPosion();
        }
		
	}
    void SpPosion()
    {
        if(spPosion.SpTotalScore>=0)
        {
            spPosion.EatPosion();
            hp += 10;
            imgSpbar.fillAmount = (float)sp / (float)initSp;
            spPosion.SpTotalScore -= 1;
        }
        
    }
    void HpPosion()
    {
        Debug.Log(hpPosion.HpTotalScore);
        if (hpPosion.HpTotalScore >= 0)
        {
            hpPosion.EatPosion();
            hp += 10;
            imgHpbar.fillAmount = (float)hp / (float)initHp;
            hpPosion.HpTotalScore -= 1;
        }

    }
    void Meteor(int buttonNumber)
    {
        Rigidbody skillRb = Instantiate(skill[buttonNumber - 1], skillPos.position, skillPos.rotation).GetComponent<Rigidbody>();
        sp -= 10;
        imgSpbar.fillAmount = (float)sp / (float)initSp;
        skillRb.AddForce(skillPos.transform.forward * speed);
    }
    void Fireball(int buttonNumber)
    {
        Rigidbody skillRb = Instantiate(skill[buttonNumber - 1], skillPos.position, skillPos.rotation).GetComponent<Rigidbody>();
        sp -= 10;
        imgSpbar.fillAmount = (float)sp / (float)initSp;
        //     Debug.Log(imgHpbar.fillAmount);
        //      Instantiate(skill[buttonNumber-1], skillPos.position, skillPos.rotation);
        //     skill[buttonNumber - 1].GetComponent<Rigidbody>().AddForce(skillPos.transform.forward * speed);
        skillRb.AddForce(skillPos.transform.forward * speed);
    }
    public void BarStatus()
    {
        imgHpbar.fillAmount = (float)hp / (float)initHp;
        imgSpbar.fillAmount = (float)sp / (float)initSp;
    }
    
}
