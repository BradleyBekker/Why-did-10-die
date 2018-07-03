using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class P2movement : MonoBehaviour
{
    public bool isOnGround = false;
    //win cutscene animation variables
    public bool allowMovement = true;
    private bool playPlayerCutscene = false;

    [SerializeField] public Renderer spriteRenderer;
    [SerializeField] private GameObject playerrocket;
    [SerializeField] private GameObject part1;
    [SerializeField] private GameObject part2;
    [SerializeField] private GameObject part3;
    [SerializeField] public GameObject runFX;

    Animator anim;
    float animspeed = 0;

    public Rigidbody2D rb;

    public Vector2 position;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<Renderer>();
    }

    void FixedUpdate()
    {
        animspeed = 0;
        
        position = transform.position;

        if(!allowMovement && isOnGround) playPlayerCutscene = true;
        if(playPlayerCutscene) playerCutscene();

        calculateForce();
        particle();

        anim.SetFloat("speed", animspeed);
    }

    //plasy player cutscene after winning
    private void playerCutscene() {
        Vector2 posRocket = playerrocket.GetComponent<P2rocket>().defaultPosition;

        if(position.x + .04 >= posRocket.x) {
            position.x = posRocket.x;
            transform.localScale = new Vector3(1, 1, 1);
            spriteRenderer.enabled = false;
            playerrocket.GetComponent<P2rocket>().animationPlaying = false;
            playerrocket.GetComponent<P2rocket>().playAnimation();
        }
        else {
            position.x += .04f;
            transform.localScale = new Vector3(1, 1, 1);
            animspeed = 1;
            falldownFactor = minFalldown;
        }
    }

    private void calculateForce()
    {
        calculateMovement();
        calculateJump();
        calculateGravity();

        rb.MovePosition( position );
    }

    // movement variables
    public float minMovementSpeed = .1f;
    public float maxMovementSpeed = .12f;
    private float movementSpeedRange;
    private float movementFactor = 0;
    public float movementFactorGrowth = 11;
    // jump variables
    public float jumpHeight = .12f;
    private float jumpFactor = 60;
    public float jumpFactorGrowth = 2;
    private float maxJumpFalldown = 180;
    private bool jumping = false;
    // gravity variables
    private float minFalldown = 180;
    private float maxFalldown = 270; // used for both jump and gravity so the gravity after the jump aligns with fall gravity
    private float falldownFactor = 180;
    public float falldownFactorGrowth = 1;
    private float gravityFactor = 0.01f;

    private void calculateMovement()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && allowMovement)
        {
            position.x -= calculateMovementSin();
            transform.localScale = new Vector3(-1, 1, 1);
            animspeed = 1;
        }
        if (Input.GetKey(KeyCode.RightArrow)&& !Input.GetKey(KeyCode.LeftArrow) && allowMovement)
        {
            position.x += calculateMovementSin();
            transform.localScale = new Vector3(1, 1, 1);
            animspeed = 1;
        }
    }

    private float calculateMovementSin()
    {
        movementSpeedRange = maxMovementSpeed - minMovementSpeed;
        movementFactor += movementFactorGrowth;
        movementFactor %= 360;
        return minMovementSpeed + (movementSpeedRange / 2) + movementSpeedRange * (float) Math.Sin(Math.PI * movementFactor / 180);
    }

    private void calculateJump() // when the jumpFactor equals 180 the player falls down
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isOnGround && allowMovement)
        {
            isOnGround = false;
            jumping = true;
            jumpFactor = 60;
            anim.SetTrigger("prep");
            anim.SetBool("jumping",true);
        }

        if(!isOnGround)
        {
            float jumpValue = (float) (jumpHeight * Math.Sin(Math.PI * jumpFactor / 180));
            if(jumpFactor + jumpFactorGrowth > maxJumpFalldown)
            {
                jumping = false;
            }
            else
            {
                jumpFactor += jumpFactorGrowth;
                position.y += jumpValue;
            }
        }
        if (jumpFactor == 180)
        {
            anim.SetBool("jumping", false);
            anim.SetBool("falling", true);
        }
    }

    private void calculateGravity()
    {
        position.y -= gravityFactor;
        if(!jumping)
        {
            position.y += (float) (jumpHeight * Math.Sin(Math.PI * falldownFactor / 180));
            if(falldownFactor + falldownFactorGrowth > maxFalldown)
            {
                falldownFactor = maxFalldown;
            }
            else falldownFactor += falldownFactorGrowth;
        }
    }

    public void OnGround()
    {
        isOnGround = true;
        jumping = false;
        jumpFactor = 60;
        falldownFactor = minFalldown;
        anim.SetBool("falling", false);
        anim.SetTrigger("land");
    }

    public void OnFloor()
    {
        jumping = false;
        jumpFactor = 180;
    }
    
    void particle()
    {
        ParticleSystem ps = runFX.GetComponent<ParticleSystem>();

        if (animspeed > 0f && isOnGround)
        {
            ps.enableEmission = true;
        }
        else//
        {
            ps.enableEmission = false;

        }
    }


}
