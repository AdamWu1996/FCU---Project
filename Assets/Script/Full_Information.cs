using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Full_Information : MonoBehaviour {

	public int startFull = 100;
	public Slider fullSlider;
	private static int currentFull;
	private float time = 0;

	void Awake(){
		
		fullSlider.maxValue = startFull; //初始化飽滿度最大值

		if (currentFull <= 0) { //死掉後重新開始
			fullSlider.value = startFull;
			currentFull = startFull;
		}
		else {
			fullSlider.value = startFull; //正常初始化
		}

	}

	public void GraduallyHungry(){
		fullSlider.value -= 10;
		time = 0;
	}

	void FixedUpdate(){
		
		time += Time.deltaTime;

		if(time > 3)
			GraduallyHungry ();
	}

}
