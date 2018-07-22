using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MoveByJoystick : MonoBehaviour {

	public float speed = 6f;
	private Vector3 movement;
	private Animator anim;
	private float angle_Sum;
	private Rigidbody catRigidbody;

	void Awake(){
		anim = GetComponent<Animator>();
		catRigidbody = GetComponent<Rigidbody> ();
	}

	void Move(float h,float v){
		movement.Set (h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;
		catRigidbody.MovePosition (transform.position + movement);
	}

	void Animating(float h,float v){
		bool running = h != 0 || v != 0;
		anim.SetBool ("isRun", running);
		//用GetAxisRaw判斷是否按到移動鍵，是的話執行以下程式，放開可以保留角度狀態，也能避免NaN的狀況
		if(CrossPlatformInputManager.GetAxisRaw("Vertical") != 0 || CrossPlatformInputManager.GetAxisRaw ("Horizontal") != 0)
		{
			//三角函數計算
			angle_Sum = Mathf.Atan2 (h, v) / (Mathf.PI / 180);

			//角色轉向
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, angle_Sum, transform.eulerAngles.z);
		}
	}

	void FixedUpdate(){
		float v = CrossPlatformInputManager.GetAxis ("Vertical");
		float h = CrossPlatformInputManager.GetAxis ("Horizontal");
		Move (h, v);
		Animating(h, v);

	}

}
