using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollider : MonoBehaviour {

	public GameObject testQuad;


	void OnTriggerEnter2D(Collider2D other){
		testQuad.SendMessage("PlatformPressed");
	}

	void OnTriggerExit2D(Collider2D other) {
		testQuad.SendMessage("PlatformUnpressed");
	}

}
