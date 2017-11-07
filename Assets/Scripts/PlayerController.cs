using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	public float playerVelocity = 10f;
	public float jumpSpeed = 10f;

	// Update is called once per frame
	void Start()
	{
		rb = GetComponent <Rigidbody> ();
	}


	void FixedUpdate () {
		//se não tem rigidebody, usar o update
		//se tiver fisica, usar o fixeupdate
		//usar o deltaTime para fazer o moviento ser em metros/segundo
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		float jump = 0f;

		if (Input.GetButtonDown ("Jump")) 
		{
			jump = jumpSpeed;
		}

		Vector3 moviment = new Vector3 (moveHorizontal, jump, moveVertical) * playerVelocity;
		rb.AddForce (moviment);
	}

	public bool destroy = false;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("PickUp")) 
		{
			other.gameObject.SetActive (false);
		}
	}

}
