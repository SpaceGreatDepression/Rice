using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Mainpage : MonoBehaviour {

	public GameObject Bg,mid,bot,top,obot,popup;
	public GameObject bp,bw,br;
	float topgap = 0;
	Vector2 V = new Vector2(0,0);
	Vector2 Ori = new Vector2(0,0);
	IEnumerator Start(){
		yield return new WaitForSeconds (2f);
		while (true) {
			for (int i = 0; i < mid.transform.childCount; i++) {
				mid.transform.GetChild (i).GetComponent<Image> ().color += new Color (0,0,0,0.02f);
			}
			if (mid.transform.GetChild (0).GetComponent<Image> ().color.a >= 1) {
				for (int i = 0; i < mid.transform.childCount; i++) {
					mid.transform.GetChild (i).GetComponent<Image> ().color = new Color (1,1,1,1);
					mid.transform.GetChild (i).GetComponent<Image> ().raycastTarget = true;
				}
				break;
			}
			yield return new WaitForFixedUpdate ();
		}
	}
	void Awake2(){

		if (V.x == 0) {
			V = FirstScreenSizeSetting.Instance.Size;
		}
		if (Ori.x == 0) {
			Ori = FirstScreenSizeSetting.Instance.Origin;
		}
		Bg.GetComponent<RectTransform> ().sizeDelta = new Vector2(V.x,V.x*1920f/1080f);

//		float ygap = 30+ (((V.y - 1140f) / 480f)*70f);
//		if (ygap < 30) {
//			ygap = 30;
//		}

		top.GetComponent<RectTransform> ().sizeDelta = new Vector2 (V.x,14f);

		top.GetComponent<RectTransform> ().sizeDelta -= new Vector2 (0,((4f/3f)-(Ori.y/Ori.x))*(74f/((16f/9f)-(4f/3f))));
		Bg.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0,(-(Bg.GetComponent<RectTransform> ().sizeDelta.y-V.y)/2f)+88f-top.GetComponent<RectTransform> ().sizeDelta.y);
		top.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0,V.y/2f);
		top.transform.GetChild (0).GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0,-50);
		top.transform.GetChild (0).GetComponent<RectTransform> ().anchoredPosition += new Vector2 (0,((4f/3f)-(Ori.y/Ori.x))*(23/((16f/9f)-(4f/3f))));
		obot.GetComponent<RectTransform> ().anchoredPosition = new Vector2 ((V.x/2f)-23f,(V.y/-2f)+22f);
		mid.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, -90f);
		popup.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0,-(V.y/2f)+58f);
		bp.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (V.x,0);
		bw.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (V.x,0);
		br.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (V.x,0);
		bot.transform.localScale = new Vector3 (0.7f,0.7f,1f);
		bot.transform.localScale -=  new Vector3 (((4f/3f)-(Ori.y/Ori.x))*(0.3f/((16f/9f)-(4f/3f))),((4f/3f)-(Ori.y/Ori.x))*(0.3f/((16f/9f)-(4f/3f))),0);
		FirstScreenSizeSetting.Instance.kipbackevent (
			close);
	}

	public void setting(Vector2 v,Vector2 o){
		V = v;
		Ori = o;
		Awake2 ();
	}
	public void stage1(){
		FirstScreenSizeSetting.Instance.dad.Dimon ();
		bot.SetActive (true);
		mid.transform.GetChild (0).GetComponent<Image> ().raycastTarget = false;
		mid.transform.GetChild (1).GetComponent<Image> ().raycastTarget = false;
		mid.transform.GetChild (2).GetComponent<Image> ().raycastTarget = false;
		bp.SetActive (true);
		FirstScreenSizeSetting.Instance.SMoveAtoB (new Vector2(0,0),bp,0.1f,"M1",this.gameObject,null);
		StopCoroutine ("popupon");
		popup.GetComponent<Image> ().color = new Color (1,1,1,0);
		modeq = false;
	}
	public void stage2(){
		FirstScreenSizeSetting.Instance.dad.Dimon ();
		bot.SetActive (true);
		mid.transform.GetChild (0).GetComponent<Image> ().raycastTarget = false;
		mid.transform.GetChild (1).GetComponent<Image> ().raycastTarget = false;
		mid.transform.GetChild (2).GetComponent<Image> ().raycastTarget = false;
		bw.SetActive (true);
		FirstScreenSizeSetting.Instance.SMoveAtoB (new Vector2(0,0),bw,0.1f,"M2",this.gameObject,null);
		StopCoroutine ("popupon");
		popup.GetComponent<Image> ().color = new Color (1,1,1,0);
		modeq = false;
	}
	public void stage3(){
		FirstScreenSizeSetting.Instance.dad.Dimon ();
		bot.SetActive (true);
		mid.transform.GetChild (0).GetComponent<Image> ().raycastTarget = false;
		mid.transform.GetChild (1).GetComponent<Image> ().raycastTarget = false;
		mid.transform.GetChild (2).GetComponent<Image> ().raycastTarget = false;
		br.SetActive (true);
		FirstScreenSizeSetting.Instance.SMoveAtoB (new Vector2(0,0),br,0.1f,"M3",this.gameObject,null);
		StopCoroutine ("popupon");
		popup.GetComponent<Image> ().color = new Color (1,1,1,0);
		modeq = false;
	}
	void M1(){
		FirstScreenSizeSetting.Instance.dad.Dimoff ();
		mid.transform.GetChild (0).GetComponent<Image> ().raycastTarget = true;
		mid.transform.GetChild (1).GetComponent<Image> ().raycastTarget = true;
		mid.transform.GetChild (2).GetComponent<Image> ().raycastTarget = true;
		FirstScreenSizeSetting.Instance.kipbackevent (
			transform.parent.FindChild ("BEST PRACTICE").GetComponent<bestpractice> ().back);


	}
	void M2(){
		FirstScreenSizeSetting.Instance.dad.Dimoff ();
		mid.transform.GetChild (0).GetComponent<Image> ().raycastTarget = true;
		mid.transform.GetChild (1).GetComponent<Image> ().raycastTarget = true;
		mid.transform.GetChild (2).GetComponent<Image> ().raycastTarget = true;
		FirstScreenSizeSetting.Instance.kipbackevent (
			transform.parent.FindChild ("BEST WAR").GetComponent<bestwar> ().back);
	}
	void M3(){
		FirstScreenSizeSetting.Instance.dad.Dimoff ();
		mid.transform.GetChild (0).GetComponent<Image> ().raycastTarget = true;
		mid.transform.GetChild (1).GetComponent<Image> ().raycastTarget = true;
		mid.transform.GetChild (2).GetComponent<Image> ().raycastTarget = true;
		FirstScreenSizeSetting.Instance.kipbackevent (
			transform.parent.FindChild ("FUTURE RICE").GetComponent<futurerice> ().back);
	}

	public void close(){
		if (modeq) {
			Application.Quit ();
		} else {
			StopCoroutine ("popupon");
			StartCoroutine ("popupon");
		}

	}
	bool modeq = false;
	IEnumerator popupon(){
		modeq = true;
		for (float i = 0; i < 1; i+=0.1f) {
			popup.GetComponent<Image> ().color = new Color (1,1,1,i);
			yield return new WaitForSeconds (0.05f);
		}
		popup.GetComponent<Image> ().color = new Color (1,1,1,1);
		yield return new WaitForSeconds (3f);

		for (float i = 1; i >= 0; i-=0.05f) {
			popup.GetComponent<Image> ().color = new Color (1,1,1,i);
			yield return new WaitForSeconds (0.05f);
		}
		popup.GetComponent<Image> ().color = new Color (1,1,1,0);
		modeq = false;
	}
}
