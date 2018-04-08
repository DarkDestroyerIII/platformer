using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimatorController : MonoBehaviour {

	void PlatformPressed () {
		GetComponent<Animator> ().SetBool ("on platform?", true);	
	}

	void PlatformUnpressed() {
		GetComponent<Animator> ().SetBool ("on platform?", false);
	}

}
