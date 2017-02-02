using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Loding : MonoBehaviour {
	Vector2 V = new Vector2(0,0);
	public GameObject dim;
	public Image lo;
	public List<Sprite> lolist = new List<Sprite>();
	// Use this for initialization

	
	void Awake2(){

		if (V.x == 0) {
			V = FirstScreenSizeSetting.Instance.Size;
		}
		dim.GetComponent<RectTransform> ().sizeDelta = new Vector2 (V.x,V.y);
	//	dim.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0,-60f);

	}

	public void setting(Vector2 v){
		V = v;

		Awake2 ();
	}
	public void StartLoding(){
		dim.SetActive (true);
		StartCoroutine ("Lodings");

	}
	public void EndLoding(){
		dim.SetActive (false);
		StopCoroutine ("Lodings");
	
	}
	IEnumerator Lodings(){
		while(true){
			lo.sprite = lolist [0];
			yield return new WaitForSeconds(0.1f);
			lo.sprite = lolist [1];
			yield return new WaitForSeconds(0.1f);
		}
	}
}
