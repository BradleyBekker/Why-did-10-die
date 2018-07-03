using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {
    public float timer = 0;
    public int scenenumber = 0;

	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            SceneManager.LoadScene(scenenumber);

        }
    }
}
