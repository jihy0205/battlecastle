using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealerSkillCtrl : MonoBehaviour
{

    public int hp = 100;
    public int sp = 500;

    private int initHp;
    private int initSp;

    public Image imgHpbar;
    public Image imgSpbar;

    public GameObject[] skill = new GameObject[4];
    public Transform skillPos;
    public int damage = 20;

    public float speed = 1000.0f;
    // Use this for initialization
    void Start()
    {

        initHp = hp;
        initSp = sp;

        //    GetComponent<Rigidbody>().AddForce(transform.forward * speed);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Heal"))
        {
            Heal(0);
        }
        if(Input.GetButtonUp("HpAbsorb"))
        {
            HpAbsorb(1);
        }
        if(Input.GetButtonUp("CheerUp"))
        {
            CheerUp(2);
        }
        if(Input.GetButtonUp("Stone"))
        {
            Stone(3);
        }
    }

    void CheerUp(int buttonNumber)
    {
        Rigidbody skillRb = Instantiate(skill[buttonNumber], skillPos.position, skillPos.rotation).GetComponent<Rigidbody>();
        sp -= 10;
        imgSpbar.fillAmount = (float)sp / (float)initSp;
        //    Instantiate(skill[buttonNumber], skillPos.position, skillPos.rotation);
        skillRb.AddForce(skillPos.transform.forward * speed);
    }

    void Heal(int buttonNumber)
    {
        Rigidbody skillRb = Instantiate(skill[buttonNumber], skillPos.position, skillPos.rotation).GetComponent<Rigidbody>();
        sp -= 10;
        imgSpbar.fillAmount = (float)sp / (float)initSp;
        //    Instantiate(skill[buttonNumber], skillPos.position, skillPos.rotation);
        skillRb.AddForce(skillPos.transform.forward * speed);
    }
    void HpAbsorb(int buttonNumber)
    {

        Rigidbody skillRb = Instantiate(skill[buttonNumber], skillPos.position, skillPos.rotation).GetComponent<Rigidbody>();
        sp -= 10;
        imgSpbar.fillAmount = (float)sp / (float)initSp;
        //    Instantiate(skill[buttonNumber], skillPos.position, skillPos.rotation);
        skillRb.AddForce(skillPos.transform.forward * speed);
    }
    void Stone(int buttonNumber)
    {
        Rigidbody skillRb = Instantiate(skill[buttonNumber], skillPos.position, skillPos.rotation).GetComponent<Rigidbody>();
        sp -= 10;
        imgSpbar.fillAmount = (float)sp / (float)initSp;
        //    Instantiate(skill[buttonNumber], skillPos.position, skillPos.rotation);
        skillRb.AddForce(skillPos.transform.forward * speed);

    }

}
