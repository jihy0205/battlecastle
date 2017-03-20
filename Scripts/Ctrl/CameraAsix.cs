using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAsix : MonoBehaviour {

	public float CameraSpeed = 10.0f;
	Vector3 MouseGap;
	public float distance = 3.0f;
	public bool Invert = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (1)) {
			MouseGap.y += Input.GetAxis ("Mouse X") * CameraSpeed;
			if (Invert)
				MouseGap.x += Input.GetAxis ("Mouse Y") * CameraSpeed;
			else
				MouseGap.x -= Input.GetAxis ("Mouse Y") * CameraSpeed;

			MouseGap.x = Mathf.Clamp (MouseGap.x, -50f, 50f);
		}
		transform.rotation = Quaternion.Euler (MouseGap);
		Transform camT = Camera.main.transform;

		Vector3 tmp = transform.forward * -1;
		distance += Input.GetAxis ("Mouse ScrollWheel") * -10;

		tmp *= distance;
		camT.position = tmp + transform.position;
	}
}
