using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeverDestroy : MonoBehaviour {

	// Use this for initialization
	void Awake() {
		GameObject[] objects = GameObject.FindGameObjectsWithTag("Audio");
		if(objects.Length > 1)
			Destroy(this.gameObject);
		DontDestroyOnLoad(this.gameObject);
	}
}
