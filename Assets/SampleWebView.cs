/*
 * Copyright (C) 2012 GREE, Inc.
 * 
 * This software is provided 'as-is', without any express or implied
 * warranty.  In no event will the authors be held liable for any damages
 * arising from the use of this software.
 * 
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 * 
 * 1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would be
 *    appreciated but is not required.
 * 2. Altered source versions must be plainly marked as such, and must not be
 *    misrepresented as being the original software.
 * 3. This notice may not be removed or altered from any source distribution.
 */

using System.Collections;
using UnityEngine;

public class SampleWebView : MonoBehaviour
{
    public string Url;
	public string status;
	WebViewObject webViewObject;


	delegate void BackEvent();
	void comp(){
		Debug.Log ("lodeon");
	}
	public void View(string url){
		saver = FirstScreenSizeSetting.Instance.EventAction;

		FirstScreenSizeSetting.Instance.kipbackevent (backbutton);
		Url = url;
		StartCoroutine ("Starts");
	}
	public void close(){
		StopCoroutine ("Starts");

		StartCoroutine ("closeweb");
	}
	Vector2 V; 
    IEnumerator Starts()
    {




		V = FirstScreenSizeSetting.Instance.Origin;
        webViewObject = (new GameObject("WebViewObject")).AddComponent<WebViewObject>();

        webViewObject.Init(
            cb: (msg) =>
            {
                Debug.Log(string.Format("CallFromJS[{0}]", msg));
				msg = status;
       
            },
            err: (msg) =>
            {
                Debug.Log(string.Format("CallOnError[{0}]", msg));
				msg = status;

            },
            ld: (msg) =>
            {
                Debug.Log(string.Format("CallOnLoaded[{0}]", msg));
				msg = status;
#if !UNITY_ANDROID
                webViewObject.EvaluateJS(@"
                  window.Unity = {
                    call: function(msg) {
                      var iframe = document.createElement('IFRAME');
                      iframe.setAttribute('src', 'unity:' + msg);
                      document.documentElement.appendChild(iframe);
                      iframe.parentNode.removeChild(iframe);
                      iframe = null;
                    }
                  }
                ");
#endif
            },
            enableWKWebView: true);
		int Y = (int)(120f * FirstScreenSizeSetting.Instance.local.y);
		webViewObject.SetMargins((int)V.x, Y, 0, 0);
	//	webViewObject.SetMargins(5, 100, 5, Screen.height / 4);
        webViewObject.SetVisibility(true);


#if !UNITY_WEBPLAYER
        if (Url.StartsWith("http")) {
            webViewObject.LoadURL(Url.Replace(" ", "%20"));
        } else {
            var exts = new string[]{
                ".jpg",
                ".html"  // should be last
            };
            foreach (var ext in exts) {
                var url = Url.Replace(".html", ext);
                var src = System.IO.Path.Combine(Application.streamingAssetsPath, url);
                var dst = System.IO.Path.Combine(Application.persistentDataPath, url);
                byte[] result = null;
                if (src.Contains("://")) {  // for Android
                    var www = new WWW(src);
                    yield return www;
                    result = www.bytes;
                } else {
                    result = System.IO.File.ReadAllBytes(src);
                }
                System.IO.File.WriteAllBytes(dst, result);
                if (ext == ".html") {
                    webViewObject.LoadURL("file://" + dst.Replace(" ", "%20"));
                    break;
                }
            }
        }
#else
        if (Url.StartsWith("http")) {
            webViewObject.LoadURL(Url.Replace(" ", "%20"));
        } else {
            webViewObject.LoadURL("StreamingAssets/" + Url.Replace(" ", "%20"));
        }
        webViewObject.EvaluateJS(
            "parent.$(function() {" +
            "   window.Unity = {" +
            "       call:function(msg) {" +
            "           parent.unityWebView.sendMessage('WebViewObject', msg)" +
            "       }" +
            "   };" +
            "});");
#endif
		float Vec = V.x;
		float f=0;
		while (true) {
			Vec = Mathf.SmoothDamp (Vec,0,ref f,0.1f);
			webViewObject.SetMargins((int)Vec, Y, 0, 0);
			vv = Vec;
			if (Mathf.Abs (f) < 0.3f) {
				webViewObject.SetMargins(0, Y, 0, 0);
				vv = 0;
				break;
			}
			yield return new WaitForFixedUpdate ();
		}
        yield break;
    }
	System.Action saver;
	void backbutton(){
		if (webViewObject.CanGoBack ()) {
			webViewObject.GoBack ();
		} else {
			FirstScreenSizeSetting.Instance.EventAction = saver;
			FirstScreenSizeSetting.Instance.EventAction ();
	
		}
	}
	float vv=0;
#if !UNITY_WEBPLAYER
//    void OnGUI()
//    {
//        GUI.enabled = webViewObject.CanGoBack();
//        if (GUI.Button(new Rect(10, 10, 80, 80), "<")) {
//            webViewObject.GoBack();
//        }
//        GUI.enabled = true;
//
//        GUI.enabled = webViewObject.CanGoForward();
//        if (GUI.Button(new Rect(100, 10, 80, 80), ">")) {
//            webViewObject.GoForward();
//        }
//        GUI.enabled = true;
//    }
#endif
	IEnumerator closeweb(){
		float Vec = vv;
		float f=0;
		int Y = (int)(120f * FirstScreenSizeSetting.Instance.local.y);
		while (true) {
			Vec = Mathf.SmoothDamp (Vec,V.x,ref f,0.1f);
			webViewObject.SetMargins((int)Vec, Y, 0, 0);
			if (Mathf.Abs (f) < 0.3f) {
				webViewObject.SetMargins((int)V.x, Y, 0, 0);
				break;
			}
			yield return new WaitForFixedUpdate ();
		}
		webViewObject.SetVisibility (false);
		FirstScreenSizeSetting.Instance.dad.Dimoff ();
		Destroy (webViewObject.gameObject);
	}

	public void volup(){
		
	}
}
