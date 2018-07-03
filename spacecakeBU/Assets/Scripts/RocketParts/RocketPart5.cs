using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketPart5 : MonoBehaviour
{

    public AudioSource soundsource;

    public GameObject P1rocket;
    public GameObject P2rocket;
    [SerializeField] private Image Player1part;
    [SerializeField] private Image Player2part;
    Animator anim;
    bool Colletable = true;

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
        if (collision.gameObject.tag == "player1" && P1rocket.GetComponent<P1rocket>().part5 == false && Colletable)
        {
            soundsource.Play();
            Colletable = false;
            anim.SetTrigger("pickup");
            P1rocket.GetComponent<P1rocket>().part5 = true;
            StartCoroutine(Wait());
            Player1part.enabled = true;
        }
        if (collision.gameObject.tag == "player2" && P2rocket.GetComponent<P2rocket>().part5 == false && Colletable)
        {
            soundsource.Play();
            Colletable = false;
            anim.SetTrigger("pickup");
            P2rocket.GetComponent<P2rocket>().part5 = true;
            StartCoroutine(Wait());
            Player2part.enabled = true;
        }

    }
    void Imagechecks()
    {
        if (P1rocket.GetComponent<P1rocket>().part5 == true)
        {
            Player1part.enabled = true;
        }
        if (P1rocket.GetComponent<P1rocket>().part5 == false)
        {
            Player1part.enabled = false;
        }

        if (P2rocket.GetComponent<P2rocket>().part5 == true)
        {
            Player2part.enabled = true;
        }
        if (P2rocket.GetComponent<P2rocket>().part5 == false)
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

