using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class P2rocket : MonoBehaviour 
{
    [SerializeField] public GameObject BackgroundMusic;
    [SerializeField] public GameObject Player2;
    [SerializeField] public GameObject playercam;
    [SerializeField] public GameObject Rocket1;
    [SerializeField]public ParticleSystem particleSystem1;
    [SerializeField]public ParticleSystem particleSystem2;

    private float flightIncrease = .003f;
    private float flightXRange = 3f;
    private float flightXRangeDeg = 0;
    public bool animationPlaying = false;

    public bool playerWon = false;

    public bool part1 = false;
    public bool part2 = false;
    public bool part3 = false;
    public bool part4 = false;
    public bool part5 = false;

    public Vector2 position;
    public Vector2 defaultPosition;


    private void Start() {
        defaultPosition = transform.position;
        particleSystem1.GetComponent<ParticleSystem>().enableEmission = false;
        particleSystem2.GetComponent<ParticleSystem>().enableEmission = false;
    }

    private void FixedUpdate() {
        position = transform.position;
        if(animationPlaying) playAnimation();
        if(transform.position.y > 56) playerWin();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (part1 && part2 && part3 && part4 && part5 && !Rocket1.GetComponent<P1rocket>().playerWon && collision.gameObject.tag == "player2")
        {
            part1 = false;
            part2 = false;
            part3 = false;
            part4 = false;
            part5 = false;
            BackgroundMusic.GetComponent<MusicManager>().transDefaultRunning = true;
            playerWon = true;

            Player2.GetComponent<P2movement>().allowMovement = false;
            particleSystem1.GetComponent<ParticleSystem>().enableEmission = true;
        }
    }

    //flies the rocket after winning
    public void playAnimation() {
        playercam.GetComponent<Playercam>().followPlayer = false;
        flightXRangeDeg += 1f % 360;
        position.y += calculateFlightIncrease();
        transform.position = new Vector2(defaultPosition.x, position.y);
    }

    //calculate the flight speed
    private float calculateFlightIncrease() {
        if(flightIncrease < 0.275f) {
            flightIncrease *= 1.022f;
        }
        else flightIncrease = 0.275f;
        
        if(flightIncrease > 0.005) {
            particleSystem2.GetComponent<ParticleSystem>().enableEmission = true;
        }
        return flightIncrease;
    }

    public void playerWin() {
        SceneManager.LoadScene(3);
    }
}
