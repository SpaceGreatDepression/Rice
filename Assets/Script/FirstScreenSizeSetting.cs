using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class FirstScreenSizeSetting : MonoBehaviour {
//	public GameObject SpnieCanvers;
	public GameObject UiCanvers;
	public GameObject TempCanvers;

	public Vector2 Target;
	public delegate void BackEvent();
	public System.Action EventAction;

	Vector2 BGSize; 

	public float Gap;
	public Vector2 Size;

	public Loding LD;
	public dimanddim dad;
	public void kipbackevent(BackEvent B){
		EventAction = () => B ();
	}

	private static FirstScreenSizeSetting _instance = null;
	public static FirstScreenSizeSetting Instance{
		get{
			if(_instance == null){
				_instance = new FirstScreenSizeSetting();
			}
			return _instance;
		}
	}
	public Vector2 InputMousePosition(){
		Vector2 pos;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponent<Canvas>().transform as RectTransform, Input.mousePosition, GetComponent<Canvas>().worldCamera, out pos);
	//	Debug.Log ("pos1 : " + pos);
//		pos = pos * Gap;
//	//	Debug.Log ("pos2 : " + pos);
//		if (2048f >= local.x) {
//
//			pos = new Vector2 (pos.x * 2048f / local.x, (pos.y) * Yy / local.y);
//		
//	
//		} else {
//			
//			pos = new Vector2 (pos.x *  local.x/2048f, (pos.y) * local.y/Yy);
//
//		}
		pos = new Vector2 (pos.x/local.x,pos.y/local.y);
		return pos;

	}
