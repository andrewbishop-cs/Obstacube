using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectCoin : MonoBehaviour {

	public GameObject pickupEffect;


	void OnTriggerEnter (Collider other){

		if ( other.CompareTag("Player")) {

			Pickup(other);
		}


	}
			
	void Pickup(Collider player){

		Debug.Log ("coin collected");

		//spawn effect
		Instantiate(pickupEffect, transform.position, transform.rotation);

		//add to bank


		PlayerPrefs.SetInt ("Coins", (PlayerPrefs.GetInt ("Coins")+1));
		Debug.Log("Total coins: " + PlayerPrefs.GetInt ("Coins"));
		PlayerPrefs.SetInt ("CoinsGame", PlayerPrefs.GetInt ("CoinsGame")+1 );
		Debug.Log("Coins this game: " + PlayerPrefs.GetInt ("CoinsGame"));

		//remove from scene
		Destroy(gameObject);

	}

	
}





