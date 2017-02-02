using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidManager : MonoBehaviour {
	
	AndroidJavaObject _a;
	void Awake(){
		AndroidJavaClass jc = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
		_a = jc.GetStatic<AndroidJavaClass> ("currentActivity");
	}
	void Start(){
		_a.Call ("Hellofunction");
	}
}
