using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class RearWheelDrive : MonoBehaviour {
	public float maxAngle = 30; // 輪胎的角度
	public float maxTorque = 300; //扭力（馬力）

	public WheelCollider[] wheelColliderArray; //Collider物件

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		float angle = maxAngle * CrossPlatformInputManager.GetAxis ("Horizontal");
		float torque = maxTorque * CrossPlatformInputManager.GetAxis ("Vertical");

		wheelColliderArray [0].steerAngle = angle;
		wheelColliderArray [1].steerAngle = angle;
		wheelColliderArray [2].motorTorque = torque;
		wheelColliderArray [3].motorTorque = torque;

		foreach (WheelCollider wheelCollider in wheelColliderArray){ //賦予角度
			
			Vector3 p;
			Quaternion q;

			wheelCollider.GetWorldPose (out p, out q);
			Transform wheelShape = wheelCollider.transform.GetChild (0); //wheelColliderArray的子物件 American_Muscle_01_Wheel

			//wheelShape.position = p;
			wheelShape.rotation = q;

		}
	}
}
