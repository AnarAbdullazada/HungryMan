using DynamicBox.EventManagement;
using SOG.UI.GamePlayUI;
using SOG.UI.PauseAndLoose;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOG.Player
{
  public class Movement : MonoBehaviour
  {
    [Header ("Properties")]
    [SerializeField] private float movementSpeed;

    [SerializeField] private int verticalSpeed;

    [SerializeField] private int fallSpeed;

    [SerializeField] private bool isJumpable;

    [Header("Links")]
    [SerializeField] private Rigidbody2D playerRb;

    [SerializeField] private Animator animator;

    //Internal variables
    private Vector2 gravVector;

    private void PlayerMovement()
    {
      float InputHorizontal = Input.GetAxis("Horizontal");

      playerRb.velocity = ((Vector2.right * InputHorizontal * movementSpeed) + (Vector2.up * playerRb.velocity.y)) * Time.deltaTime;

      if (Input.touchCount > 0)
      {
        Touch touch = Input.GetTouch(0);
        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        if (touchPosition.x > 1)
        {
          playerRb.velocity = ((Vector2.right * 1 * movementSpeed) + (Vector2.up * playerRb.velocity.y)) * Time.deltaTime;
        }
        if (touchPosition.x < -1)
        {
          playerRb.velocity = ((Vector2.right * -1 * movementSpeed) + (Vector2.up * playerRb.velocity.y)) * Time.deltaTime;
        }

        transform.localScale = new Vector3(Mathf.Sign(touchPosition.x), 1, 1);

        if (InputHorizontal > 0.5 || InputHorizontal < -0.5)
        {
          if (isJumpable)
          {
            playerRb.velocity = ((Vector2.right * playerRb.velocity.x) + (Vector2.up * ((float)(Math.Pow(playerRb.velocity.x, 2)))));
            isJumpable = false;
          }
        }
      }
      if (InputHorizontal != 0)
      {
        transform.localScale = new Vector3(Mathf.Sign(InputHorizontal),1,1);
      }
      animator.SetBool("IsJump", false);
      if (InputHorizontal > 0.8 || InputHorizontal < -0.8)
      {
        if (isJumpable)
        {
          animator.SetBool("IsJump", true);
          playerRb.velocity = (Vector2.right * playerRb.velocity.x) + (Vector2.up * verticalSpeed);
          isJumpable = false;
        }
      }

      if (playerRb.velocity.y < 0)
      {
        playerRb.velocity -= gravVector * fallSpeed * Time.deltaTime;
      }

    }



    private void OnTriggerStay2D(Collider2D collision)
    {
      if (collision.gameObject.CompareTag("Ground")) isJumpable = true;
    }

    private void Start()
    {
      gravVector = new Vector2(0, -Physics2D.gravity.y);
      isJumpable = true;

    }

    private void Update()
    {
      if (GameManager.Instance.gameState == GameStateEnum.PLAY)
      {
        PlayerMovement();
      }
    }


    #region Unity Events
    private void OnEnable()
    {
      EventManager.Instance.AddListener<RestartButtonPressedEvent>(RestartButtonPressedEventHadnler);
      EventManager.Instance.AddListener<PauseButtonPressedEvent>(PauseButtonPressedEventHadnler);
      EventManager.Instance.AddListener<ResumeButtonPressedEvent>(ResumeButtonPressedEventHandler);
    }

    private void OnDisable()
    {
      EventManager.Instance.RemoveListener<RestartButtonPressedEvent>(RestartButtonPressedEventHadnler);
      EventManager.Instance.RemoveListener<PauseButtonPressedEvent>(PauseButtonPressedEventHadnler);
      EventManager.Instance.RemoveListener<ResumeButtonPressedEvent>(ResumeButtonPressedEventHandler);

    }

    #endregion

    #region Handlers

    private void RestartButtonPressedEventHadnler(RestartButtonPressedEvent eventDetails)
    {
      gameObject.transform.position = new Vector3(0, -2.752f, 0);
      playerRb.bodyType = RigidbodyType2D.Dynamic;
    }

    private void PauseButtonPressedEventHadnler(PauseButtonPressedEvent eventDetails)
    {
      playerRb.velocity = Vector2.zero;
      playerRb.bodyType = RigidbodyType2D.Static;
      if (eventDetails.isLosed)
      {

      }
    }

    private void ResumeButtonPressedEventHandler(ResumeButtonPressedEvent eventDetails)
    {
      playerRb.bodyType = RigidbodyType2D.Dynamic;
    }

    #endregion


  }
}
