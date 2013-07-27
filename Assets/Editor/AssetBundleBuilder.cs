using UnityEditor;
using UnityEngine;
using System.IO;

public class AssetBundleBuilder {

	[MenuItem ("CustomTools/AssetBundleBuilder/Scene")]
	static void ExportScene(){
		string pathSceneFileName = EditorUtility.OpenFilePanel("Build Scene", "Assets", "unity");
		Debug.Log(pathSceneFileName);
		if (pathSceneFileName.Length == 0) {
			EditorUtility.DisplayDialog("AssetBundleBuilder", "Choice Scene File", "OK");
			return;
		}
		string sceneFileName = Path.GetFileNameWithoutExtension(pathSceneFileName);
		Debug.Log(sceneFileName);
		string assetBundleFileName = EditorUtility.SaveFilePanel("Save AssetBundle", "", sceneFileName, "unity3d");
		if (assetBundleFileName.Length == 0) {
			EditorUtility.DisplayDialog("AssetBundleBuilder", "Input AssetBundle File Name", "OK");
			return;
		}
		string[] levels = new string[] {pathSceneFileName};
		string errorMessage = BuildPipeline.BuildStreamedSceneAssetBundle(levels, assetBundleFileName, BuildTarget.WebPlayer);
		if (errorMessage.Length == 0) {
			EditorUtility.DisplayDialog("AssetBundleBuilder", "Build Success!", "OK");
		} else {
			EditorUtility.DisplayDialog("AssetBundleBuilder", errorMessage, "OK");
		}
	}
}
