using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class bestpractice : MonoBehaviour {
	public GameObject Bg,top,mid,sub,go1,go2,go3;
	// Use this for initialization
	public float Midmenusizey = 150f;
	public float Midsubsizey = 100f;
	List<GameObject> Tlist = new List<GameObject> ();
	Vector2 V = new Vector2(0,0);
	void setmask(Transform Tmid,int i){
		float gap = 0;	

		Transform T = Tmid.transform.FindChild (i.ToString ()).transform;
		T.GetComponent<RectTransform> ().sizeDelta = new Vector2 (V.x,Midsubsizey*T.GetChild(0).transform.childCount);
		T.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0,-Midmenusizey);
		T.transform.GetChild (0).GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0,T.GetComponent<RectTransform> ().sizeDelta.y);
		Tmid.transform.FindChild ("go" + i.ToString ()).GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, -gap);
		Tmid.transform.FindChild ("go" + i.ToString ()).GetComponent<RectTransform> ().sizeDelta = new Vector2 (V.x, Midmenusizey);
		if (i != 1) {
			Tmid.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0,-Midmenusizey);
		}
		gap += Midmenusizey * T.transform.childCount;
		for (int a = 0; a < T.transform.GetChild(0).childCount; a++) {
			T.transform.GetChild (0).GetChild (a).GetComponent<RectTransform> ().anchoredPosition = new Vector2 (-37,-(a*Midsubsizey));
		//	T.transform.GetChild (a).GetComponent<RectTransform> ().sizeDelta = new Vector2 (200,Midsubsizey);
		}

		if (T.transform.parent.childCount > 2||i == 1) {
			
			setmask (Tmid.transform.FindChild ("go" + (i + 1).ToString () + "s").transform, (i + 1));
		//	Debug.Log (i);
//			Tmid.transform.FindChild ("go" + (i + 1).ToString () + "s").transform.FindChild ("mask").GetComponent<RectTransform> ().sizeDelta = new Vector2 (V.x,
//				((float)Tmid.transform.FindChild ("go" + (i + 1).ToString () + "s").transform.FindChild ((i + 1).ToString ()).GetChild(0).transform.childCount * Midsubsizey/2f)+Midmenusizey);

		}
	}
	void Awake2(){
		if (V.x == 0) {
			V = FirstScreenSizeSetting.Instance.Size;
		}
		Bg.GetComponent<RectTransform> ().sizeDelta = V;
		top.GetComponent<RectTransform> ().sizeDelta = new Vector2 (V.x,120f);
		top.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0,V.y/2f);
		mid.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0,(V.y/2f)-top.GetComponent<RectTransform> ().sizeDelta.y);
		setmask (mid.transform.FindChild("go1s").transform,1);
		sub.GetComponent<RectTransform> ().sizeDelta = new Vector2 (V.x,V.y-120f);
		sub.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (V.x,-60f);

	}
	public void setting(Vector2 v){
		V = v;
		Awake2 ();
	}
	int maxc = 0;
	int nowc = 0;
	public void gomaskclick(GameObject g){
		nowc = 0;
		maxc = 1;
		Debug.Log ("gomaskclick");
		go1.transform.parent.parent.FindChild ("go"+go1.name).GetComponent<Image> ().raycastTarget = false;
		go2.transform.parent.parent.FindChild ("go"+go2.name).GetComponent<Image> ().raycastTarget = false;
		go3.transform.parent.parent.FindChild ("go"+go3.name).GetComponent<Image> ().raycastTarget = false;
		StartCoroutine ("smoothm",g.GetComponent<RectTransform>());
		switch (g.name) {
		case "1":
			if (go2.GetComponent<RectTransform> ().anchoredPosition.y == 0) {
				maxc++;
				StartCoroutine ("smoothm",go2.GetComponent<RectTransform>());
			}
			if (go3.GetComponent<RectTransform> ().anchoredPosition.y == 0) {
				maxc++;
				StartCoroutine ("smoothm",go3.GetComponent<RectTransform>());
			}
			break;
		case "2":
			if (go1.GetComponent<RectTransform> ().anchoredPosition.y == 0) {
				maxc++;
				StartCoroutine ("smoothm",go1.GetComponent<RectTransform>());
			}
			if (go3.GetComponent<RectTransform> ().anchoredPosition.y == 0) {
				maxc++;
				StartCoroutine ("smoothm",go3.GetComponent<RectTransform>());
			}
			break;
		case "3":
			if (go2.GetComponent<RectTransform> ().anchoredPosition.y == 0) {
				maxc++;
				StartCoroutine ("smoothm",go2.GetComponent<RectTransform>());
			}
			if (go1.GetComponent<RectTransform> ().anchoredPosition.y == 0) {
				maxc++;
				StartCoroutine ("smoothm",go1.GetComponent<RectTransform>());
			}
			break;
		}
	}
	IEnumerator smoothm(RectTransform R){

		Vector2 vel = new Vector2(0,0);
		float he = R.GetComponent<RectTransform>().sizeDelta.y;
		if (R.anchoredPosition.y == 0) {
			R.transform.parent.parent.FindChild ("go" + R.name).FindChild("arrow").transform.localScale = new Vector3 (1,1,1);
			while (true) {
				Vector2 sv = R.anchoredPosition;
				R.anchoredPosition = Vector2.SmoothDamp (R.anchoredPosition, new Vector2 (0, R.sizeDelta.y), ref vel, 0.1f,9999f,0.02f);

				if (int.Parse (R.name) + 1 <= 3) {
					Vector2 s =  sv-R.anchoredPosition;
		
					R.transform.parent.parent.FindChild ("go" + (int.Parse (R.name) + 1).ToString()+"s").GetComponent<RectTransform> ().anchoredPosition -= s;
				}
				if (Mathf.Abs (vel.y) < 0.3f) {
					R.anchoredPosition = new Vector2 (0, R.sizeDelta.y);
					nowc++;
					Debug.Log (maxc +" : "+ nowc);
					if (maxc <= nowc) {
						go1.transform.parent.parent.FindChild ("go" + go1.name).GetComponent<Image> ().raycastTarget = true;
						go2.transform.parent.parent.FindChild ("go" + go2.name).GetComponent<Image> ().raycastTarget = true;
						go3.transform.parent.parent.FindChild ("go" + go3.name).GetComponent<Image> ().raycastTarget = true;
					}
					if (int.Parse (R.name) + 1 <= 3) {
						R.transform.parent.parent.FindChild ("go" + (int.Parse (R.name) + 1).ToString()+"s").GetComponent<RectTransform> ().anchoredPosition = new Vector2(0,
							-Midmenusizey);
						}
					break;
				}
				yield return new WaitForFixedUpdate ();
			}
		} else {
		//	Debug.Log (R.transform.parent.parent.name);
		//	Debug.Log (R.name);
			R.transform.parent.parent.FindChild ("go" + R.name).FindChild("arrow").transform.localScale = new Vector3 (-1,1,1);
			while (true) {
				Vector2 sv = R.anchoredPosition;
				R.anchoredPosition = Vector2.SmoothDamp (R.anchoredPosition, new Vector2 (0, 0), ref vel, 0.1f,9999f,0.02f);
				if (int.Parse (R.name) + 1 <= 3) {
					Vector2 s =  sv-R.anchoredPosition;
		
					R.transform.parent.parent.FindChild ("go" + (int.Parse (R.name) + 1).ToString()+"s").GetComponent<RectTransform> ().anchoredPosition -= s;
				}
				if (Mathf.Abs (vel.y) < 0.3f) {
					R.anchoredPosition = new Vector2 (0, 0);
					nowc++;
					Debug.Log (maxc +" : "+ nowc);
					if (maxc <= nowc) {
						go1.transform.parent.parent.FindChild ("go" + go1.name).GetComponent<Image> ().raycastTarget = true;
						go2.transform.parent.parent.FindChild ("go" + go2.name).GetComponent<Image> ().raycastTarget = true;
						go3.transform.parent.parent.FindChild ("go" + go3.name).GetComponent<Image> ().raycastTarget = true;
					}
					if (int.Parse (R.name) + 1 <= 3) {
						R.transform.parent.parent.FindChild ("go" + (int.Parse (R.name) + 1).ToString()+"s").GetComponent<RectTransform> ().anchoredPosition = new Vector2(0,
							-Midmenusizey-((float)R.transform.childCount*Midsubsizey));
					}
					break;
				}
				yield return new WaitForFixedUpdate ();
			}
		}
	}
	string path = "sources/menu01";
	int count = 0;
	string fullpath;
	List<Sprite> tempsp =new List<Sprite>();
	string cha;
	public void stringclick(string s){
		FirstScreenSizeSetting.Instance.dad.Dimon ();
		StartCoroutine ("datalod",s);
		/*
		subuse = true;
		tempsp.Clear ();
		FirstScreenSizeSetting.Instance.memory ();
		switch (s) {
		case "01_01_school02":
			count = 14;
			break;
		case "01_02_school04":
		case "01_02_school03":
		case "01_01_school03":
			count = 15;
			break;
		case "01_03_school02":
		case "01_03_school01":
		case "01_01_school01":
		case "01_02_school01":
		case "01_02_school02":			
		case "01_02_school05":
			count = 16;
			break;
		}
		cha = "";
		char[] ch = s.ToCharArray ();
//		for (int i = 0; i < ch.Length - 1; i++) {
//			cha += ch [i].ToString ();
//		}
	
		fullpath = path+"/"+ s+"/"+s+"_";

		for (int i = 1; i < 2; i++) {
			if (i >= 10) {
				tempsp.Add (
					FirstScreenSizeSetting.Instance.getsprite (fullpath + i.ToString ()));
				Debug.Log (fullpath + i.ToString () + ".jpg");
			} else {
				tempsp.Add (
					FirstScreenSizeSetting.Instance.getsprite (fullpath +"0"+ i.ToString ()));
				Debug.Log (fullpath +"0"+ i.ToString () + ".jpg");
			}
			Debug.Log (tempsp[i-1].name);
		}
		status = 0;

		sub.transform.FindChild ("mask").GetComponent<RectTransform> ().sizeDelta = new Vector2 (V.x,V.y-120f);

		sub.transform.FindChild ("mask").GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0,0);
		sub.transform.FindChild ("mask").GetChild(0).GetComponent<RectTransform> ().sizeDelta = new Vector2 (V.x,1818f/1440f*V.x);

		sub.transform.FindChild ("mask").GetChild(0).GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0,0);

		sub.transform.FindChild ("mask").GetChild(0).GetComponent<Image> ().sprite = tempsp [0];
		sub.transform.FindChild ("mask").gameObject.SetActive (true);
		cha = ch [4].ToString ()+"_"+ch[13].ToString();
		top.transform.FindChild ("st").FindChild (cha).GetComponent<Image> ().color = new Color (1,1,1,0);
		FirstScreenSizeSetting.Instance.ColorOnoff (top.transform.FindChild ("st").FindChild (cha).gameObject,0,1,0.75f,"C1",this.gameObject);
		FirstScreenSizeSetting.Instance.ColorOnoff (top.transform.FindChild ("Ts").gameObject,0,1,0.75f,"C1",this.gameObject);
		FirstScreenSizeSetting.Instance.ColorOnoff (top.transform.FindChild("mt").gameObject,1,0,0.75f,"C1",this.gameObject);
		FirstScreenSizeSetting.Instance.SMoveAtoB (new Vector2(0,sub.GetComponent<RectTransform>().anchoredPosition.y),sub,0.1f,"M1",this.gameObject,null);*/

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
		Tlist.Add (Tempimage);
		return Tempimage;
	}
	IEnumerator datalod(string s){
		FirstScreenSizeSetting.Instance.LD.StartLoding ();


		subuse = true;
		tempsp.Clear ();
		FirstScreenSizeSetting.Instance.memory ();
		switch (s) {
		case "01_01_school02":
			count = 13;
			break;
		case "01_02_school04":
		case "01_02_school03":
		case "01_01_school03":
			count = 14;
			break;
		case "01_03_school02":
		case "01_03_school01":
		case "01_01_school01":
		case "01_02_school01":
		case "01_02_school02":			
		case "01_02_school05":
			count = 15;
			break;
		}
		cha = "";
		char[] ch = s.ToCharArray ();
		//		for (int i = 0; i < ch.Length - 1; i++) {
		//			cha += ch [i].ToString ();
		//		}

		fullpath = path+"/"+ s+"/"+s+"_";




		for (int i = 1; i < count; i++) {
			if (i >= 10) {
				tempsp.Add (
					FirstScreenSizeSetting.Instance.getsprite (fullpath + i.ToString ()));
				Debug.Log (fullpath + i.ToString () + ".jpg");
			} else {
				tempsp.Add (
					FirstScreenSizeSetting.Instance.getsprite (fullpath +"0"+ i.ToString ()));
				Debug.Log (fullpath +"0"+ i.ToString () + ".jpg");
			}
			Debug.Log (tempsp[i-1].name);
			yield return new WaitForFixedUpdate ();
		}
		yield return new WaitForSeconds (0.1f);

		status = 0;
		sub.transform.FindChild ("mask").GetChild (0).GetComponent<RectTransform> ().pivot = new Vector2 (0.5f,0.5f);
		sub.transform.FindChild ("mask").GetComponent<RectTransform> ().sizeDelta = new Vector2 (V.x,V.y-120f);

		sub.transform.FindChild ("mask").GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0,0);
		sub.transform.FindChild ("mask").GetChild (0).GetComponent<PinchZoomandview> ().smooth = false;
		sub.transform.FindChild ("mask").GetChild(0).GetComponent<RectTransform> ().sizeDelta = new Vector2 (V.x,1818f/1440f*V.x);

		sub.transform.FindChild ("mask").GetChild(0).GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0,0);
		sub.transform.FindChild ("mask").GetChild (0).transform.localScale = new Vector3 (1,1,1);
		sub.transform.FindChild ("mask").GetChild(0).GetComponent<Image> ().sprite = tempsp [0];

		sub.transform.FindChild ("mask").gameObject.SetActive (true);
		cha = ch [4].ToString ()+"_"+ch[13].ToString();
		top.transform.FindChild ("st").FindChild (cha).GetComponent<Image> ().color = new Color (1,1,1,0);
		FirstScreenSizeSetting.Instance.ColorOnoff (top.transform.FindChild ("st").FindChild (cha).gameObject,0,1,0.75f,"C1",this.gameObject);
		FirstScreenSizeSetting.Instance.ColorOnoff (top.transform.FindChild ("Ts").gameObject,0,1,0.75f,"C1",this.gameObject);
		FirstScreenSizeSetting.Instance.ColorOnoff (top.transform.FindChild("mt").gameObject,1,0,0.75f,"C1",this.gameObject);
		FirstScreenSizeSetting.Instance.SMoveAtoB (new Vector2(0,sub.GetComponent<RectTransform>().anchoredPosition.y),sub,0.1f,"M1",this.gameObject,null);
		FirstScreenSizeSetting.Instance.LD.EndLoding ();
	}
	void C1(){

	}
	void M1(){
		sub.transform.FindChild ("mask").GetChild (0).GetComponent<Image> ().raycastTarget = true;
		FirstScreenSizeSetting.Instance.dad.Dimoff ();
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
	public void L(){
		sub.transform.FindChild ("L").gameObject.SetActive (true);
		sub.transform.FindChild ("R").gameObject.SetActive (true);
		status--;
		if (status <= 0) {
			status = 0;
		
		}
		if (sub.transform.FindChild("mask").GetChild(0).GetComponent<Image> ().sprite != tempsp [status]) {
			GameObject Tg = TempG ();
			sub.transform.FindChild ("mask").GetChild(0).GetComponent<Image> ().sprite = tempsp [status];
//			sub.transform.FindChild ("R").GetComponent<Image> ().raycastTarget = false;
//			sub.transform.FindChild ("L").GetComponent<Image> ().raycastTarget = false;
	
	
			Tg.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0,0);
			Tg.SetActive (true);
			FirstScreenSizeSetting.Instance.SMoveAtoB (new Vector2(V.x,0),Tg,0.1f,"M2",this.gameObject,Tg);
		}
		if (status == 0) {
			sub.transform.FindChild ("L").gameObject.SetActive (false);
		}
		if (status == count - 2) {
			sub.transform.FindChild ("R").gameObject.SetActive (false);
		}
	}
	public void R(){
		sub.transform.FindChild ("L").gameObject.SetActive (true);
		sub.transform.FindChild ("R").gameObject.SetActive (true);
			status++;
		if (status >= count - 2) {
			status = count - 2;
		}
		if (sub.transform.FindChild("mask").GetChild(0).GetComponent<Image> ().sprite != tempsp [status]) {
			GameObject Tg = TempG ();
			Tg.transform.GetChild(0).GetComponent<Image> ().sprite = tempsp [status];
//				sub.transform.FindChild ("R").GetComponent<Image> ().raycastTarget = false;
//			sub.transform.FindChild ("L").GetComponent<Image> ().raycastTarget = false;
				Tg.gameObject.SetActive (true);
			FirstScreenSizeSetting.Instance.SMoveAtoB (new Vector2(0,0),Tg,0.1f,"M2",this.gameObject,Tg);
			}
		if (status == 0) {
			sub.transform.FindChild ("L").gameObject.SetActive (false);
		}
		if (status == count - 2) {
			sub.transform.FindChild ("R").gameObject.SetActive (false);
		}


	}
	void M2(object o){
		GameObject O = (GameObject)o;
		sub.transform.FindChild ("mask").GetChild (0).GetComponent<PinchZoomandview> ().smooth = false;
		sub.transform.FindChild ("mask").GetChild(0).GetComponent<Image> ().sprite = tempsp [status];
		sub.transform.FindChild ("mask").GetChild (0).GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0,0);
		sub.transform.FindChild ("mask").GetChild (0).transform.localScale = new Vector3 (1, 1, 1);
		Tlist.Remove (O);
		Destroy (O);

		sub.transform.FindChild ("L").GetComponent<Image> ().raycastTarget = true;
		sub.transform.FindChild ("R").GetComponent<Image> ().raycastTarget = true;

	

	}

	public void back(){
		if (subuse) {
			FirstScreenSizeSetting.Instance.dad.Dimon ();
			subuse = false;
			top.transform.FindChild ("back").GetComponent<Image> ().raycastTarget = false;
			if (top.transform.FindChild ("Ts").GetComponent<Image> ().color.a != 0) {
				FirstScreenSizeSetting.Instance.Smovestop ();
				FirstScreenSizeSetting.Instance.colorOnoffstop ();

				FirstScreenSizeSetting.Instance.ColorOnoff (top.transform.FindChild ("st").FindChild (cha).gameObject,
					top.transform.FindChild ("st").FindChild (cha).GetComponent<Image> ().color.a, 0, 0.3f, "C1", this.gameObject);
				
				FirstScreenSizeSetting.Instance.ColorOnoff (top.transform.FindChild ("Ts").gameObject,
					top.transform.FindChild ("Ts").GetComponent<Image> ().color.a, 0, 0.3f, "C1", this.gameObject);
				
				FirstScreenSizeSetting.Instance.ColorOnoff (top.transform.FindChild ("mt").gameObject,
					top.transform.FindChild ("mt").GetComponent<Image> ().color.a, 1, 0.3f, "C1", this.gameObject);
				FirstScreenSizeSetting.Instance.SMoveAtoB (new Vector2 (V.x, sub.GetComponent<RectTransform> ().anchoredPosition.y), sub, 0.05f, "M3", this.gameObject, null);

			}
			sub.transform.FindChild ("L").gameObject.SetActive (false);
			sub.transform.FindChild ("R").gameObject.SetActive (true);
			sub.transform.FindChild ("mask").GetChild (0).GetComponent<Image> ().raycastTarget = false;
		} else {
			StopAllCoroutines ();
			go1.GetComponent<RectTransform> ().anchoredPosition = new Vector2(0,go1.GetComponent<RectTransform> ().sizeDelta.y);
			go2.GetComponent<RectTransform> ().anchoredPosition = new Vector2(0,go2.GetComponent<RectTransform> ().sizeDelta.y);
			go3.GetComponent<RectTransform> ().anchoredPosition = new Vector2(0,go3.GetComponent<RectTransform> ().sizeDelta.y);
			go1.transform.parent.parent.FindChild ("go" + go1.name).GetComponent<Image> ().raycastTarget = true;
			go2.transform.parent.parent.FindChild ("go" + go2.name).GetComponent<Image> ().raycastTarget = true;
			go3.transform.parent.parent.FindChild ("go" + go3.name).GetComponent<Image> ().raycastTarget = true;
			mid.transform.FindChild ("go1s").GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0,0);
			mid.transform.FindChild ("go1s").FindChild("go2s").GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0,-Midmenusizey);
			mid.transform.FindChild ("go1s").FindChild("go2s").FindChild("go3s").GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0,-Midmenusizey);
			go1.transform.parent.parent.FindChild ("go1").FindChild ("arrow").transform.localScale = new Vector3 (1,1,1);
			go2.transform.parent.parent.FindChild ("go2").FindChild ("arrow").transform.localScale = new Vector3 (1,1,1);
			go3.transform.parent.parent.FindChild ("go3").FindChild ("arrow").transform.localScale = new Vector3 (1,1,1);
			transform.parent.FindChild ("bot").gameObject.SetActive (false);
			FirstScreenSizeSetting.Instance.SMoveAtoB (new Vector2 (V.x, 0), this.gameObject, 0.1f, "gohome", this.gameObject, null);
			FirstScreenSizeSetting.Instance.dad.Dimon ();
		}
	}
	void gohome(){

		FirstScreenSizeSetting.Instance.kipbackevent (
			transform.parent.FindChild ("MAIN PAGE").GetComponent<Mainpage> ().close);
		this.gameObject.SetActive (false);
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
