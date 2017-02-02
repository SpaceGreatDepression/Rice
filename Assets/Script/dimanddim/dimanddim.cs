using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dimanddim : MonoBehaviour {
	public GameObject dim;
	Vector2 V = new Vector2(0,0);
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
	public void Dimon(){
		dim.SetActive (true);

	}
	public void Dimoff(){
		dim.SetActive (false);

	}
}
