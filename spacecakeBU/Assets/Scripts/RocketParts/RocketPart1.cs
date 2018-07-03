using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketPart1 : MonoBehaviour {
    public AudioClip clip;
    public AudioSource soundsource;



    public GameObject P1rocket;
    public GameObject P2rocket;
    [SerializeField] private Image Player1part;
    [SerializeField] private Image Player2part;
    Animator anim;
    bool Collectable = true;
    private void Start()
    {
        soundsource.clip = clip;
        anim = GetComponent<Animator>();

    }
    private void Update()
    {
        Imagechecks();


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player1" && P1rocket.GetComponent<P1rocket>().part1 == false && Collectable)
        {
            soundsource.Play();
            Collectable = false;
            anim.SetTrigger("pickup");
            P1rocket.GetComponent<P1rocket>().part1 = true;
            Player1part.enabled = true;
            StartCoroutine(Wait());
        }
        if (collision.gameObject.tag == "player2" && P2rocket.GetComponent<P2rocket>().part1 == false && Collectable)
        {
            soundsource.Play();
            Collectable = false;
            anim.SetTrigger("pickup");
            P2rocket.GetComponent<P2rocket>().part1 = true;
            Player2part.enabled = true;
            StartCoroutine(Wait());

        }
    }

    void Imagechecks() {
        if (P1rocket.GetComponent<P1rocket>().part1 == true)
        {
            Player1part.enabled = true;
        }
        if (P1rocket.GetComponent<P1rocket>().part1 == false)
        {
            Player1part.enabled = false;
        }

        if (P2rocket.GetComponent<P2rocket>().part1 == true)
        {
            Player2part.enabled = true;
        }
        if (P2rocket.GetComponent<P2rocket>().part1 == false)
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
