using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DownloadObbExample : MonoBehaviour 
{
	private string expPath;
	private string logtxt;
	private bool alreadyLogged = false;
	private string nextScene = "rice";
	private bool downloadStarted;

	public GameObject pop1,pop2;
	public Text T;
	void Start(){
		DontDestroyOnLoad (this.gameObject);
	}
	void log( string t )
	{
		logtxt += t + "\n";
		print("MYLOG " + t);
	}
	void OnGUI()
	{
		//GUI.Label(new Rect(10, 10, Screen.width-10, 20), "Use GooglePlayDownloader only on Android device!");
		//GUI.skin = mySkin;
	//	GUI.DrawTexture(new Rect(0,0,background.width,background.height),background);

		if (!GooglePlayDownloader.RunningOnAndroid())
		{
			//GUI.Label(new Rect(10, 10, Screen.width-10, 20), "Use GooglePlayDownloader only on Android device!");
			Debug.Log("Use GooglePlayDownloader only on Android device!");
			return;
		}

		expPath = GooglePlayDownloader.GetExpansionFilePath();
		if (expPath == null)
		{
			Debug.Log("External storage is not available!");
			//GUI.Label(new Rect(10, 10, Screen.width-10, 20), "External storage is not available!");
		}
		else
		{
			string mainPath = GooglePlayDownloader.GetMainOBBPath(expPath);
			string patchPath = GooglePlayDownloader.GetPatchOBBPath(expPath);
			if( alreadyLogged == false )
			{
				alreadyLogged = true;
				Debug.Log( "expPath = "  + expPath );
				Debug.Log( "Main = "  + mainPath );
		//		Debug.Log( "Main = " + mainPath.Substring(expPath.Length));

				if (mainPath != null) {
					if (Caching.spaceOccupied < 600000000) {
						StartCoroutine(loadLevel());
					} else {
						Application.LoadLevel (nextScene);
					}					//Application.LoadLevel(nextScene);
				//	StartCoroutine (loadLevel ());
				}

			}
			//GUI.Label(new Rect(10, 10, Screen.width-10, Screen.height-10), logtxt );

			if (mainPath == null)
			{
				pop1.SetActive (true);

			}

		}


	}
	//string[] ssl = {"01_01_school01","01_01_school02","01_01_school03","01_02_school01","01_02_school02","01_02_school03","01_02_school04","01_02_school05","01_03_school01","01_03_school02","02_01","02_04","03_01"};
	string[] ssl = {"01_01_school01","01_01_school02","01_01_school03","01_02_school01","01_02_school02","01_02_school03","01_02_school04","01_02_school05","01_03_school01","01_03_school02","02_01","02_04","03_01"};
	public void pop1ok(){
		pop1.transform.GetChild (0).gameObject.SetActive (false);
		pop1.transform.GetChild (1).gameObject.SetActive (false);
		pop1.GetComponent<Image> ().color = new Color (1,1,1,0);
			Debug.Log("Start Download !");
			GooglePlayDownloader.FetchOBB();
			StartCoroutine(loadLevel());

	}
	public void pop2c(){
		Application.Quit ();	
	}
	WWW www;
	float maxc = 0;
	float nowc = 0;
	protected IEnumerator loadLevel() 
	{ 

		if (pop2 != null) {
			pop2.SetActive (true);
		}
		maxc = (float)ssl.Length;
	
		//comp
		string mainPath = GooglePlayDownloader.GetMainOBBPath(expPath);
				for(int i = 0 ; i < ssl.Length;i++){
				//	Debug.Log (ssl[i]);
		


			string uri = string.Empty;
			uri = "jar:file://" + mainPath + "!/"+ssl[i];
					//uri =  "file://Users/choi-Yfactory/Rice/AssetBundles/Android/" + strItemName;
					Debug.Log("downloading " + uri);
		www = WWW.LoadFromCacheOrDownload(uri, 0);

					// Wait for download to complete
					pro = www.progress;
					yield return www;

					if (www.error != null)
					{
						Debug.Log("wwww error " + www.error);
					}
					else
					{
						AssetBundle assetBundle = www.assetBundle;
				assetBundle.LoadAllAssets ();

						assetBundle.Unload(false);

				Resources.UnloadUnusedAssets ();
				System.GC.Collect ();
				nowc += 1;
					}


			yield return null;


				}
		www.Dispose();
				Application.LoadLevel (nextScene);
				Destroy (this.gameObject);
			

	}
	float pro = 0;
	void Update () {
		if (Application.loadedLevelName == "index") {
	
//				float num = maxc / ((float)ssl.Length + 1f);
//				T.text = ((int)((pro * 100f/((float)ssl.Length + 1f))+num)).ToString () + "%";
			if (www != null && www.isDone == false){
				T.text =  (int)((www.progress * 100f/(maxc))+((nowc/maxc)*100f)) + "%";
			}

		}
	}
}