using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketPart2 : MonoBehaviour {
   
    public AudioSource soundsource;

    public GameObject P1rocket;
    public GameObject P2rocket;
    [SerializeField] private Image Player1part;
    [SerializeField] private Image Player2part;
    Animator anim;
    bool Collectable = true;
    private void Start()
    {
        anim = GetComponent<Animator>();
        soundsource = GetComponent<AudioSource>();

    }

    private void Update()
    {
        Imagechecks();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            if (collision.gameObject.tag == "player1" && P1rocket.GetComponent<P1rocket>().part2 == false && Collectable)
            {
                soundsource.Play();
                Collectable = false;
                P1rocket.GetComponent<P1rocket>().part2 = true;
                anim.SetTrigger("pickup");

                Player1part.enabled = true;
                StartCoroutine(Wait());

        }
        if (collision.gameObject.tag == "player2" && P2rocket.GetComponent<P2rocket>().part2 == false && Collectable)
        {
            soundsource.Play();
            Collectable = false;
                P2rocket.GetComponent<P2rocket>().part2 = true;
                anim.SetTrigger("pickup");

                Player2part.enabled = true;
                StartCoroutine(Wait());

        }



    }


    void Imagechecks()
    {
        if (P1rocket.GetComponent<P1rocket>().part2 == true)
        {
            Player1part.enabled = true;
        }
        if (P1rocket.GetComponent<P1rocket>().part2 == false)
        {
            Player1part.enabled = false;
        }

        if (P2rocket.GetComponent<P2rocket>().part2 == true)
        {
            Player2part.enabled = true;
        }
        if (P2rocket.GetComponent<P2rocket>().part2 == false)
        {
            Player2part.enabled = false;
        }
    }
    IEnumerator Wait()
    {
        //print("startwait");
        yield return new WaitForSeconds(1.0f);
        //print("endwaitwait");
        DestroyObject(gameObject);

    }
}
