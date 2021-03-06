﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public enum players { player1, player2, player3, player4}
    public players player;
    [Range(-100, 100)] public int Sadness;
    [Range(-100, 100)] public int Happiness;
    [Range(-100, 100)] public int Anxiety;
    [Range(-100, 100)] public int Anger;
    [Range(-100, 100)] public int Energy;
    public Image button;
    public Image activitytimer;
    public string activityButton;

    public float inputX;
    public float inputZ;
    public Vector3 desiredMoveDirection;
    public bool blockRotationPlayer;
    public float desiredRotationSpeed;
    public Animator anim;
    public float speed;
    public float allowPlayerRotation;
    public Camera cam;
    public CharacterController controller;
    public bool isGrounded;
    private float verticalVel;
    private Vector3 moveVector;
    public int PlayerScore;

    public GameObject hand;
    public GameObject OrderObject;

    private Movement playerInstance;


    public ParticleSystem plusHappy;
    public ParticleSystem minusHappy;
    public ParticleSystem plusSadness;
    public ParticleSystem minusSadness;
    public ParticleSystem plusAnger;
    public ParticleSystem minusAnger;
    public ParticleSystem plusAnxiety;
    public ParticleSystem minusAnxiety;
    public ParticleSystem plusEnergy;
    public ParticleSystem minusEnergy;
    void Start()
    {
        anim = this.GetComponent<Animator>();
        controller = this.GetComponent<CharacterController>();
        PlayerCheck();
        
    }

    void Update()
    {
        PlayerCheck();
        InputMagnitude();
        CheckIfHoldingOrder();

        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Ending")
        {
            Destroy(this.GetComponent<firstPerson>());
            Destroy(this.GetComponent<MusicManaging>());
        }
    }
    void CheckIfHoldingOrder()
    {
        if(hand.transform.childCount >= 1)
        OrderObject = hand.transform.GetChild(0).gameObject;
    }
    void PlayerMoveAndRotation()
    {

        Vector3 forward = cam.transform.forward;
        Vector3 right = cam.transform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        transform.Translate(Vector3.forward * (speed * 2) * Time.deltaTime);

        desiredMoveDirection = forward * inputZ + right * inputX;

        if(blockRotationPlayer == false)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection.normalized), desiredRotationSpeed);
        }
    }

    void InputMagnitude()
    {

        anim.SetFloat("InputZ", inputZ, 0.0f, Time.deltaTime * 2f);
        anim.SetFloat("InputX", inputX, 0.0f, Time.deltaTime * 2f);

        speed = new Vector2(inputX, inputZ).sqrMagnitude;

        if(speed > allowPlayerRotation)
        {
            anim.SetFloat("InputMagnitude", speed, 0.0f, Time.deltaTime);
            PlayerMoveAndRotation();
        }

        else if(speed < allowPlayerRotation)
        {
            anim.SetFloat("InputMagnitude", speed, 0.0f, Time.deltaTime);
        }
    }

    void PlayerCheck()
    {
        if (player == players.player1)
        {
            inputX = Input.GetAxis("HorizontalP1");
            inputZ = Input.GetAxis("VerticalP1");
            activityButton = "Fire1P1";
        }
        if (player == players.player2)
        {
            inputX = Input.GetAxis("HorizontalP2");
            inputZ = Input.GetAxis("VerticalP2");
            activityButton = "Fire1P2";
        }
        if (player == players.player3)
        {
            inputX = Input.GetAxis("HorizontalP3");
            inputZ = Input.GetAxis("VerticalP3");
            activityButton = "Fire1P3";
        }
        if (player == players.player4)
        {
            inputX = Input.GetAxis("HorizontalP4");
            inputZ = Input.GetAxis("VerticalP4");
            activityButton = "Fire1P4";
        }
    }
}