//	public Vector2 worldtorect(Vector2 v){
//		Vector2 pos;
//		RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponent<Canvas>().transform as RectTransform, v, GetComponent<Canvas>().worldCamera, out pos);
//		return pos;
//	}



	public Vector2 InputMousePosition(int i){
		Vector2 pos;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponent<Canvas>().transform as RectTransform, Input.touches[i].position, GetComponent<Canvas>().worldCamera, out pos);
		pos = new Vector2 (pos.x/local.x,pos.y/local.y);
		return pos;

	}
	public Vector2 InputMousePosition(Touch T){
		Vector2 pos;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponent<Canvas>().transform as RectTransform, T.position, GetComponent<Canvas>().worldCamera, out pos);
	pos = new Vector2 (pos.x/local.x,pos.y/local.y);
		return pos;

	}
 void Awake(){

		Input.multiTouchEnabled = true;
		QualitySettings.vSyncCount =  0; 
		Application.targetFrameRate = 60;
		_instance = this;

		set (GetMainGameViewSize().x,GetMainGameViewSize().y);

		Debug.Log ("gap : " + gap);
		Debug.Log ("GetMainGameViewSize : " + GetMainGameViewSize());

	}

	float Yy = 1536f;
	Vector2 GetMainGameViewSize()
	{

#if UNITY_EDITOR
		System.Type T = System.Type.GetType("UnityEditor.GameView,UnityEditor");
		System.Reflection.MethodInfo GetSizeOfMainGameView = T.GetMethod("GetSizeOfMainGameView",System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
		System.Object Res = GetSizeOfMainGameView.Invoke(null,null);
		return (Vector2)Res;
#else
		return new Vector2(Screen.width,Screen.height);
#endif

	}
	// Use this for initialization
	public float gap;
	//public float GAP = 0;
	public float Ng;
	public Vector3 local;
	public float hh;
	public Vector2 Origin;
	public void set(float W,float H){
		
		//local = new Vector3 (1,1,1);
		Size = new Vector2 (W,H);

		Origin = Size;
		//if (Size.x > 800) {
			Size = new Vector2 (800f,H/W*800f);
	//	}


		local = new Vector3(W/800f,H/(H/W*800f));
		transform.FindChild ("Main").transform.localScale = local;
		transform.GetChild (0).FindChild ("bot").GetComponent<RectTransform> ().anchoredPosition = new Vector2 (-Size.x / 2f,-Size.y/2f);
		/*Vector3 BGLocalScale,LocalScale;

		#if UNITY_EDITOR

		Size = Target;



		Debug.Log(Size.y / Size.x);
		LocalScale = new Vector3 (H/Target.y, H/Target.y, 1);

	
		BGLocalScale = new Vector3 (1,1,1);
		GameObject go = GameObject.Find("BGCanvas");
		BGSize = new Vector2 (0,0);
		float BGLocalscale = 0;
		float BGLocalscale1 = 0;



		for(int i = 0; i<go.transform.childCount;i++){



			go.transform.GetChild (i).GetComponent<RectTransform> ().sizeDelta = new Vector2 (Target.x,Target.y);
		
		
			for(int u = 0; u<go.transform.GetChild(i).childCount;u++){

	
					go.transform.GetChild (i).GetChild(u).GetComponent<RectTransform>().sizeDelta = new Vector2(go.transform.GetChild (i).GetChild (u).GetChild(0).GetComponent<Image> ().preferredWidth,go.transform.GetChild (i).GetChild (u).GetChild(0).GetComponent<Image> ().preferredHeight);
					BGLocalscale = Target.x/
						go.transform.GetChild (i).GetChild(u).GetComponent<RectTransform>().sizeDelta.x;
			
					go.transform.GetChild(i).transform.localScale = LocalScale*BGLocalscale;

						go.transform.GetChild (i).GetChild(u).localScale = new Vector3(1,1,1);
						go.transform.GetChild (i).GetChild(u).GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
					
	
				
		
				
		
			

			}
		}
		if(UiCanvers!=null){

			UiCanvers.transform.GetChild (0).GetComponent<RectTransform> ().sizeDelta = new Vector2 (Target.x,Target.y);

			UiCanvers.transform.GetChild(0).transform.localScale = LocalScale*BGLocalscale;

				UiCanvers.transform.GetChild (0).GetChild(0).transform.localScale= new Vector3(1,1,1);
				UiCanvers.transform.GetChild (0).GetChild(0).GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);

		
		}
		if(TempCanvers!=null){
	
			TempCanvers.transform.GetChild (0).GetComponent<RectTransform> ().sizeDelta = new Vector2 (Target.x,Target.y);

			TempCanvers.transform.GetChild(0).transform.localScale = LocalScale*BGLocalscale;

				TempCanvers.transform.GetChild (0).GetChild(0).GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
				TempCanvers.transform.GetChild (0).GetChild(0).transform.localScale= new Vector3(1,1,1);
			
	
		}

		Gap = Target.x/GetMainGameViewSize().x;
		
		#else


		Debug.Log("Not Edit");
		LocalScale = new Vector3 (1, 1, 1);
		BGLocalScale = new Vector3 (1,1,1);
	
		//		Debug.Log ("W : " + W + ":: H : " + H);
		//		Debug.Log ("Target.x : " + Target.x + ":: Target.y : " + Target.y);
		//		Debug.Log ("W / Target.x : " + W / Target.x);
		//		Debug.Log ("H / Target.y : " + H / Target.y);
		//		Debug.Log ("LocalScale : " + LocalScale);
		GameObject go = GameObject.Find("BGCanvas");



		Vector2 BGSize = new Vector2 (0,0);
		float BGLocalscale = 0;
		float BGLocalscale1 = 0;
		hh = Size.y/Size.x * 2048f;

		Ng = (hh/1339f);


		for(int i = 0; i<go.transform.childCount;i++){


	
		go.transform.GetChild (i).GetComponent<RectTransform> ().sizeDelta = new Vector2 (W,H);


		for(int u = 0; u<go.transform.GetChild(i).childCount;u++){


		go.transform.GetChild (i).GetChild(u).GetComponent<RectTransform>().sizeDelta = new Vector2(go.transform.GetChild (i).GetChild (u).GetChild(0).GetComponent<Image> ().preferredWidth,go.transform.GetChild (i).GetChild (u).GetChild(0).GetComponent<Image> ().preferredHeight);
		BGLocalscale = W/
		go.transform.GetChild (i).GetChild(u).GetComponent<RectTransform>().sizeDelta.x;

		go.transform.GetChild(i).transform.localScale = LocalScale*BGLocalscale;

		go.transform.GetChild (i).GetChild(u).localScale = new Vector3(1,1,1);
		go.transform.GetChild (i).GetChild(u).GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);








		}
		}


		if(UiCanvers!=null){

		UiCanvers.transform.GetChild (0).GetComponent<RectTransform> ().sizeDelta = new Vector2 (W,H);
		UiCanvers.transform.GetChild(0).transform.localScale = LocalScale*BGLocalscale;

		UiCanvers.transform.GetChild (0).GetChild(0).transform.localScale= new Vector3(1,1,1);
		UiCanvers.transform.GetChild (0).GetChild(0).GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);

		}



		if(TempCanvers!=null){
	
		TempCanvers.transform.GetChild (0).GetComponent<RectTransform> ().sizeDelta = new Vector2  (W,H);
		TempCanvers.transform.GetChild(0).transform.localScale = LocalScale*BGLocalscale;



		TempCanvers.transform.GetChild (0).GetChild(0).transform.localScale= new Vector3(1,1,1);
		TempCanvers.transform.GetChild (0).GetChild(0).GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
		}






		//	Gap = Target.x/Size.x;
		//Debug.Log("target.x : " + Target.x);
		//Debug.Log("Size.x : " + Size.x);
		Gap = 1;
		#endif
*/
	
		transform.GetChild (0).FindChild ("MAIN PAGE").GetComponent<Mainpage> ().setting (Size,Origin);
		transform.GetChild (0).FindChild ("BEST PRACTICE").GetComponent<bestpractice> ().setting (Size);
		transform.GetChild (0).FindChild ("BEST WAR").GetComponent<bestwar> ().setting (Size);
		transform.GetChild (0).FindChild ("FUTURE RICE").GetComponent<futurerice> ().setting (Size);
		transform.GetChild (0).FindChild ("Loding").GetComponent<Loding> ().setting (Size);
		transform.GetChild (0).FindChild ("dimanddim").GetComponent<dimanddim> ().setting (Size);

	}
	public Sprite getsprite(string path){
		
		Sprite Sprite1 = Resources.Load<Sprite> (path);
		return Sprite1;
	}
	public void memory(){
		Resources.UnloadUnusedAssets ();
		System.GC.Collect ();
	}
	public void SMoveAtoB(Vector2 B,GameObject T,float speed,string M, GameObject G,object o){
		moveab ab = new moveab ();
		ab.a = T.GetComponent<RectTransform>().anchoredPosition;
		ab.b = B;
		ab.t = T.GetComponent<RectTransform>();
		ab.speed = speed;
		ab.m = M;
		ab.g = G;
		ab.o = o;
		//		a = A;
		//		b = B;
		//		t = T;
		//		m = M;
		//		g = G;
		StartCoroutine ("SmoveAtoB",ab);

	}
	public void Smovestop(){
		StopCoroutine ("SmoveAtoB");
	}
	IEnumerator SmoveAtoB(moveab ab){
		Vector2 a = ab.a;
		Vector2 b = ab.b;
		RectTransform t = ab.t;
		Debug.Log (a + " : " + b);
		string m = ab.m;
		GameObject g = ab.g;
		object o = ab.o;
		GameObject adder = ab.adder;
		//	Debug.Log (((GameObject)o).name);
		t.anchoredPosition = a;
		float times = ab.speed;

		t.anchoredPosition = a;

		Vector2 vel = Vector2.zero;
		Vector2 saverv = Vector2.zero;
		if (adder == null) {

			while (true) {
				saverv = vel;

				t.anchoredPosition = Vector2.SmoothDamp (t.anchoredPosition,b, ref vel, times,9999f,0.02f);
				//Debug.Log (vel);
				if ((Mathf.Abs (vel.x) < 0.2f && Mathf.Abs (vel.y) < 0.2f)||saverv == vel) {
					t.anchoredPosition = b;
					if (o == null) {
						g.SendMessage (m);

					} else {
						g.SendMessage (m, o);
					}
					break;
				} 
				yield return new WaitForFixedUpdate ();

			}

		} else {
			Vector2 saves;
			Vector2 Asave = adder.GetComponent<RectTransform> ().anchoredPosition;
			while (true) {
				saves = t.anchoredPosition;
				saverv = vel;
				t.anchoredPosition = Vector2.SmoothDamp (t.anchoredPosition,b, ref vel, times,9999f,0.02f);
				adder.GetComponent<RectTransform> ().anchoredPosition += t.anchoredPosition - saves;
				//Debug.Log (vel);
				if ((Mathf.Abs (vel.x) < 0.2f && Mathf.Abs (vel.y) < 0.2f)||saverv == vel) {
					t.anchoredPosition = b;
					adder.GetComponent<RectTransform> ().anchoredPosition = Asave + (b - a);
					if (o == null) {
						g.SendMessage (m);

					} else {
						g.SendMessage (m, o);
					}
					break;
				} 
				yield return new WaitForFixedUpdate ();

			}
		}
	}

	public void ColorOnoff(GameObject G,float start,float end,float time,string m,GameObject g){
		Debug.Log (G.name);
		colorm c = new colorm ();
		c.G = G;
		c.start = start;
		c.end = end;
		c.time = time;
		c.m = m;
		c.g = g;
		StartCoroutine ("colorOnoff",c);

	}
	public void colorOnoffstop(){
		StopCoroutine ("colorOnoff");
	}
	IEnumerator colorOnoff(colorm c){
		GameObject G = c.G;

		float start = c.start;
		float end = c.end;
		float time = c.time;
		string m = c.m;
		GameObject g = c.g;
		object o = c.o;
		if (start < end) {
			//G.GetComponent<Image> ().color = new Color (1,1,1,start);
			float gap = end - start;

			float count = time * 50f;
			float num = gap / count;
			for (int i = 0; i < count; i++) {
				G.GetComponent<Image> ().color += new Color (0,0,0,num);
				yield return new WaitForFixedUpdate ();
			}
			if (c.o == null) {
				g.SendMessage (m);
			} else {
				g.SendMessage (m,o);
			}

		} else if(start > end) {
			float gap = start - end;
			float count = time * 50f;
			float num = gap / count;

			for (int i = 0; i < count; i++) {
				G.GetComponent<Image> ().color -= new Color (0,0,0,num);
				yield return new WaitForFixedUpdate ();
			}
			if (c.o == null) {
				g.SendMessage (m);
			} else {
				g.SendMessage (m,o);
			}
		}
	}

	class moveab{
		public Vector2 a;
		public Vector2 b;
		public RectTransform t;
		public float speed;
		public string m;
		public GameObject g;
		public object o;
		public GameObject adder;
		public GameObject adder1;
		public GameObject adder2;

	}
	class colorm{
		public GameObject G;
		public float start;
		public float end;
		public float time;
		public string m;
		public GameObject g;
		public object o;
	}

	void Update()
	{
		//if(Application.platform == RuntimePlatform.Android)
		//{
			if(Input.GetKeyDown(KeyCode.Escape))
			{
			Debug.Log ("esc");

				if (EventAction != null) {
				if (!LD.dim.activeSelf) {
					EventAction ();
				}
				}


			}
		//}
	}
}

