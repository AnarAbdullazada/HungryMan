using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOG.Meals;

namespace SOG.Player
{
  public class Eating : MonoBehaviour
  {
    [SerializeField] private float hungerTime;
    private float hungerTimer;
    private bool IsLosed = false;

    private void TimerForHunger()
    {
      if (IsLosed)
      {
        if (hungerTimer >= 0)
        {
          hungerTimer -= Time.deltaTime;
        }
        else
        {
          Debug.Log("Game Over");
          IsLosed = false;
        }
      }
    }



    private void Start()
    {
      hungerTimer = hungerTime;

      /*TEMPORARY*/
      IsLosed = true;
      /*TEMPORARY*/
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

  }
}

