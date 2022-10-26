using SOG.Meals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOG.PlayerStand
{
  public class PlayerStand : MonoBehaviour
  {
    private void OnCollisionEnter2D(Collision2D collision)
    {
      if (collision.gameObject.CompareTag("Eatable"))
      {
        IMeal meal = collision.gameObject.GetComponent<IMeal>();
        meal.Loss();
      }
    }
  }
}

