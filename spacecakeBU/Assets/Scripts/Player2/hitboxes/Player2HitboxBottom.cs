using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2HitboxBottom : MonoBehaviour {

	[SerializeField] public GameObject Player2;

	private void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.gameObject.tag == "ground") 
        {
            Player2.GetComponent<P2movement>().OnGround();
        }
        if(collision.gameObject.tag == "floor")
        {
            Player2.GetComponent<P2movement>().OnFloor();
        }
	}
}
