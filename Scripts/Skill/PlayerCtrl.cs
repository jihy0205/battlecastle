using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Anim
{
  

}


public class PlayerCtrl : MonoBehaviour {
    private float h = 0.0f;
    private float v = 0.0f;

    private Transform tr;
    public Animator animator;

    public float moveSpeed = 10.0f;

    //회전 속도 변수
    public float rotSpeed = 100.0f;
    // Use this for initialization
    public Anim anim;

	void Start () {
        tr = GetComponent<Transform>();
        


		
	}
	
	// Update is called once per frame
	void Update () {
   //     animator.SetBool("Run", true);
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
        //     tr.Translate(Vector3.forward * moveSpeed * v * Time.deltaTime, Space.Self);
        //    tr.Translate(Vector3.right * moveSpeed * h * Time.deltaTime, Space.Self);
        tr.Translate(moveDir * Time.deltaTime * moveSpeed, Space.Self);

        tr.Rotate(Vector3.up * Time.deltaTime * rotSpeed * Input.GetAxis("Mouse X"));
	}
}
