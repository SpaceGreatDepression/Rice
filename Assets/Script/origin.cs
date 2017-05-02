using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class origin : MonoBehaviour {
//	public GameObject SpnieCanvers;


	public Vector2 Target;

	Vector2 BGSize; 

	public float Gap;
	public Vector2 Size;


	public GameObject Bg,top,obot;


 void Awake(){
		
		Debug.Log ("Caching.enabled : " + Caching.enabled);
	//	Caching.enabled = true;
		Caching.maximumAvailableDiskSpace = (long)4048*(long)1024*(long)1024;
		Debug.Log ("Caching.ready : " + Caching.ready);
		Debug.Log ("Caching.spaceFree : " + Caching.spaceFree);
		Debug.Log ("Caching.spaceOccupied : " + Caching.spaceOccupied);
		//Application.LoadLevel("rice");
		set (GetMainGameViewSize().x,GetMainGameViewSize().y);



	}


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

	public Vector3 local;

	public Vector2 Origin;
	public void set(float W,float H){
		
		//local = new Vector3 (1,1,1);
		Size = new Vector2 (W, H);

		Origin = Size;
		//if (Size.x > 800) {
		Size = new Vector2 (800f, H / W * 800f);
		//	}


		local = new Vector3 (W / 800f, H / (H / W * 800f));


		//		float ygap = 30+ (((V.y - 1140f) / 480f)*70f);
		//		if (ygap < 30) {
		//			ygap = 30;
		//		}
		Vector2 V = Size;
		Vector2 Ori = Origin;
		transform.FindChild ("Main").transform.localScale = local;
		Bg.GetComponent<RectTransform> ().sizeDelta = new Vector2(V.x,V.x*1920f/1080f);
		top.GetComponent<RectTransform> ().sizeDelta = new Vector2 (V.x,14f);

		top.GetComponent<RectTransform> ().sizeDelta -= new Vector2 (0,((4f/3f)-(Ori.y/Ori.x))*(74f/((16f/9f)-(4f/3f))));
		Bg.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0,(-(Bg.GetComponent<RectTransform> ().sizeDelta.y-V.y)/2f)+88f-top.GetComponent<RectTransform> ().sizeDelta.y);
		top.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0,V.y/2f);
		top.transform.GetChild (0).GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0,-50);
		top.transform.GetChild (0).GetComponent<RectTransform> ().anchoredPosition += new Vector2 (0,((4f/3f)-(Ori.y/Ori.x))*(23/((16f/9f)-(4f/3f))));
		obot.GetComponent<RectTransform> ().anchoredPosition = new Vector2 ((V.x/2f)-23f,(V.y/-2f)+22f);
	}

}

