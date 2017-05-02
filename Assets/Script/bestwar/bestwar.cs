using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
public class bestwar : MonoBehaviour {
	public GameObject Bg,top,mid,sub,sub2,sub4;
	// Use this for initialization
	public GameObject Webview;

	Vector2 V = new Vector2(0,0);
	float wgp;
	public void Awake2(){
		if (V.x == 0) {
			V = FirstScreenSizeSetting.Instance.Size;
		}
		Bg.GetComponent<RectTransform> ().sizeDelta = V;
		top.GetComponent<RectTransform> ().sizeDelta = new Vector2 (V.x,120f);
		top.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0,V.y/2f);
		//mid.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0,(V.y/2f)-top.GetComponent<RectTransform> ().sizeDelta.y);
		mid.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0,-40f);
		sub.GetComponent<RectTransform> ().sizeDelta = new Vector2 (V.x,V.y-120f);;
		sub.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (V.x,-60f);
	
		sub.transform.FindChild("dim").GetComponent<RectTransform> ().sizeDelta = new Vector2 (V.x,V.y-120f);
		sub.transform.FindChild("wg").GetComponent<RectTransform> ().sizeDelta = new Vector2 (V.x,V.x*(683f/1024f));
		sub.transform.FindChild("wg").FindChild("mask").GetComponent<RectTransform> ().sizeDelta = new Vector2 (V.x-14f,V.x*(683f/1024f)-14);
		sub.transform.FindChild("wg").FindChild("mask").GetChild(0).GetComponent<RectTransform> ().sizeDelta = new Vector2 (V.x-14f,V.x*(683f/1024f)-14);
		sub.transform.FindChild ("wg").GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0,-(V.y/2f)-(sub.transform.FindChild("wg").GetComponent<RectTransform> ().sizeDelta.y/2f)-24.5f);
		sub.transform.FindChild ("wg").FindChild ("dim").GetComponent<RectTransform> ().sizeDelta = V;
		wgp = sub.transform.FindChild ("wg").GetComponent<RectTransform> ().anchoredPosition.y;
		sub2.transform.FindChild("wg").GetComponent<RectTransform> ().sizeDelta = new Vector2 (V.x,V.x*(683f/1024f));
		sub2.transform.FindChild("wg").FindChild("RawImage").GetComponent<RectTransform> ().sizeDelta = new Vector2 (V.x-14f,V.x*(683f/1024f)-14);
		sub2.transform.FindChild ("wg").GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0,-(V.y/2f)-(sub.transform.FindChild("wg").GetComponent<RectTransform> ().sizeDelta.y/2f)-24.5f);
		sub2.transform.FindChild ("wg").FindChild ("player").transform.localScale = new Vector3 ((V.x-16f)/786f,(V.x-16f)/786f,1);
		sub2.transform.FindChild("dim").GetComponent<RectTransform> ().sizeDelta = new Vector2 (V.x,V.y-120f);
		sub4.GetComponent<RectTransform> ().sizeDelta = new Vector2 (V.x,V.y-120f);;
		sub4.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (V.x,-60f);
		sub4.transform.FindChild ("wg").FindChild ("dim").GetComponent<RectTransform> ().sizeDelta = V;
		sub4.transform.FindChild("dim").GetComponent<RectTransform> ().sizeDelta = new Vector2 (V.x,V.y-120f);
		sub4.transform.FindChild("wg").GetComponent<RectTransform> ().sizeDelta = new Vector2 (V.x,V.x*(683f/1024f));
		sub4.transform.FindChild("wg").FindChild("mask").GetComponent<RectTransform> ().sizeDelta = new Vector2 (V.x-14f,V.x*(683f/1024f)-14);
		sub4.transform.FindChild("wg").FindChild("mask").GetChild(0).GetComponent<RectTransform> ().sizeDelta = new Vector2 (V.x-14f,V.x*(683f/1024f)-14);
		sub4.transform.FindChild ("wg").GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0,-(V.y/2f)-(sub.transform.FindChild("wg").GetComponent<RectTransform> ().sizeDelta.y/2f)-24.5f);

		setsubscroll ();


	}
	void Start2(){
		sub2.SetActive (true);
		sub2.transform.FindChild ("wg").gameObject.SetActive (true);

		if (dataload) {
			dataload = false;
			sub2.transform.FindChild ("wg").GetComponent<monoflow.MPMP_ugui_Element> ().player.Load ();
		}
		sub2.SetActive (false);
		sub2.transform.FindChild ("wg").gameObject.SetActive (false);
	
	}
	public void setting(Vector2 v){
		V = v;
		Awake2 ();
	}

	void setsubscroll(){
		float sizex = (V.x / 2f) - 12.5f;
		float sizey = sizex*(340f/511f);
		float sum = 8;
		for (int i = 0; i < sub.transform.FindChild ("items").transform.childCount; i++) {
			//Debug.Log ("ss");
			sub.transform.FindChild ("items").transform.GetChild (i).GetComponent<LayoutElement> ().preferredWidth = sizex;
			sub.transform.FindChild ("items").transform.GetChild (i).GetComponent<LayoutElement> ().preferredHeight = sizey;
			sub.transform.FindChild ("items").transform.GetChild (i).GetChild (0).GetComponent<RectTransform> ().sizeDelta = new Vector2 (sizex,sizey);
			sub.transform.FindChild ("items").transform.GetChild (i).GetChild (0).GetComponent<RectTransform> ().anchoredPosition = new Vector2(9,0);
			sum = sum + sizey + 8f;
		}
		sub.transform.FindChild("items").GetComponent<RectTransform> ().sizeDelta = new Vector2 (V.x,sum);
		sub.transform.FindChild ("items").GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0,-sum);
		sum = 8;
		for (int i = 0; i < sub4.transform.FindChild ("items").transform.childCount; i++) {
			//Debug.Log ("ss");
			sub4.transform.FindChild ("items").transform.GetChild (i).GetComponent<LayoutElement> ().preferredWidth = sizex;
			sub4.transform.FindChild ("items").transform.GetChild (i).GetComponent<LayoutElement> ().preferredHeight = sizey;
			sub4.transform.FindChild ("items").transform.GetChild (i).GetChild (0).GetComponent<RectTransform> ().sizeDelta = new Vector2 (sizex,sizey);
			sub4.transform.FindChild ("items").transform.GetChild (i).GetChild (0).GetComponent<RectTransform> ().anchoredPosition = new Vector2(9,0);
			sum = sum + sizey + 8f;
		}
		sub4.transform.FindChild("items").GetComponent<RectTransform> ().sizeDelta = new Vector2 (V.x,sum);
		sub4.transform.FindChild ("items").GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0,-sum);

	}



	List<Sprite> tempsp =new List<Sprite>();
	void C1(){
		FirstScreenSizeSetting.Instance.dad.Dimoff ();
	}
	enum Status{
		stage1,stage2,stage3,stage4,stage1_1,stage0,stage4_1,stage1_1_1,stage4_1_1
	}
	Status ES = Status.stage0;
	public void stage1(){
		FirstScreenSizeSetting.Instance.dad.Dimon ();
		stage1lod ();
	}

	char[] ch;
	void getsprits1(object o){
		Sprite[] S = o as Sprite[];
		tempsp = S.ToList ();
		sub.transform.FindChild ("dim").gameObject.SetActive (false);
		sub.SetActive (true);
		FirstScreenSizeSetting.Instance.ColorOnoff (top.transform.FindChild ("Ts").gameObject,0,1,0.75f,"C1",this.gameObject);
		FirstScreenSizeSetting.Instance.ColorOnoff (top.transform.FindChild("mt").gameObject,1,0,0.75f,"C1",this.gameObject);
		FirstScreenSizeSetting.Instance.SMoveAtoB (new Vector2(0,sub.GetComponent<RectTransform>().anchoredPosition.y),sub,0.1f,"M1",this.gameObject,null);
		sub.transform.FindChild ("dim").GetComponent<Image> ().color = new Color (0,0,0,0);
		sub.transform.FindChild ("dim").gameObject.SetActive (true);
		ES = Status.stage1;
		FirstScreenSizeSetting.Instance.LD.EndLoding();

	}
	void stage1lod(){
		FirstScreenSizeSetting.Instance.LD.StartLoding ();
		Lcount = 0;
		Rcount = 0;
		FirstScreenSizeSetting.Instance.getsprites ("02_01",this.gameObject,"getsprits1");

	}
	bool dataload = true;
	public void stage2(){
		FirstScreenSizeSetting.Instance.dad.Dimon ();
		FirstScreenSizeSetting.Instance.LD.StartLoding ();

		sub2.SetActive (true);
		FirstScreenSizeSetting.Instance.ColorOnoff (top.transform.FindChild ("Ts2").gameObject,0,1,0.75f,"C1",this.gameObject);
		FirstScreenSizeSetting.Instance.ColorOnoff (top.transform.FindChild("mt").gameObject,1,0,0.75f,"C1",this.gameObject);
		//FirstScreenSizeSetting.Instance.SMoveAtoB (new Vector2(0,sub2.GetComponent<RectTransform>().anchoredPosition.y),sub,0.1f,"M1",this.gameObject,null);
		sub2.transform.FindChild ("dim").GetComponent<Image> ().color = new Color (0,0,0,0);
		sub2.transform.FindChild ("dim").gameObject.SetActive (true);
		StartCoroutine("play");
		sub2.transform.FindChild ("wg").FindChild ("player").FindChild ("Slider.Volume").FindChild ("soff").FindChild ("son").gameObject.SetActive (true);
		//sub2.transform.FindChild ("wg").FindChild ("player").FindChild ("Slider.Seek").FindChild ("playerbg").FindChild ("pause").FindChild ("play").gameObject.SetActive (true);
		sub2.transform.FindChild ("wg").GetComponent<monoflow.MPMP_ugui_Element> ().player.volume = 0.5f;
		ES = Status.stage2;
	}

	public void stage3(){
		FirstScreenSizeSetting.Instance.dad.Dimon ();
		Webview.GetComponent<SampleWebView> ().View ("https://www.youtube.com/channel/UCGUuc8iDYP00rBMnSKxaaXQ");
		FirstScreenSizeSetting.Instance.ColorOnoff (top.transform.FindChild ("Ts3").gameObject,0,1,0.75f,"C1",this.gameObject);
		FirstScreenSizeSetting.Instance.ColorOnoff (top.transform.FindChild("mt").gameObject,1,0,0.75f,"C1",this.gameObject);
		ES = Status.stage3;

	}
	public void stage4(){
		FirstScreenSizeSetting.Instance.dad.Dimon ();
		stage4lod ();
	}
	void getsprits4(object o){
		Sprite[] S = o as Sprite[];
		tempsp = S.ToList ();
		sub4.transform.FindChild ("dim").gameObject.SetActive (false);

		sub4.SetActive (true);
		FirstScreenSizeSetting.Instance.ColorOnoff (top.transform.FindChild ("Ts4").gameObject,0,1,0.75f,"C1",this.gameObject);
		FirstScreenSizeSetting.Instance.ColorOnoff (top.transform.FindChild("mt").gameObject,1,0,0.75f,"C1",this.gameObject);
		FirstScreenSizeSetting.Instance.SMoveAtoB (new Vector2(0,sub4.GetComponent<RectTransform>().anchoredPosition.y),sub4,0.1f,"M41",this.gameObject,null);
		sub4.transform.FindChild ("dim").GetComponent<Image> ().color = new Color (0,0,0,0);
		sub4.transform.FindChild ("dim").gameObject.SetActive (true);
		ES = Status.stage4;
		FirstScreenSizeSetting.Instance.LD.EndLoding();

	}
	void stage4lod(){
		FirstScreenSizeSetting.Instance.LD.StartLoding ();
		Lcount4 = 0;
		Rcount4 = 0;
		FirstScreenSizeSetting.Instance.getsprites ("02_04",this.gameObject,"getsprits4");
	}

	public void items2(int i){

		for (int b = 0; b < Tlist.Count; b++) {
			Destroy (Tlist[b]);
		}
		ES = Status.stage4_1;
		sub4.transform.FindChild ("wg").FindChild ("x").GetComponent<Image> ().raycastTarget = true;
		FirstScreenSizeSetting.Instance.colorOnoffstop ();
		FirstScreenSizeSetting.Instance.Smovestop ();
		status = i;
		sub4.transform.FindChild ("wg").gameObject.SetActive (true);
		sub4.transform.FindChild ("wg").FindChild ("mask").GetChild (0).transform.localScale = new Vector3 (1,1,1);
		sub4.transform.FindChild ("wg").FindChild ("mask").GetChild (0).GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0,0);
		sub4.transform.FindChild ("wg").FindChild ("mask").GetChild (0).GetComponent<Image> ().sprite = tempsp [i];
		sub4.transform.FindChild ("dim").GetComponent<Image> ().color = new Color (0,0,0,0);
		sub4.transform.FindChild ("dim").gameObject.SetActive (true);
		FirstScreenSizeSetting.Instance.ColorOnoff (sub4.transform.FindChild("dim").gameObject,0,0.75f,0.5f,"IT",this.gameObject);
		FirstScreenSizeSetting.Instance.SMoveAtoB (new Vector2(0,0),sub4.transform.FindChild ("wg").gameObject,0.2f,"IT",this.gameObject,null);



		setname4 (status);
	}



	IEnumerator play(){
		sub2.transform.FindChild ("wg").FindChild ("x").GetComponent<Image> ().raycastTarget = true;

		sub2.transform.FindChild ("wg").gameObject.SetActive (true);

		sub2.transform.FindChild ("wg").GetComponent<monoflow.MPMP_ugui_Element> ().player.Load ();
		yield return new WaitForSeconds (1f);
		FirstScreenSizeSetting.Instance.LD.EndLoding();
		FirstScreenSizeSetting.Instance.ColorOnoff (sub2.transform.FindChild("dim").gameObject,0,0.75f,0.5f,"IT",this.gameObject);
		FirstScreenSizeSetting.Instance.SMoveAtoB (new Vector2(0,0),sub2.transform.FindChild ("wg").gameObject,0.2f,"IT",this.gameObject,null);


	}

	public void playclose(){
		ES = Status.stage0;
		sub2.transform.FindChild ("wg").FindChild ("x").GetComponent<Image> ().raycastTarget = false;
		if (sub2.transform.FindChild ("wg").GetComponent<RectTransform> ().anchoredPosition.y != wgp) {
			FirstScreenSizeSetting.Instance.colorOnoffstop ();
			FirstScreenSizeSetting.Instance.Smovestop ();
			FirstScreenSizeSetting.Instance.ColorOnoff (top.transform.FindChild ("Ts2").gameObject,1,0,0.5f,"C1",this.gameObject);
			FirstScreenSizeSetting.Instance.ColorOnoff (top.transform.FindChild("mt").gameObject,0,1,0.5f,"C1",this.gameObject);
			FirstScreenSizeSetting.Instance.ColorOnoff (sub2.transform.FindChild("dim").gameObject,sub2.transform.FindChild("dim")
				.GetComponent<Image>().color.a,0,0.5f,"IT2",this.gameObject);
			FirstScreenSizeSetting.Instance.SMoveAtoB (new Vector2(0,wgp),sub2.transform.FindChild ("wg").gameObject,0.2f,"PC",this.gameObject,null);
		}
		sub2.transform.FindChild ("wg").GetComponent<monoflow.MPMP_ugui_Element> ().player.Stop ();
	}
	void PC(){
		sub2.SetActive (false);
	}
	void M1(){
//		for (int i = 1; i < 11; i++) {
//			string path;
//			if (i == 10) {
//				path = "sources/menu02/02_01/02_01_" + i.ToString ();
//			} else {
//				path = "sources/menu02/02_01/02_01_0" + i.ToString ();
//			}
//
//			tempsp.Add (FirstScreenSizeSetting.Instance.getsprite (path));
//			Debug.Log (tempsp [i - 1].name);
//		}
		sub.transform.FindChild ("dim").gameObject.SetActive (false);

	}
	void M41(){
//		for (int i = 1; i < 15; i++) {
//			string path;
//			if (i >= 10) {
//				path = "sources/menu02/02_04/02_04_" + i.ToString ();
//			} else {
//				path = "sources/menu02/02_04/02_04_0" + i.ToString ();
//			}
//
//			tempsp.Add (FirstScreenSizeSetting.Instance.getsprite (path));
//			Debug.Log (tempsp [i - 1].name);
//		}
		sub4.transform.FindChild ("dim").gameObject.SetActive (false);
	}
	int status = 0;
	public void items(int i){

		for (int b = 0; b < Tlist.Count; b++) {
			Destroy (Tlist[b]);
		}
		Tlist.Clear();
		ES = Status.stage1_1;
		sub.transform.FindChild ("wg").FindChild ("x").GetComponent<Image> ().raycastTarget = true;
		FirstScreenSizeSetting.Instance.colorOnoffstop ();
		FirstScreenSizeSetting.Instance.Smovestop ();
		status = i;
		sub.transform.FindChild ("wg").gameObject.SetActive (true);
		sub.transform.FindChild ("wg").FindChild ("mask").GetChild (0).transform.localScale = new Vector3 (1,1,1);
		sub.transform.FindChild ("wg").FindChild ("mask").GetChild (0).GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0,0);
		sub.transform.FindChild ("wg").FindChild ("mask").GetChild (0).GetComponent<Image> ().sprite = tempsp [i];
		sub.transform.FindChild ("dim").GetComponent<Image> ().color = new Color (0,0,0,0);
		sub.transform.FindChild ("dim").gameObject.SetActive (true);
		FirstScreenSizeSetting.Instance.ColorOnoff (sub.transform.FindChild("dim").gameObject,0,0.75f,0.5f,"IT",this.gameObject);
		FirstScreenSizeSetting.Instance.SMoveAtoB (new Vector2(0,0),sub.transform.FindChild ("wg").gameObject,0.2f,"IT",this.gameObject,null);

		setname (status);
	}



	public void playbutton(){
		sub2.transform.FindChild ("wg").FindChild ("player").FindChild ("Slider.Seek").FindChild ("playerbg").FindChild ("pause").FindChild ("play").gameObject.SetActive (false);
	}
	public void pausebutton(){
		sub2.transform.FindChild ("wg").FindChild ("player").FindChild ("Slider.Seek").FindChild ("playerbg").FindChild ("pause").FindChild ("play").gameObject.SetActive (true);
	}
	int savev;
	public void soff(){
		//Debug.Log ("off");
		sub2.transform.FindChild ("wg").FindChild ("player").FindChild ("Slider.Volume").FindChild ("soff").FindChild ("son").gameObject.SetActive (true);
		FirstScreenSizeSetting.Instance.AD.Vset (savev);
		//sub2.transform.FindChild ("wg").FindChild ("player").FindChild ("Slider.Volume").GetComponent<Slider>().value = savev;
		//sub2.transform.FindChild ("wg").GetComponent<monoflow.MPMP_ugui_Element> ().player.volume = savev;
	}
	public void son(){

		sub2.transform.FindChild ("wg").FindChild ("player").FindChild ("Slider.Volume").FindChild ("soff").FindChild ("son").gameObject.SetActive (false);
		savev = (int)sub2.transform.FindChild ("wg").FindChild ("player").FindChild ("Slider.Volume").GetComponent<Slider>().value;

		FirstScreenSizeSetting.Instance.AD.Vset (0);
	//	sub2.transform.FindChild ("wg").FindChild ("player").FindChild ("Slider.Volume").GetComponent<Slider>().value  = 0;
	//	sub2.transform.FindChild ("wg").GetComponent<monoflow.MPMP_ugui_Element> ().player.volume = 0;
	//	Debug.Log ("on" + sub2.transform.FindChild ("wg").FindChild ("player").FindChild ("Slider.Volume").GetComponent<Slider>().value);
	}
	public void onvc(){
		//Debug.Log ("obvc");
	//	Debug.Log ("onvc"+ sub2.transform.FindChild ("wg").FindChild ("player").FindChild ("Slider.Volume").GetComponent<Slider>().value);
		//if (sub2.transform.FindChild ("wg").GetComponent<monoflow.MPMP_ugui_Element> ().player.volume == 0) {
		FirstScreenSizeSetting.Instance.AD.Vg();
		if(FirstScreenSizeSetting.Instance.AD.nowvolume !=(int)sub2.transform.FindChild ("wg").FindChild ("player").FindChild ("Slider.Volume").GetComponent<Slider> ().value){
		FirstScreenSizeSetting.Instance.AD.Vset ((int)sub2.transform.FindChild ("wg").FindChild ("player").FindChild ("Slider.Volume").GetComponent<Slider> ().value);
		}
		if (sub2.transform.FindChild ("wg").FindChild ("player").FindChild ("Slider.Volume").GetComponent<Slider> ().value == 0) {
			sub2.transform.FindChild ("wg").FindChild ("player").FindChild ("Slider.Volume").FindChild ("soff").FindChild ("son").gameObject.SetActive (false);
		} else {
			sub2.transform.FindChild ("wg").FindChild ("player").FindChild ("Slider.Volume").FindChild ("soff").FindChild ("son").gameObject.SetActive (true);
		}
	}
	public void expand(GameObject g){
		if (g.transform.parent.childCount == 7) {
			g.transform.GetComponent<RectTransform> ().sizeDelta = new Vector2 (V.x, V.y);
			g.transform.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, 60f);
			g.transform.GetChild (0).transform.localEulerAngles = new Vector3 (0, 0, -90f);

			g.transform.GetChild (0).GetComponent<RectTransform> ().sizeDelta = new Vector2 (V.y, V.y * (683f / 1024f));
			g.transform.parent.parent.FindChild ("expand").gameObject.SetActive (true);
			g.transform.parent.FindChild ("L").gameObject.SetActive (false);
			g.transform.parent.FindChild ("R").gameObject.SetActive (false);
			g.transform.parent.FindChild ("ex").gameObject.SetActive (false);
			transform.parent.FindChild ("bot").gameObject.SetActive (false);
			g.transform.parent.FindChild ("dim").gameObject.SetActive (true);
			g.transform.parent.parent.GetComponent<RectMask2D> ().enabled = false;
			g.transform.GetChild (0).GetComponent<PinchZoomandview> ().enabled = true;
			if (g.transform.parent.parent.name == "sub") {
				ES = Status.stage1_1_1;
			} else {
				ES = Status.stage4_1_1;
			}
		}
		//g.transform.SetAsLastSibling ();
	}
	public void reduce(GameObject g){
		g.transform.GetComponent<RectTransform> ().sizeDelta = new Vector2 (V.x-14f,V.x*(683f/1024f)-14);
		g.transform.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0,0f);
		g.transform.GetChild (0).transform.localEulerAngles = new Vector3 (0,0,0);

		g.transform.GetChild (0).GetComponent<RectTransform> ().sizeDelta = new Vector2 (V.x-14f,V.x*(683f/1024f)-14f);
		g.transform.GetChild (0).GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0,0);
		g.transform.parent.parent.FindChild("expand").gameObject.SetActive (false);
		g.transform.parent.FindChild ("L").gameObject.SetActive (true);
		g.transform.parent.FindChild ("R").gameObject.SetActive (true);
		g.transform.parent.FindChild ("ex").gameObject.SetActive (true);
		transform.parent.FindChild ("bot").gameObject.SetActive (true);
		g.transform.parent.FindChild ("dim").gameObject.SetActive (false);
		g.transform.parent.parent.GetComponent<RectMask2D> ().enabled = true;
		g.transform.GetChild (0).GetComponent<PinchZoomandview> ().enabled = false;
		if (g.transform.parent.parent.name == "sub") {
			ES = Status.stage1_1;
		} else {
			ES = Status.stage4_1;
		}
		FirstScreenSizeSetting.Instance.dad.Dimoff ();
		//g.transform.SetSiblingIndex (3);
	}
	void setname(int i){
		string s = "";
		switch (i) {
		case 0:
			s = "진주 남강초등학교";
			break;
		case 1:
			s = "울산 동백초등학교";
			break;
		case 2:
			s = "홍성 덕명초등학교";
			break;
		case 3:
			s = "옥천 장야초등학교";
			break;
		case 4:
			s = "예산 대술초등학교";
			break;
		case 5:
			s = "구례 광의초등학교";
			break;
		case 6:
			s = "인천 공촌초등학교";
			break;
		case 7:
			s = "춘천 신동초등학교";
			break;
		case 8:
			s = "대전 용산초등학교";
			break;
		case 9:
			s = "대전 삼천초등학교";
			break;
		}
		sub.transform.FindChild ("wg").FindChild ("textb").GetChild (0).GetComponent<Text> ().text = s;
	}
	void setname4(int i){
		sub4.transform.FindChild ("wg").FindChild ("textb").GetChild (0).GetComponent<LetterSpacing> ().spacing = 2;
		string s = "";
		switch (i) {
		case 0:
			s = "장려상 수상학교들";
			break;
		case 1:
			s = "장려상 - 구례 광의초등학교";
			break;
		case 2:
			s = "장려상 - 옥천 장야초등학교";
			break;
		case 3:
			s = "장려상 - 울산 동백초등학교";
			break;
		case 4:
			s = "장려상 - 춘천 신동초등학교";
			break;
		case 5:
			s = "우수상 수상학교들";
			break;
		case 6:
			s = "우수상 - 예산 대술초등학교";
			break;
		case 7:
			s = "우수상 - 진주 남강초등학교";
			break;
		case 8:
			s = "우수상 - 홍성 덕명초등학교";
			break;
		case 9:
			s = "최우수상 수상학교들";
			break;
		case 10:
			sub4.transform.FindChild ("wg").FindChild ("textb").GetChild (0).GetComponent<LetterSpacing> ().spacing = -2;
			s = "최우수상 - 대전 용산초등학교";
			break;
		case 11:
			sub4.transform.FindChild ("wg").FindChild ("textb").GetChild (0).GetComponent<LetterSpacing> ().spacing = -2;
			s = "최우수상 - 인천 공촌초등학교";
			break;
		case 12:
			s = "대상 - 대전 삼천초등학교";
			break;
		case 13:
			s = "수상자들 단체사진";
			break;
		}
		sub4.transform.FindChild ("wg").FindChild ("textb").GetChild (0).GetComponent<Text> ().text = s;
	}
	void IT(){

	}
	void IT2(){
		sub.transform.FindChild ("dim").gameObject.SetActive (false);
	}
	void IT4(){
		sub4.transform.FindChild ("dim").gameObject.SetActive (false);
	}
	void IV(){
		for (int i = 0; i < Tlist.Count; i++) {
			Destroy (Tlist[i]);
		}
		Tlist.Clear();
		sub.transform.FindChild ("wg").FindChild ("x").GetComponent<Image> ().raycastTarget = true;
		sub.transform.FindChild ("wg").gameObject.SetActive (false);
		sub.SetActive (false);
	}
	void IV4(){
		for (int i = 0; i < Tlist.Count; i++) {
			Destroy (Tlist[i]);
		}
		Tlist.Clear();
		sub4.transform.FindChild ("wg").FindChild ("x").GetComponent<Image> ().raycastTarget = true;
		sub4.transform.FindChild ("wg").gameObject.SetActive (false);
		sub4.SetActive (false);
	}
	void IX(){
		for (int i = 0; i < Tlist.Count; i++) {
			Destroy (Tlist[i]);
		}
		Tlist.Clear();
		sub.transform.FindChild ("wg").FindChild ("x").GetComponent<Image> ().raycastTarget = true;
		sub.transform.FindChild ("wg").gameObject.SetActive (false);
	}
	void IX4(){
		for (int i = 0; i < Tlist.Count; i++) {
			Destroy (Tlist[i]);
		}
		Tlist.Clear();
		sub4.transform.FindChild ("wg").FindChild ("x").GetComponent<Image> ().raycastTarget = true;
		sub4.transform.FindChild ("wg").gameObject.SetActive (false);
	}
	public void close(){
		sub.transform.FindChild ("wg").FindChild ("x").GetComponent<Image> ().raycastTarget = false;
		if (sub.transform.FindChild ("wg").GetComponent<RectTransform> ().anchoredPosition.y != wgp) {
			FirstScreenSizeSetting.Instance.colorOnoffstop ();
			FirstScreenSizeSetting.Instance.Smovestop ();
			FirstScreenSizeSetting.Instance.ColorOnoff (sub.transform.FindChild("dim").gameObject,sub.transform.FindChild("dim")
				.GetComponent<Image>().color.a,0,0.5f,"IT2",this.gameObject);
			FirstScreenSizeSetting.Instance.SMoveAtoB (new Vector2(0,wgp),sub.transform.FindChild ("wg").gameObject,0.2f,"IX",this.gameObject,null);
			ES = Status.stage1;
		}
	}
	public void close4(){
		sub4.transform.FindChild ("wg").FindChild ("x").GetComponent<Image> ().raycastTarget = false;
		if (sub4.transform.FindChild ("wg").GetComponent<RectTransform> ().anchoredPosition.y != wgp) {
			FirstScreenSizeSetting.Instance.colorOnoffstop ();
			FirstScreenSizeSetting.Instance.Smovestop ();
			FirstScreenSizeSetting.Instance.ColorOnoff (sub4.transform.FindChild("dim").gameObject,sub4.transform.FindChild("dim")
				.GetComponent<Image>().color.a,0,0.5f,"IT4",this.gameObject);
			FirstScreenSizeSetting.Instance.SMoveAtoB (new Vector2(0,wgp),sub4.transform.FindChild ("wg").gameObject,0.2f,"IX4",this.gameObject,null);
			ES = Status.stage4;
		}
	}
	List<GameObject> Tlist = new List<GameObject> ();
	GameObject TempG(){
		GameObject Tempimage = Instantiate (sub.transform.FindChild ("wg").FindChild("mask").gameObject) as GameObject;
		Tempimage.transform.SetParent (sub.transform.FindChild ("wg").FindChild("mask").transform.parent);
		Tempimage.transform.SetSiblingIndex (Tempimage.transform.parent.childCount-4);
		Tempimage.transform.localScale = new Vector3 (1,1,1);

		Tempimage.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (V.x,0);
		Tlist.Add (Tempimage);
		return Tempimage;
	}
	GameObject TempG4(){
		GameObject Tempimage = Instantiate (sub4.transform.FindChild ("wg").FindChild("mask").gameObject) as GameObject;
		Tempimage.transform.SetParent (sub4.transform.FindChild ("wg").FindChild("mask").transform.parent);
		Tempimage.transform.SetSiblingIndex (Tempimage.transform.parent.childCount-4);
		Tempimage.transform.localScale = new Vector3 (1,1,1);

		Tempimage.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (V.x,0);
		Tlist.Add (Tempimage);
		return Tempimage;
	}
	public void L(){
		if (Rcount == 0) {
			status--;
			if (status < 0) {
				status = 9;

			}
			setname (status);
			Debug.Log ("L : " + status);
			if (sub.transform.FindChild ("wg").FindChild ("mask").GetChild (0).GetComponent<Image> ().sprite != tempsp [status]) {
				GameObject Tg = TempG ();
				sub.transform.FindChild ("wg").FindChild ("mask").GetChild (0).GetComponent<Image> ().sprite = tempsp [status];
				//			sub.transform.FindChild ("R").GetComponent<Image> ().raycastTarget = false;
				//			sub.transform.FindChild ("L").GetComponent<Image> ().raycastTarget = false;


				Tg.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, 0);
				Tg.SetActive (true);

				FirstScreenSizeSetting.Instance.SMoveAtoB (new Vector2 (V.x, 0), Tg, 0.1f, "M2l", this.gameObject, Tg);
				Lcount++;
			}
		}

	}
	void M2l(object o){
		GameObject O = (GameObject)o;

		if (sub.transform.FindChild ("wg").FindChild ("mask").GetChild (0).GetComponent<Image> ().sprite != tempsp [status]) {

			sub.transform.FindChild ("wg").FindChild ("mask").GetChild (0).GetComponent<Image> ().sprite = O.transform.GetChild(0).GetComponent<Image>().sprite;

		}
		Tlist.Remove (O);
		Destroy (O);

		sub.transform.FindChild ("wg").FindChild ("L").GetComponent<Image> ().raycastTarget = true;
		sub.transform.FindChild ("wg").FindChild ("R").GetComponent<Image> ().raycastTarget = true;

		Lcount--;

	}
	void M2r(object o){
		GameObject O = (GameObject)o;

		if (sub.transform.FindChild ("wg").FindChild ("mask").GetChild (0).GetComponent<Image> ().sprite != tempsp [status]) {

			sub.transform.FindChild ("wg").FindChild ("mask").GetChild (0).GetComponent<Image> ().sprite = O.transform.GetChild(0).GetComponent<Image>().sprite;

		}
		Tlist.Remove (O);
		Destroy (O);

		sub.transform.FindChild ("wg").FindChild ("L").GetComponent<Image> ().raycastTarget = true;
		sub.transform.FindChild ("wg").FindChild ("R").GetComponent<Image> ().raycastTarget = true;
		Rcount--;


	}
	int Lcount = 0;
	int Rcount = 0;
	public void R(){
		if (Lcount == 0) {
			status++;
			if (status >= 10) {
				status = 0;
			}

			setname (status);
			if (sub.transform.FindChild ("wg").FindChild ("mask").GetChild (0).GetComponent<Image> ().sprite != tempsp [status]) {
				Debug.Log ("R : " + status);
				GameObject Tg = TempG ();
				Tg.transform.GetChild (0).GetComponent<Image> ().sprite = tempsp [status];
				//				sub.transform.FindChild ("R").GetComponent<Image> ().raycastTarget = false;
				//			sub.transform.FindChild ("L").GetComponent<Image> ().raycastTarget = false;
				Tg.gameObject.SetActive (true);
	
				FirstScreenSizeSetting.Instance.SMoveAtoB (new Vector2 (0, 0), Tg, 0.1f, "M2r", this.gameObject, Tg);
				Rcount++;
			}


		}
	}
	public void L4(){
		if (Rcount4 == 0) {
			status--;
			if (status < 0) {
				status = 13;

			}
			setname4 (status);
			if (sub4.transform.FindChild ("wg").FindChild ("mask").GetChild (0).GetComponent<Image> ().sprite != tempsp [status]) {
				GameObject Tg = TempG4 ();
				sub4.transform.FindChild ("wg").FindChild ("mask").GetChild (0).GetComponent<Image> ().sprite = tempsp [status];
				//			sub.transform.FindChild ("R").GetComponent<Image> ().raycastTarget = false;
				//			sub.transform.FindChild ("L").GetComponent<Image> ().raycastTarget = false;


				Tg.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, 0);
				Tg.SetActive (true);
		
				FirstScreenSizeSetting.Instance.SMoveAtoB (new Vector2 (V.x, 0), Tg, 0.1f, "M24l", this.gameObject, Tg);
				Lcount4++;
			}
		}
	}
	void M24l(object o){
		GameObject O = (GameObject)o;

		if (sub4.transform.FindChild ("wg").FindChild ("mask").GetChild (0).GetComponent<Image> ().sprite != tempsp [status]) {

			sub4.transform.FindChild ("wg").FindChild ("mask").GetChild (0).GetComponent<Image> ().sprite = O.transform.GetChild(0).GetComponent<Image>().sprite;

		}
		Tlist.Remove (O);
		Destroy (O);

		sub4.transform.FindChild ("wg").FindChild ("L").GetComponent<Image> ().raycastTarget = true;
		sub4.transform.FindChild ("wg").FindChild ("R").GetComponent<Image> ().raycastTarget = true;

		Lcount4--;

	}
	void M24r(object o){
		GameObject O = (GameObject)o;

		if (sub4.transform.FindChild ("wg").FindChild ("mask").GetChild (0).GetComponent<Image> ().sprite != tempsp [status]) {

			sub4.transform.FindChild ("wg").FindChild ("mask").GetChild (0).GetComponent<Image> ().sprite = O.transform.GetChild(0).GetComponent<Image>().sprite;

		}
		Tlist.Remove (O);
		Destroy (O);

		sub4.transform.FindChild ("wg").FindChild ("L").GetComponent<Image> ().raycastTarget = true;
		sub4.transform.FindChild ("wg").FindChild ("R").GetComponent<Image> ().raycastTarget = true;

		Rcount4--;

	}
	int Lcount4 = 0;
	int Rcount4 = 0;
	public void R4(){
		if (Lcount4 == 0) {
			status++;
			if (status > 13) {
				status = 0;
			}
			setname4 (status);
			if (sub4.transform.FindChild ("wg").FindChild ("mask").GetChild (0).GetComponent<Image> ().sprite != tempsp [status]) {
				GameObject Tg = TempG4 ();
				Tg.transform.GetChild (0).GetComponent<Image> ().sprite = tempsp [status];
				//				sub.transform.FindChild ("R").GetComponent<Image> ().raycastTarget = false;
				//			sub.transform.FindChild ("L").GetComponent<Image> ().raycastTarget = false;
				Tg.gameObject.SetActive (true);

				FirstScreenSizeSetting.Instance.SMoveAtoB (new Vector2 (0, 0), Tg, 0.1f, "M24r", this.gameObject, Tg);
				Rcount4++;
			}
		}


	}
	public void back(){
		Debug.Log (ES);
		FirstScreenSizeSetting.Instance.dad.Dimon ();
		if (ES == Status.stage1) {
			tempsp.Clear ();
			FirstScreenSizeSetting.Instance.memory ();
			ES = Status.stage0;
			top.transform.FindChild ("back").GetComponent<Image> ().raycastTarget = false;
			if (top.transform.FindChild ("Ts").GetComponent<Image> ().color.a != 0) {
				FirstScreenSizeSetting.Instance.Smovestop ();
				FirstScreenSizeSetting.Instance.colorOnoffstop ();


				FirstScreenSizeSetting.Instance.ColorOnoff (top.transform.FindChild ("Ts").gameObject,
					top.transform.FindChild ("Ts").GetComponent<Image> ().color.a, 0, 0.3f, "C1", this.gameObject);

				FirstScreenSizeSetting.Instance.ColorOnoff (top.transform.FindChild ("mt").gameObject,
					top.transform.FindChild ("mt").GetComponent<Image> ().color.a, 1, 0.3f, "C1", this.gameObject);
				FirstScreenSizeSetting.Instance.SMoveAtoB (new Vector2 (V.x, sub.GetComponent<RectTransform> ().anchoredPosition.y), sub, 0.05f, "M3", this.gameObject, null);
				sub.transform.FindChild ("wg").FindChild ("x").GetComponent<Image> ().raycastTarget = false;
				if (sub.transform.FindChild ("wg").GetComponent<RectTransform> ().anchoredPosition.y != wgp) {

					FirstScreenSizeSetting.Instance.ColorOnoff (sub.transform.FindChild ("dim").gameObject, sub.transform.FindChild ("dim")
						.GetComponent<Image> ().color.a, 0, 0.3f, "IT2", this.gameObject);
					FirstScreenSizeSetting.Instance.SMoveAtoB (new Vector2 (0, wgp), sub.transform.FindChild ("wg").gameObject, 0.05f, "IV", this.gameObject, null);
				}

			}

		} else if (ES == Status.stage2) {
			FirstScreenSizeSetting.Instance.dad.Dimoff ();
			playclose ();
		} else if (ES == Status.stage1_1) {
			FirstScreenSizeSetting.Instance.dad.Dimoff ();
			ES = Status.stage1;
			close ();
		} else if (ES == Status.stage3) {
			ES = Status.stage0;
			Webview.GetComponent<SampleWebView> ().close ();
			FirstScreenSizeSetting.Instance.ColorOnoff (top.transform.FindChild ("Ts3").gameObject, 1, 0, 0.75f, "C1", this.gameObject);
			FirstScreenSizeSetting.Instance.ColorOnoff (top.transform.FindChild ("mt").gameObject, 0, 1, 0.75f, "C1", this.gameObject);
		} else if (ES == Status.stage4) {
			tempsp.Clear ();
			FirstScreenSizeSetting.Instance.memory ();
			ES = Status.stage0;
	
			top.transform.FindChild ("back").GetComponent<Image> ().raycastTarget = false;
			if (top.transform.FindChild ("Ts4").GetComponent<Image> ().color.a != 0) {
				FirstScreenSizeSetting.Instance.Smovestop ();
				FirstScreenSizeSetting.Instance.colorOnoffstop ();


				FirstScreenSizeSetting.Instance.ColorOnoff (top.transform.FindChild ("Ts4").gameObject,
					top.transform.FindChild ("Ts4").GetComponent<Image> ().color.a, 0, 0.3f, "C1", this.gameObject);

				FirstScreenSizeSetting.Instance.ColorOnoff (top.transform.FindChild ("mt").gameObject,
					top.transform.FindChild ("mt").GetComponent<Image> ().color.a, 1, 0.3f, "C1", this.gameObject);
				FirstScreenSizeSetting.Instance.SMoveAtoB (new Vector2 (V.x, sub4.GetComponent<RectTransform> ().anchoredPosition.y), sub4, 0.05f, "M3", this.gameObject, null);
				sub4.transform.FindChild ("wg").FindChild ("x").GetComponent<Image> ().raycastTarget = false;
				if (sub4.transform.FindChild ("wg").GetComponent<RectTransform> ().anchoredPosition.y != wgp) {

					FirstScreenSizeSetting.Instance.ColorOnoff (sub4.transform.FindChild ("dim").gameObject, sub4.transform.FindChild ("dim")
						.GetComponent<Image> ().color.a, 0, 0.3f, "IT4", this.gameObject);
					FirstScreenSizeSetting.Instance.SMoveAtoB (new Vector2 (0, wgp), sub4.transform.FindChild ("wg").gameObject, 0.05f, "IV4", this.gameObject, null);
				}

			}
		} else if (ES == Status.stage4_1) {
			FirstScreenSizeSetting.Instance.dad.Dimoff ();
			ES = Status.stage4;
			close4 ();
		} else if (ES == Status.stage1_1_1) {

			reduce (sub.transform.FindChild("wg").FindChild("mask").gameObject);

	
		} else if (ES == Status.stage4_1_1) {

			reduce (sub4.transform.FindChild("wg").FindChild("mask").gameObject);

		}else {
			StopAllCoroutines ();
	
			transform.parent.FindChild ("bot").gameObject.SetActive (false);
			FirstScreenSizeSetting.Instance.SMoveAtoB (new Vector2 (V.x, 0), this.gameObject, 0.1f, "gohome", this.gameObject, null);
		}

	}
	void gohome(){
		tempsp.Clear ();
		ES = Status.stage0;
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
}
