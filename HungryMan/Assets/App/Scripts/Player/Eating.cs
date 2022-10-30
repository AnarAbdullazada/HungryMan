using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOG.Meals;
using DynamicBox.EventManagement;
using SOG.UI.PauseAndLoose;
using SOG.UI.GamePlayUI;

namespace SOG.Player
{
  public class Eating : MonoBehaviour
  {
    [SerializeField] private float hungerTime;
    private float hungerTimer;

    private void TimerForHunger()
    {
        if (hungerTimer >= 0)
        {
          hungerTimer -= Time.deltaTime;
        }
        else
        {
        EventManager.Instance.Raise(new PauseButtonPressedEvent(true));
        }
    }



    private void Start()
    {
      hungerTimer = hungerTime;
    }

    private void Update()
    {
      if (GameManager.Instance.gameState == GameStateEnum.PLAY)
      {
        TimerForHunger();
      }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      if (collision.gameObject.CompareTag("Eatable"))
      {
        IMeal meal = collision.gameObject.GetComponent<IMeal>();
        meal.Eat();
        if (meal.GetSatiate())
        {
          hungerTimer = hungerTime;
        }
      }
    }



    #region Unity Events
    private void OnEnable()
    {
      EventManager.Instance.AddListener<RestartButtonPressedEvent>(RestartButtonPressedEventHadnler);
    }

    private void OnDisable()
    {
      EventManager.Instance.RemoveListener<RestartButtonPressedEvent>(RestartButtonPressedEventHadnler);

    }

    #endregion

    #region Handlers

    private void RestartButtonPressedEventHadnler(RestartButtonPressedEvent eventDetails)
    {
      hungerTimer = hungerTime;
    }

    #endregion


  }
}

