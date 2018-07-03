using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2HitboxTop : MonoBehaviour {

	[SerializeField] public GameObject Player2;

	private void OnCollisionEnter2D(Collision2D collision){
		Player2.GetComponent<P2movement>().OnFloor();
	}
}
