
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {


	public GameObject[] tilePrefabs;
	public GameObject[] bottom;

	private Transform playerTransform;
	private float spawnZ = -10.0f;
	private float spawnBotZ = -10.0f;
	private float tileLength = 10.0f;



	//public void updateRD(float RD){

	//amnTilesOnScreen = (int)RD;

	//}

	private float safeZone = 15.0f; 
	private int lastPrefabIndex = 0;

	private List<GameObject> activeTiles;
	private List<GameObject> activeBottom;



	// Use this for initialization
	private void Start () {

		//blocks = (int)PlayerPrefs.GetFloat ("RD");

		//amnTilesOnScreen = ((int)PlayerPrefs.GetFloat("RD"));

		activeTiles = new List<GameObject> ();
		activeBottom = new List<GameObject> ();

		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;

		for (int i = 0; i < (int)PlayerPrefs.GetFloat ("RD"); i++) { // for (int i = 0; i < amnTilesOnScreen+1; i++) {  ** REPLACING (int)PlayerPrefs.GetFloat("RD") with BLOCKS

			int test = PlayerPrefs.GetInt ("Bottom");

			if (i < 4) {
				SpawnTile (0);

				if (test == 1 )
					SpawnBottom ();
			} else {
				SpawnTile ();
				if (test == 1 )
					SpawnBottom ();
			}




		}

	}



	// Update is called once per frame
	private void Update () {

		//blocks = (int)PlayerPrefs.GetFloat ("RD");

		if (playerTransform.position.z -safeZone > (spawnZ - PlayerPrefs.GetFloat ("RD") * tileLength)) { //** REPLACING (int)PlayerPrefs.GetFloat("RD") with BLOCKS

			SpawnTile ();

			int test = PlayerPrefs.GetInt ("Bottom");

			if (test == 1 )
				SpawnBottom ();

			DeleteTile ();

		}




	}

	private void SpawnTile ( int prefabIndex = -1 ){


		GameObject go;

		if (prefabIndex == -1 )
			go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;

		else
			go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;

		go.transform.SetParent (transform);	
		go.transform.position = Vector3.forward * spawnZ;
		spawnZ += tileLength;

		activeTiles.Add (go);

	}

	private void SpawnBottom(){

		GameObject bo;

		bo = Instantiate(bottom[0]) as GameObject;

		bo.transform.SetParent (transform);	
		bo.transform.position = Vector3.forward * spawnBotZ;
		spawnBotZ += tileLength;

		activeBottom.Add (bo);


	}


	private void DeleteTile(){

		Destroy (activeTiles [0]);
		activeTiles.RemoveAt (0);

		int test = PlayerPrefs.GetInt ("Bottom");

		if (test == 1 ){

			Destroy (activeBottom [0]);
			activeBottom.RemoveAt (0);

		}

	}


	private int RandomPrefabIndex (){

		if (tilePrefabs.Length <= 1)
			return 0;


		int randomIndex = lastPrefabIndex;
		while (randomIndex == lastPrefabIndex) {

			randomIndex = Random.Range (0, tilePrefabs.Length);

		}

		lastPrefabIndex = randomIndex;
		return randomIndex;

	}

}


/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {


	public GameObject[] tilePrefabs;

	private Transform playerTransform;
	private float spawnZ = -10.0f;
	private float tileLength = 10.0f;



	int amnTilesOnScreen = 7; // RENDER DISTANCE OPTION 

	
	//public void updateRD(float RD){

		//amnTilesOnScreen = (int)RD;

	//}

	private float safeZone = 15.0f; 
	private int lastPrefabIndex = 0;

	private List<GameObject> activeTiles;

	int blocks = 7;


	// Use this for initialization
	private void Start () {

	//blocks = (int)PlayerPrefs.GetFloat ("RD");

	//amnTilesOnScreen = ((int)PlayerPrefs.GetFloat("RD"));

		activeTiles = new List<GameObject> ();

		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;

		for (int i = 0; i < (int)PlayerPrefs.GetFloat ("RD"); i++) { // for (int i = 0; i < amnTilesOnScreen+1; i++) {  ** REPLACING (int)PlayerPrefs.GetFloat("RD") with BLOCKS

			if ( i < 4 )
				SpawnTile (0);

			else
				SpawnTile ();





		}

	}



// Update is called once per frame
	private void Update () {

	//blocks = (int)PlayerPrefs.GetFloat ("RD");

		if (playerTransform.position.z -safeZone > (spawnZ - PlayerPrefs.GetFloat ("RD") * tileLength)) { //** REPLACING (int)PlayerPrefs.GetFloat("RD") with BLOCKS

			SpawnTile ();
			SpawnBottom();

			DeleteTile ();

		}




	}

	private void SpawnTile ( int prefabIndex = -1 ){


		GameObject go;
	
		if (prefabIndex == -1 )
			go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
	
		else
			go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
	
		go.transform.SetParent (transform);	
		go.transform.position = Vector3.forward * spawnZ;
		spawnZ += tileLength;
	
		activeTiles.Add (go);
	
	}
	
	private void DeleteTile(){
	
		Destroy (activeTiles [0]);
		activeTiles.RemoveAt (0);
	
	}
	
	
	private int RandomPrefabIndex (){
	
		if (tilePrefabs.Length <= 1)
			return 0;
	
	
		int randomIndex = lastPrefabIndex;
		while (randomIndex == lastPrefabIndex) {
	
			randomIndex = Random.Range (0, tilePrefabs.Length);

		}

		lastPrefabIndex = randomIndex;
		return randomIndex;

	}

}

*/

