using UnityEngine;
using System.Collections;
using UnityEditor;
[CustomEditor(typeof(FirstScreenSizeSetting))]
public class Resize : Editor {

	public override void OnInspectorGUI()
		
	{
		FirstScreenSizeSetting T = target as FirstScreenSizeSetting;  
		base.DrawDefaultInspector();
		if (GUILayout.Button ("ResizeButten")) {
		
		

			T.set(GetMainGameViewSize().x,GetMainGameViewSize().y);		
		}
		
	}
	Vector2 GetMainGameViewSize()
	{
		System.Type T = System.Type.GetType("UnityEditor.GameView,UnityEditor");
		    System.Reflection.MethodInfo GetSizeOfMainGameView = T.GetMethod("GetSizeOfMainGameView",System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
		System.Object Res = GetSizeOfMainGameView.Invoke(null,null);
		return (Vector2)Res;
	}

}

