using UnityEditor;

public class ImportAutoScript : AssetPostprocessor { public void OnPreprocessModel() { ModelImporter modelImporter = (ModelImporter) assetImporter; 
		modelImporter.globalScale = 1; 
	} 
}
