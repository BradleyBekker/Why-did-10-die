using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1HitboxTop : MonoBehaviour {

	[SerializeField] public GameObject Player1;

	private void OnCollisionEnter2D(Collision2D collision){
		Player1.GetComponent<P1movement>().OnFloor();
	}
}
