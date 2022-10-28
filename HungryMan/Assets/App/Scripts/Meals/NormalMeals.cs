using DynamicBox.EventManagement;
using SOG.Managers.ScoreManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SOG.Meals
{
  public class NormalMeals : MonoBehaviour, IMeal
  {
    [SerializeField] private int scoreForEat;
    [SerializeField] private bool satiate;

    public bool GetSatiate()
    {
      return satiate;
    }

    public void Eat()
    {
      gameObject.SetActive(false);
      gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
      EventManager.Instance.Raise(new UpdateScoreEvent(scoreForEat));
    }

    public void Loss()
    {
      gameObject.SetActive(false);
      gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }

  }
}
