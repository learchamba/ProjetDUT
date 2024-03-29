﻿using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO ;  

[CustomEditor(typeof(Grid))]
public class GridEditor : Editor {

	Grid grid;
	private int oldIndex;

	void OnEnable(){
		oldIndex = 0;
		grid = (Grid)target;
	}

	[MenuItem("Assets/Create/TileSet")]
	static void CreateTileSet(){;
		var asset = ScriptableObject.CreateInstance<TileSet>();
		var path = AssetDatabase.GetAssetPath(Selection.activeObject);

		if(string.IsNullOrEmpty(path)){
			path="Assets";
		}else if (Path.GetExtension(path) != ""){
			path = path.Replace(Path.GetFileName(path),"");
		}else{
			path += "/";
		}

		var assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + "TileSet.asset");
		AssetDatabase.CreateAsset(asset,assetPathAndName);
		AssetDatabase.SaveAssets();
		EditorUtility.FocusProjectWindow();
		Selection.activeObject = asset;
		asset.hideFlags = HideFlags.DontSave;
	}
	public override void OnInspectorGUI(){

		EditorGUI.BeginChangeCheck();
		var newTilePrefab = (Transform)EditorGUILayout.ObjectField("Tile Prefab", grid.tilePrefab,typeof(Transform),false);
		if (EditorGUI.EndChangeCheck()){
			grid.tilePrefab = newTilePrefab;
			Undo.RecordObject(target,"Grid Changed");
		}

		EditorGUI.BeginChangeCheck();
		var newTileSet = (TileSet)EditorGUILayout.ObjectField("TileSet", grid.tileSet ,typeof(TileSet),false);
		if (EditorGUI.EndChangeCheck()){
			grid.tileSet = newTileSet;
			Undo.RecordObject(target,"Grid Changed");
		}

		if (grid.tileSet != null){
			EditorGUI.BeginChangeCheck();
			var names = new string[grid.tileSet.prefabs.Length];
			var values = new int[names.Length];

			for (int i = 0; i< names.Length; i++){
				names[i] = grid.tileSet.prefabs[i] != null ? grid.tileSet.prefabs[i].name : "";
				values[i] = i ;
			}

			var index = EditorGUILayout.IntPopup("Select Tile",oldIndex,names,values);

			if(EditorGUI.EndChangeCheck()){
				Undo.RecordObject(target,"Grid Changed");
				if (oldIndex != index){
					oldIndex = index ;
					grid.tilePrefab = grid.tileSet.prefabs[index];

					float width = grid.tilePrefab.GetComponent<Renderer>().bounds.size.x; 
					float height = grid.tilePrefab.GetComponent<Renderer>().bounds.size.y;

				}
			}
		}

	}

	void OnSceneGUI(){
		int controlld = GUIUtility.GetControlID(FocusType.Passive);
		Event e = Event.current;
		Ray ray = Camera.current.ScreenPointToRay(new Vector3(e.mousePosition.x, -e.mousePosition.y + Camera.current.pixelHeight));
		Vector3 mousePos = ray.origin ;

		if (e.isMouse && e.type == EventType.MouseDown){
			GUIUtility.hotControl = controlld;
			e.Use();

			GameObject gameObject;
			Transform prefab = grid.tilePrefab;

			if (prefab){
				Undo.IncrementCurrentGroup();
				gameObject = (GameObject)PrefabUtility.InstantiatePrefab(prefab.gameObject);
				Vector3 aligned = new Vector3(Mathf.Floor(mousePos.x +0.5f), Mathf.Floor(mousePos.y +0.5f), 0.0f);
				gameObject.transform.position = aligned ;
				gameObject.transform.parent = grid.transform;
				Undo.RegisterCreatedObjectUndo(gameObject,"Creat"+ gameObject.name);
			}
		}
	}

}

















