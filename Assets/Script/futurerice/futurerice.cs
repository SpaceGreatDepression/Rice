using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
public class futurerice : MonoBehaviour {
	public GameObject Bg,top,mid,sub;
	// Use this for initialization

	List<GameObject> Tlist = new List<GameObject> ();
	Vector2 V = new Vector2(0,0);
	public GameObject Webview;
	void Awake2(){


		if (V.x == 0) {
			V = FirstScreenSizeSetting.Instance.Size;
		}
		Bg.GetComponent<RectTransform> ().sizeDelta = V;
		top.GetComponent<RectTransform> ().sizeDelta = new Vector2 (V.x,120f);
		top.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0,V.y/2f);
		mid.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0,-40f);
		sub.GetComponent<RectTransform> ().sizeDelta = new Vector2 (V.x,V.y-120f);;
		sub.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (V.x,-60f);
		float num = (11f/3f/104f)+0.1f;
		float ten = (900f / (num)) * (1f - (50f / 100f));
		Debug.Log (ten);
	}
	public void setting(Vector2 v){
		V = v;
		Awake2 ();
	}
		

	int count = 0;
	string fullpath="sources/menu03/03_01/03_01_" ;
	List<Sprite> tempsp =new List<Sprite>();
	public void stage2(){
		Webview.GetComponent<SampleWebView> ().View ("http://www.rice-museum.com/");
		FirstScreenSizeSetting.Instance.ColorOnoff (top.transform.FindChild ("Ts2").gameObject,0,1,0.75f,"C1",this.gameObject);
		FirstScreenSizeSetting.Instance.ColorOnoff (top.transform.FindChild("mt").gameObject,1,0,0.75f,"C1",this.gameObject);
		statusI = 2;
	}
	public void stringclick(){
		FirstScreenSizeSetting.Instance.dad.Dimon ();
		sub.transform.FindChild ("mask").GetChild (0).GetComponent<PinchZoomandview> ().enabled = true;
		datalod ();

	}
	void getsprits(object o){
		Sprite[] S = o as Sprite[];
		tempsp = S.ToList ();
		status = 0;
		sub.transform.FindChild ("mask").GetChild (0).GetComponent<RectTransform> ().pivot = new Vector2 (0.5f,0.5f);
		sub.transform.FindChild ("mask").GetComponent<RectTransform> ().sizeDelta = new Vector2 (V.x,V.y-120f);

		sub.transform.FindChild ("mask").GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0,0);
		sub.transform.FindChild ("mask").GetChild(0).GetComponent<RectTransform> ().sizeDelta = new Vector2 (V.x,1818f/1440f*V.x);
		sub.transform.FindChild ("mask").GetChild (0).GetComponent<PinchZoomandview> ().smooth = false;
		sub.transform.FindChild ("mask").GetChild(0).GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0,0);
		sub.transform.FindChild ("mask").GetChild (0).transform.localScale = new Vector3 (1,1,1);

		sub.transform.FindChild ("mask").GetChild(0).GetComponent<Image> ().sprite = tempsp [0];
		sub.transform.FindChild ("mask").gameObject.SetActive (true);


		FirstScreenSizeSetting.Instance.ColorOnoff (top.transform.FindChild ("Ts").gameObject,0,1,0.75f,"C1",this.gameObject);
		FirstScreenSizeSetting.Instance.ColorOnoff (top.transform.FindChild("mt").gameObject,1,0,0.75f,"C1",this.gameObject);
		FirstScreenSizeSetting.Instance.SMoveAtoB (new Vector2(0,sub.GetComponent<RectTransform>().anchoredPosition.y),sub,0.1f,"M1",this.gameObject,null);
		FirstScreenSizeSetting.Instance.LD.EndLoding ();

	}
	void datalod(){
		FirstScreenSizeSetting.Instance.LD.StartLoding ();
		Lcount = 0;
		Rcount = 0;
		statusI = 1;
		count = 14;
		tempsp.Clear ();
		FirstScreenSizeSetting.Instance.memory ();

		FirstScreenSizeSetting.Instance.getsprites ("03_01",this.gameObject,"getsprits");

	}

	int status = 0;
	bool subuse = false;
	GameObject TempG(){
		GameObject Tempimage = Instantiate (sub.transform.FindChild ("mask").gameObject) as GameObject;
		Tempimage.transform.SetParent (sub.transform.FindChild ("mask").transform.parent);
		Tempimage.transform.SetSiblingIndex (Tempimage.transform.parent.childCount-3);
		Tempimage.transform.localScale = new Vector3 (1,1,1);
		Tempimage.transform.GetChild(0).localScale = new Vector3 (1,1,1);
		Tempimage.GetComponent<RectTransform> ().sizeDelta = new Vector2 (V.x,V.y-120f);
		Tempimage.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (V.x,0);
		Tempimage.transform.GetChild(0).GetComponent<RectTransform> ().sizeDelta = new Vector2 (V.x,1818f/1440f*V.x);
		Tempimage.transform.GetChild(0).GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0,0);
		Tempimage.transform.GetChild (0).GetComponent<Image> ().raycastTarget = false;
		Tempimage.transform.GetChild (0).GetComponent<PinchZoomandview> ().enabled = false;
		Tlist.Add (Tempimage);
		return Tempimage;
	}
	void C1(){

	}
	void M1(){
		FirstScreenSizeSetting.Instance.dad.Dimoff ();
		sub.transform.FindChild ("mask").GetChild (0).GetComponent<Image> ().raycastTarget = true;
//		for (int i = 2; i < count; i++) {
//			if (i >= 10) {
//				tempsp.Add (
//					FirstScreenSizeSetting.Instance.getsprite (fullpath + i.ToString ()));
//				Debug.Log (fullpath + i.ToString () + ".jpg");
//			} else {
//				tempsp.Add (
//					FirstScreenSizeSetting.Instance.getsprite (fullpath +"0"+ i.ToString ()));
//				Debug.Log (fullpath +"0"+ i.ToString () + ".jpg");
//			}
//			Debug.Log (tempsp[i-1].name);
//		}
//		sub.transform.FindChild ("L").GetComponent<Image> ().raycastTarget = true;
//		sub.transform.FindChild ("R").GetComponent<Image> ().raycastTarget = true;
	}
	int Lcount = 0;
	int Rcount = 0;
	public void L(){
		if (Rcount == 0) {
			sub.transform.FindChild ("L").gameObject.SetActive (true);
			sub.transform.FindChild ("R").gameObject.SetActive (true);
			status--;
			if (status <= 0) {
				status = 0;
		
			}
			if (sub.transform.FindChild ("mask").GetChild (0).GetComponent<Image> ().sprite != tempsp [status]) {
				GameObject Tg = TempG ();
				sub.transform.FindChild ("mask").GetChild (0).GetComponent<Image> ().sprite = tempsp [status];
//			sub.transform.FindChild ("R").GetComponent<Image> ().raycastTarget = false;
//			sub.transform.FindChild ("L").GetComponent<Image> ().raycastTarget = false;
	
				sub.transform.FindChild ("mask").GetChild (0).transform.localScale = new Vector3 (1, 1, 1);
				sub.transform.FindChild ("mask").GetChild (0).GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, 0);
				sub.transform.FindChild ("mask").GetChild (0).GetComponent<PinchZoomandview> ().enabled = false;
				Tg.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, 0);
				Tg.SetActive (true);
				FirstScreenSizeSetting.Instance.SMoveAtoB (new Vector2 (V.x, 0), Tg, 0.1f, "M2l", this.gameObject, Tg);
				Lcount++;
			}
			if (status == 0) {
				sub.transform.FindChild ("L").gameObject.SetActive (false);
			}
			if (status == count - 2) {
				sub.transform.FindChild ("R").gameObject.SetActive (false);
			}
		}
	}
	public void R(){
		if (Lcount == 0) {
			sub.transform.FindChild ("L").gameObject.SetActive (true);
			sub.transform.FindChild ("R").gameObject.SetActive (true);
			status++;
			if (status >= count - 2) {
				status = count - 2;
			}
			if (sub.transform.FindChild ("mask").GetChild (0).GetComponent<Image> ().sprite != tempsp [status]) {
				GameObject Tg = TempG ();
				Tg.transform.GetChild (0).GetComponent<Image> ().sprite = tempsp [status];
//				sub.transform.FindChild ("R").GetComponent<Image> ().raycastTarget = false;
//			sub.transform.FindChild ("L").GetComponent<Image> ().raycastTarget = false;
				sub.transform.FindChild ("mask").GetChild (0).transform.localScale = new Vector3 (1, 1, 1);
				sub.transform.FindChild ("mask").GetChild (0).GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, 0);
				sub.transform.FindChild ("mask").GetChild (0).GetComponent<PinchZoomandview> ().enabled = false;
				Tg.gameObject.SetActive (true);
				FirstScreenSizeSetting.Instance.SMoveAtoB (new Vector2 (0, 0), Tg, 0.1f, "M2r", this.gameObject, Tg);
				Rcount++;
			}
			if (status == 0) {
				sub.transform.FindChild ("L").gameObject.SetActive (false);
			}
			if (status == count - 2) {
				sub.transform.FindChild ("R").gameObject.SetActive (false);
			}

		}
	}
	void M2r(object o){
		GameObject O = (GameObject)o;
		if (sub.transform.FindChild ("mask").GetChild (0).GetComponent<Image> ().sprite != tempsp [status]) {
			sub.transform.FindChild ("mask").GetChild (0).GetComponent<PinchZoomandview> ().smooth = false;
			sub.transform.FindChild ("mask").GetChild (0).GetComponent<Image> ().sprite = O.transform.GetChild (0).GetComponent<Image> ().sprite;
			sub.transform.FindChild ("mask").GetChild (0).GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, 0);
			sub.transform.FindChild ("mask").GetChild (0).transform.localScale = new Vector3 (1, 1, 1);
		}
		Tlist.Remove (O);
		Destroy (O);

		sub.transform.FindChild ("L").GetComponent<Image> ().raycastTarget = true;
		sub.transform.FindChild ("R").GetComponent<Image> ().raycastTarget = true;
		sub.transform.FindChild ("mask").GetChild (0).GetComponent<PinchZoomandview> ().enabled = true;
		Rcount--;

	}
	void M2l(object o){
		GameObject O = (GameObject)o;
		if (sub.transform.FindChild ("mask").GetChild (0).GetComponent<Image> ().sprite != tempsp [status]) {
			sub.transform.FindChild ("mask").GetChild (0).GetComponent<PinchZoomandview> ().smooth = false;
			sub.transform.FindChild ("mask").GetChild (0).GetComponent<Image> ().sprite = O.transform.GetChild (0).GetComponent<Image> ().sprite;
			sub.transform.FindChild ("mask").GetChild (0).GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, 0);
			sub.transform.FindChild ("mask").GetChild (0).transform.localScale = new Vector3 (1, 1, 1);
		}
		Tlist.Remove (O);
		Destroy (O);

		sub.transform.FindChild ("L").GetComponent<Image> ().raycastTarget = true;
		sub.transform.FindChild ("R").GetComponent<Image> ().raycastTarget = true;
		sub.transform.FindChild ("mask").GetChild (0).GetComponent<PinchZoomandview> ().enabled = true;
		Lcount--;

	}
	int statusI = 0;
	public void back(){
		FirstScreenSizeSetting.Instance.dad.Dimon ();
		if (statusI == 1) {
			statusI = 0;
			top.transform.FindChild ("back").GetComponent<Image> ().raycastTarget = false;
			if (top.transform.FindChild ("Ts").GetComponent<Image> ().color.a != 0) {
				FirstScreenSizeSetting.Instance.Smovestop ();
				FirstScreenSizeSetting.Instance.colorOnoffstop ();

				
				FirstScreenSizeSetting.Instance.ColorOnoff (top.transform.FindChild ("Ts").gameObject,
					top.transform.FindChild ("Ts").GetComponent<Image> ().color.a, 0, 0.3f, "C1", this.gameObject);
				
				FirstScreenSizeSetting.Instance.ColorOnoff (top.transform.FindChild ("mt").gameObject,
					top.transform.FindChild ("mt").GetComponent<Image> ().color.a, 1, 0.3f, "C1", this.gameObject);
				FirstScreenSizeSetting.Instance.SMoveAtoB (new Vector2 (V.x, sub.GetComponent<RectTransform> ().anchoredPosition.y), sub, 0.05f, "M3", this.gameObject, null);

			}
			sub.transform.FindChild ("mask").GetChild (0).GetComponent<Image> ().raycastTarget = false;
			sub.transform.FindChild ("L").gameObject.SetActive (false);
			sub.transform.FindChild ("R").gameObject.SetActive (true);
			sub.transform.FindChild ("mask").GetChild (0).GetComponent<PinchZoomandview> ().enabled = true;
		} else if (statusI == 2) {
			statusI = 0;
			Webview.GetComponent<SampleWebView> ().close ();
			FirstScreenSizeSetting.Instance.ColorOnoff (top.transform.FindChild ("Ts2").gameObject, 1, 0, 0.75f, "C1", this.gameObject);
			FirstScreenSizeSetting.Instance.ColorOnoff (top.transform.FindChild ("mt").gameObject, 0, 1, 0.75f, "C1", this.gameObject);
		}else if(statusI == 0){
			StopAllCoroutines ();
			transform.parent.FindChild ("bot").gameObject.SetActive (false);
		
			FirstScreenSizeSetting.Instance.SMoveAtoB (new Vector2 (V.x, 0), this.gameObject, 0.1f, "gohome", this.gameObject, null);
		}
	}
	void gohome(){
		statusI = 0;
		this.gameObject.SetActive (false);
		FirstScreenSizeSetting.Instance.kipbackevent (
			transform.parent.FindChild ("MAIN PAGE").GetComponent<Mainpage> ().close);
		FirstScreenSizeSetting.Instance.dad.Dimoff ();
	}
	void M3(){
		FirstScreenSizeSetting.Instance.dad.Dimoff ();
		top.transform.FindChild ("back").GetComponent<Image> ().raycastTarget = true;
		for (int i = 0; i < Tlist.Count; i++) {
			Destroy (Tlist[i]);
		}
		Tlist.Clear();
		FirstScreenSizeSetting.Instance.memory ();
	}
//	class Coru{
//		public Coroutine C;
//		public string name;
//	}
}
