using UnityEngine;
using UnityEditor;
using System.Collections;

namespace AssetBundles
{
	public class AssetBundlesMenuItems
	{
		const string kSimulationMode = "Assets/AssetBundles/Simulation Mode";
	
		[MenuItem(kSimulationMode)]
		public static void ToggleSimulationMode ()
		{
			AssetBundleManager.SimulateAssetBundleInEditor = !AssetBundleManager.SimulateAssetBundleInEditor;
		}
	
		[MenuItem(kSimulationMode, true)]
		public static bool ToggleSimulationModeValidate ()
		{
			Menu.SetChecked(kSimulationMode, AssetBundleManager.SimulateAssetBundleInEditor);
			return true;
		}
		
		[MenuItem ("Assets/AssetBundles/Build AssetBundles")]
		static public void BuildAssetBundles ()
		{
			BuildScript.BuildAssetBundles();
		}
		[MenuItem("Assets/Build AssetBundle From Selection Android - Track dependencies")]
		static void ExportResourceToAssetBundle()
		{
			string FilePath = EditorUtility.SaveFilePanel("Export Project Data", "", "NewAssetBundle", "unity3d");

			if(FilePath.Length != 0)
			{
				Object[] ProjSelection = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);
				BuildPipeline.BuildAssetBundle(Selection.activeObject, ProjSelection, FilePath
					, BuildAssetBundleOptions.CollectDependencies 
					| BuildAssetBundleOptions.CompleteAssets
					,BuildTarget.Android);     
				Selection.objects = ProjSelection;
			}
		} 
	}
}