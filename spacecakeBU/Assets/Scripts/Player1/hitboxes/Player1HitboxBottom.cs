using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1HitboxBottom : MonoBehaviour {

	[SerializeField] public GameObject Player1;

	private void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.tag == "ground")
        {
            Player1.GetComponent<P1movement>().OnGround();
        }
        if(collision.gameObject.tag == "floor")
        {
            Player1.GetComponent<P1movement>().OnFloor();
        }
	}
}
