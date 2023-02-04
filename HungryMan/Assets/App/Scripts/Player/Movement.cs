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
    [SerializeField] private float movementSpeed;

    [SerializeField] private Rigidbody2D playerRb;

    [SerializeField] private bool isJumpable;

    private void PlayerMovement()
    {
      float vertical = 0f;
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
        PlayerRotation();
      }
      if (InputHorizontal>0.5 || InputHorizontal <-0.5)
      {
        if (isJumpable)
        {
          vertical = 10f;
          isJumpable = false;
        }
        playerRb.velocity = ((Vector2.right * playerRb.velocity.x) + (Vector2.up * (10-vertical)));
        vertical -= 1;
      }
    }

    private void PlayerRotation()
    {
      float velocityY = playerRb.velocity.y;
      float maxVelocityY = 0.0f;
      float rotation = 0f;
      /*if (playerRb.velocity.x > 0) velocityX = (float)Math.Pow(playerRb.velocity.x, 2);
      if (playerRb.velocity.x < 0) velocityX = -1*(float)Math.Pow(playerRb.velocity.x, 2);*/
      Debug.Log(playerRb.velocity.y);
      if (velocityY > maxVelocityY)
      {
        maxVelocityY = velocityY;
        if (playerRb.velocity.x > 0) transform.localRotation = Quaternion.Euler(0, 0, 200 * maxVelocityY);
        if (playerRb.velocity.x < 0) transform.localRotation = Quaternion.Euler(0, 0, -200 * maxVelocityY);
      }
      else
      {
        if (playerRb.velocity.x > 0) transform.localRotation = Quaternion.Euler(0, 0, -200 * velocityY);
        if (playerRb.velocity.x < 0) transform.localRotation = Quaternion.Euler(0, 0, 200 * velocityY);
      }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
      if (collision.gameObject.CompareTag("Ground")) isJumpable = true;
    }

    private void Start()
    {
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

    }

    private void OnDisable()
    {
      EventManager.Instance.RemoveListener<RestartButtonPressedEvent>(RestartButtonPressedEventHadnler);
      EventManager.Instance.RemoveListener<PauseButtonPressedEvent>(PauseButtonPressedEventHadnler);

    }

    #endregion

    #region Handlers

    private void RestartButtonPressedEventHadnler(RestartButtonPressedEvent eventDetails)
    {
      gameObject.transform.position = new Vector3(0, -2.752f, 0);
    }

    private void PauseButtonPressedEventHadnler(PauseButtonPressedEvent eventDetails)
    {
      if (eventDetails.isLosed)
      {

      }
    }

    #endregion


  }
}
