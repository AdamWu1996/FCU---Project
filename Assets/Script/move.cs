using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Move : MonoBehaviour
{
	private int  State; //角色狀態   
	private int  oldState=0; //前一次角色的狀態   
	private int  UP = 0; //角色狀態向前   
	private int  RIGHT =1; //角色狀態向右   
	private int  DOWN = 2; //角色狀態向後   
	private int  LEFT = 3; //角色狀態向左 
	public float  speed = 2;
	Animator anim;
	/// <summary>
	/// 垂直輸入量
	/// </summary>
	[SerializeField]
	[Header("垂直輸入量")]
	private float input_V;

	/// <summary>
	/// 水平輸入量
	/// </summary>
	[SerializeField]
	[Header("水平輸入量")]
	private float input_H;

	/// <summary>
	/// 結果角度
	/// </summary>
	[SerializeField]
	[Header("結果角度")]
	private float angle_Sum;

	void Start(){
		
		anim = GetComponent<Animator>();
	}

	void FixedUpdate ()//固定頻率重複執行
	{
		//接Input.GetAxis("Vertical")及("Horizontal")的回傳值
		input_V = CrossPlatformInputManager.GetAxis ("Vertical");
		input_H = CrossPlatformInputManager.GetAxis ("Horizontal");

		//用GetAxisRaw判斷是否按到移動鍵，是的話執行以下程式，放開可以保留角度狀態，也能避免NaN的狀況
		if(CrossPlatformInputManager.GetAxisRaw("Vertical") != 0 || CrossPlatformInputManager.GetAxisRaw ("Horizontal") != 0)
		{
			//三角函數計算
			angle_Sum = Mathf.Atan2 (input_H, input_V) / (Mathf.PI / 180);

			//角色轉向
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, angle_Sum, transform.eulerAngles.z);
		}

	}

	void  Update()  
	{  
		if  (input_V > 0)  
		{  
			setState(UP);  
		}  
		else if  (input_V < 0)   
		{  
			setState(DOWN);  
		}  

		if  (input_H < 0)
		{  
			setState(LEFT);  
		}  
		else if  (input_H > 0)
		{  
			setState(RIGHT);  
		}  

		if (input_V != 0 && input_H!=0)
			anim.SetBool ("isRun", true);
		else
			anim.SetBool ("isRun", false);
		
		//Debug.Log (CrossPlatformInputManager.GetAxis ("Horizontal"));
	}  


	void  setState( int  currState)  
	{  
		Vector3 transformValue =  new  Vector3(); //定義平移向量  
		int  rotateValue = (currState - State) * 90;  
		anim.Play ("Walk");
		switch  (currState)  
		{  
		case  0: //角色狀態向前時，角色不斷向前緩慢移動  
			transformValue = Vector3.forward * Time.deltaTime * speed;  
			break ;  
		case  1: //角色狀態向右時，角色不斷向右緩慢移動  
			transformValue = Vector3.right * Time.deltaTime * speed;  
			break ;  
		case  2: //角色狀態向後時，角色不斷向後緩慢移動  
			transformValue = Vector3.back * Time.deltaTime * speed;  
			break ;  
		case  3: //角色狀態向左時，角色不斷向左緩慢移動  
			transformValue = Vector3.left * Time.deltaTime * speed;  
			break ;  
		}  
		transform.Rotate(Vector3.up, rotateValue); //旋轉角色  
		transform.Translate(transformValue, Space.World); //平移角色  
		oldState = State; //賦值，方便下一次計算  
		State = currState; //賦值，方便下一次計算 
	}  

}