using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {


	public void ReloadScene(){
		StartCoroutine (ReloadSceneAsync ());
	}

	IEnumerator ReloadSceneAsync(){
		Debug.Log ("reloading");

		yield return new WaitForSeconds(2.0f);

		SceneManager.LoadScene(gameObject.scene.name);

	}

}
