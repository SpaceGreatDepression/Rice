using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Mainpage : MonoBehaviour {

	public GameObject Bg,mid;
	public GameObject bp,bw,br;
	float topgap = 0;
	Vector2 V = new Vector2(0,0);
	void Awake(){

		if (V.x == 0) {
			V = FirstScreenSizeSetting.Instance.Size;
		}
		Bg.GetComponent<RectTransform> ().sizeDelta = V;
//		float ygap = 30+ (((V.y - 1140f) / 480f)*70f);
//		if (ygap < 30) {
//			ygap = 30;
//		}
		//top.GetComponent<RectTransform> ().sizeDelta = new Vector2 (V.x,ygap);
		//top.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0,V.y/2f);
	//	bot.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (V.x/2f,V.y/-2f);
		mid.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, -40);
		bp.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (V.x,0);
		bw.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (V.x,0);
		br.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (V.x,0);
	}
	public void setting(Vector2 v){
		V = v;
		Awake ();
	}
	public void stage1(){
		mid.transform.GetChild (0).GetComponent<Image> ().raycastTarget = false;
		mid.transform.GetChild (1).GetComponent<Image> ().raycastTarget = false;
		mid.transform.GetChild (2).GetComponent<Image> ().raycastTarget = false;
		bp.SetActive (true);
		FirstScreenSizeSetting.Instance.SMoveAtoB (new Vector2(0,0),bp,0.1f,"M1",this.gameObject,null);
	}
	public void stage2(){
		mid.transform.GetChild (0).GetComponent<Image> ().raycastTarget = false;
		mid.transform.GetChild (1).GetComponent<Image> ().raycastTarget = false;
		mid.transform.GetChild (2).GetComponent<Image> ().raycastTarget = false;
		bw.SetActive (true);
		FirstScreenSizeSetting.Instance.SMoveAtoB (new Vector2(0,0),bw,0.1f,"M1",this.gameObject,null);
	}
	public void stage3(){
		mid.transform.GetChild (0).GetComponent<Image> ().raycastTarget = false;
		mid.transform.GetChild (1).GetComponent<Image> ().raycastTarget = false;
		mid.transform.GetChild (2).GetComponent<Image> ().raycastTarget = false;
		br.SetActive (true);
		FirstScreenSizeSetting.Instance.SMoveAtoB (new Vector2(0,0),br,0.1f,"M1",this.gameObject,null);
	}
	void M1(){
		mid.transform.GetChild (0).GetComponent<Image> ().raycastTarget = true;
		mid.transform.GetChild (1).GetComponent<Image> ().raycastTarget = true;
		mid.transform.GetChild (2).GetComponent<Image> ().raycastTarget = true;
	}
}
