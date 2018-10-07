using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {


	private CharacterController controller;

	private float speed = 6.0f;
	private float verticalVelocity = 0.0f;
	private float gravity = 12.0f;

	public GameObject deathEffect;

	private float animationDuration = 3.0f;
	private float startTime;

	private bool isDead = false;

	private Vector3 moveVector;

	void Start () {

		controller = GetComponent<CharacterController> ();
		startTime = Time.time;

	}
	// Update is called once per frame
	void FixedUpdate () {

		if (isDead)
			return;

		if (moveVector.y < -14) {
			Death ();
		}

		if (Time.time - startTime < animationDuration) {
			controller.Move (Vector3.forward * speed * Time.deltaTime);
			return;
		}

		moveVector = Vector3.zero;

		if (controller.isGrounded)
		{
			verticalVelocity = -0.5f;

		} 
		else {

			verticalVelocity -= gravity * Time.deltaTime;

		}
		//x Left Right
		moveVector.x = Input.GetAxisRaw("Horizontal") * speed;

		if (Input.GetMouseButton (0)) {

			// holding click on right side
			if (Input.mousePosition.x > Screen.width / 2) {
				moveVector.x = speed;
			} else {
				moveVector.x = -speed;
			}

		}

		//y Up Down
		moveVector.y = verticalVelocity;

		//z Forward Backward
		moveVector.z = speed;

		controller.Move (moveVector * Time.deltaTime);

		}

	public void SetSpeed (float modifier){


		speed = 6.0f + modifier/2;

	}

	// called upon collision
	private void OnControllerColliderHit( ControllerColliderHit hit ){

		if (hit.gameObject.tag == "Obstacle" ) { // if (hit.point.z > transform.position.z + controller.radius)

			Death ();

		}
	}

	private void Death(){

		Debug.Log ("Death");

		Instantiate(deathEffect, transform.position, transform.rotation);
		Destroy(gameObject);


		isDead = true;

		GetComponent<Score> ().OnDeath ();

	}

}
