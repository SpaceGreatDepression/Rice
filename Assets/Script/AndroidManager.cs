using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidManager : MonoBehaviour {
	AndroidJavaObject _a;
	// Use this for initialization
	#if UNITY_EDITOR
	#elif UNITY_ANDROID
	void Awake () {
		AndroidJavaClass jc = 
			new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
		_a = jc.GetStatic<AndroidJavaObject> ("currentActivity");
	}
	
	// Update is called once per frame
	void Start(){
		_a.Call ("getmaxvolume");
	}
	#endif
	public int maxvolume,nowvolume;
	void getmaxvolume(string arg){
		maxvolume = int.Parse (arg);
		Debug.Log ("maxvolume : " + maxvolume);
		FirstScreenSizeSetting.Instance.sd.maxValue = (float)maxvolume;
	
	}
	void getvolume(string arg){
		nowvolume = int.Parse (arg);
		Debug.Log ("nowvolume1 : " + nowvolume);
		//FirstScreenSizeSetting.Instance.MPMPE.player.volume = nowvolume / maxvolume;

		FirstScreenSizeSetting.Instance.sd.value = (float)nowvolume;
		FirstScreenSizeSetting.Instance.sd.enabled = true;
	}
	void back(string arg){
		Debug.Log ("arg");
		if (Application.loadedLevelName == "rice") {
			FirstScreenSizeSetting.Instance.back ();
		} else {
			GameObject.Find ("DownloadObbExample").GetComponent<DownloadObbExample> ().pop2c ();
		}
	}
	public void Vg(){
		_a.Call ("getvolume");
	}
	void getnowvolume(string arg){
		nowvolume = int.Parse (arg);
		Debug.Log ("nowvolume1 : " + nowvolume);
	}
	public void Vup(){
		_a.Call ("volumeup");
	}
	public void Vdown(){
		_a.Call ("volumedown");
	}

	void volumeup(string arg){
		nowvolume = int.Parse (arg);
		FirstScreenSizeSetting.Instance.sd.value = (float)nowvolume;
		Debug.Log ("nowvolume2 : " + nowvolume);
	}

	void volumedown(string arg){
		nowvolume = int.Parse (arg);
		FirstScreenSizeSetting.Instance.sd.value = (float)nowvolume;
		Debug.Log ("nowvolume3 : " + nowvolume);
	}
	void AndroidLog(string arg){
		Debug.Log ("newvolume is " + arg);
	}
	public void Vset(int i){
		_a.Call ("setvolume",i.ToString());
	}
	void setvolume(string arg){
		nowvolume = int.Parse (arg);
		Debug.Log ("nowvolume4 : " + nowvolume);
		//FirstScreenSizeSetting.Instance.MPMPE.player.volume = nowvolume / maxvolume;
		FirstScreenSizeSetting.Instance.sd.value = (float)nowvolume;
	}
}
