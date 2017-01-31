using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PinchZoomandview : MonoBehaviour
{
	List<Vector2> vl = new List<Vector2>();
	public float perspectiveZoomSpeed = 0.3f;        // The rate of change of the field of view in perspective mode.
	public float orthoZoomSpeed = 0.5f;        // The rate of change of the orthographic size in orthographic mode.
	public RectTransform target;
	public RectTransform mask;

	void Start(){
		
		PinchOn (this.transform);
	}
	Vector2 defultsize;
	Vector2 defultpos;
	Vector2 maxsizes;
	Vector3 defultscale;
	public void PinchOn(Transform t){
		//mesage = m;
		//target = g;
		T = t;
		Pinchboo = true;

	}
	public void pinchoff(){
		Pinchboo = false;
	}
	bool Pinchboo = false;
	string mesage;

	Transform T;
	public Touch touchZero;
	public Touch touchOne;
	void pivotset(){
		if (T != null) {
			vel = FirstScreenSizeSetting.Instance.InputMousePosition ();
			//defultpos = T.GetComponent<RectTransform> ().anchoredPosition;
			defultpos = Vector2.zero;
			defultsize = T.GetComponent<RectTransform> ().sizeDelta;
			defultpos -= new Vector2 (0,60f);
			defultscale = T.localScale;
			maxsizes = new Vector2 (defultscale.x * defultsize.x, defultscale.y * defultsize.y);
			T.GetComponent<RectTransform> ().pivot = new Vector2 (1f-((vel.x - defultpos.x) / maxsizes.x)-0.5f, 1f-((vel.y - defultpos.y) / maxsizes.y)-0.5f);
			T.GetComponent<RectTransform> ().anchoredPosition = defultpos;
			T.GetComponent<RectTransform> ().anchoredPosition -= new Vector2 ((0.5f-T.GetComponent<RectTransform> ().pivot.x*defultsize.x)+defultsize.x/2f,(-T.GetComponent<RectTransform> ().pivot.y*defultsize.y)+defultsize.y/2f-60f);
		}
	}
	bool fist = true;
	void Update()
	{
		//if (Pinchboo) {
			//	Debug.Log ("Input.touchCount : " + Input.touchCount);
		//pivotset ();
		if (Input.touchCount >= 2) {
			if (fist) {
				fist = false;
				pivotset ();
			}
			touchZero = Input.GetTouch (0);
			touchOne = Input.GetTouch (1);


			Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
			Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;


			float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
			float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;


			float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
			 

			//Debug.Log ("deltaMagnitudeDiff * perspectiveZoomSpeed : " + deltaMagnitudeDiff * perspectiveZoomSpeed);
			float result = (deltaMagnitudeDiff * perspectiveZoomSpeed) * -1f;
			if (result != 0) {
				T.localScale += new Vector3 (result * 0.01f, result * 0.01f, 0);
				if (T.localScale.x > 3) {
					T.localScale = new Vector3 (3, 3, 0);
				} else if (T.localScale.x < 1f) {
					T.localScale = new Vector3 (1f, 1f, 0);
				}
			}
			size = true;
			 

		} else if (Imageclick) 
		{
			T.GetComponent<RectTransform> ().pivot = new Vector2 (0.5f,0.5f);
			fist = true;
			if (size) {
				vl.Clear ();
				size = false;
	
	
					#if UNITY_EDITOR
					vel = FirstScreenSizeSetting.Instance.InputMousePosition ();
					#else
				if (Input.GetTouch (0).fingerId == touchZero.fingerId) {
				vel = FirstScreenSizeSetting.Instance.InputMousePosition (0);
				} else {
				vel = FirstScreenSizeSetting.Instance.InputMousePosition (touchOne);
				}
				#endif

			} else {
				
				count++;
				saver = target.anchoredPosition;
				target.anchoredPosition += FirstScreenSizeSetting.Instance.InputMousePosition () - vel;
				//vl.Add((saver - target.anchoredPosition)*-1f);
				//if (vl.Count > 5) {
				//	vl.RemoveAt (0);
				//}
				vel = FirstScreenSizeSetting.Instance.InputMousePosition ();
			}

		} else if(smooth) {
			T.GetComponent<RectTransform> ().pivot = new Vector2 (0.5f,0.5f);
			fist = true;
			target.anchoredPosition = Vector2.SmoothDamp (target.anchoredPosition, gotop, ref velo, 0.1f,9999f,Time.deltaTime);

		}

	}
	Vector2 saver;
	Vector2 velo;
	bool size = false;
	int count = 0;
	bool Imageclick = false;
	bool smooth = false;
	Vector2 vel;
	public void ImageDown(){
		size = true;
			vel = FirstScreenSizeSetting.Instance.InputMousePosition ();

		//pinchoff ();
		Imageclick = true;
	}




	public void ImageUp(){
		#if UNITY_EDITOR
		Imageclick = false;
		checkout ();
		#else
			if (Input.touchCount <= 1) {
				Imageclick = false;
				checkout ();
			}
		#endif

	}
	public Vector2 maxsize(){
		float x = (target.transform.localScale.x - 1f) * (target.GetComponent<RectTransform> ().sizeDelta.x / 2f);
		float y = (target.transform.localScale.y - 1f) * (target.GetComponent<RectTransform> ().sizeDelta.y / 2f);
		return new Vector2 (x,y);
	}
	void checkout(){
		Debug.Log ("checkout");
		Vector2 v = target.GetComponent<RectTransform> ().anchoredPosition;
		Vector2 M = maxsize ();
		Debug.Log ("maxsize : " + M);
		smooth = false;
		if (v.x > M.x || v.x < -M.x || v.y > M.y || v.y < -M.y) {
			smooth = true;
			float x = v.x;
			if (v.x > M.x) {
				x = M.x;
			} else if (v.x < -M.x) {
				x = -M.x;
			}
			float y = v.y;
			if (v.y > M.y) {
				y = M.y;
			} else if (v.y < -M.y) {
				y = -M.y;
			}  
			velo = Vector2.zero;
	
		

			gotop = new Vector2 (x, y);
		} else {
			//smooth = true;
			Debug.Log("saver : " + saver);
			Debug.Log("target.anchoredPosition : " + target.anchoredPosition);
			Vector2 save = (saver - target.anchoredPosition)*-1f;
			save = new Vector2 (save.x *5,save.y*5);
//			Vector2 save = new Vector2(0,0);
//			for (int i = 0; i < vl.Count; i++) {
//				save += vl [i];
//			}
//			Debug.Log (save);
			Debug.Log (save);
			save +=target.anchoredPosition ;
			smooth = true;
			if (save.x > M.x || save.x < -M.x || save.y > M.y || save.y < -M.y) {

				float x = save.x;
				if (save.x > M.x) {
					x = M.x;
				} else if (save.x < -M.x) {
					x = -M.x;
				}
				float y = save.y;
				if (save.y > M.y) {
					y = M.y;
				} else if (save.y < -M.y) {
					y = -M.y;
				}  
				velo = Vector2.zero;



				gotop = new Vector2 (x, y);
				//gotop = save;
			}else{
				gotop = save;
			} 

		
		}
	}

	Vector2 gotop;

}