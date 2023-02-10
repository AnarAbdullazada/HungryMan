using DynamicBox.EventManagement;
using SOG.Managers.ScoreManager;
using SOG.UI.GamePlayUI;
using SOG.UI.PauseAndLoose;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SOG.Meals
{
  public class NormalMeals : MonoBehaviour, IMeal
  {
    [SerializeField] private int scoreForEat;
    [SerializeField] private bool satiate;

    private Rigidbody2D rb;

    public bool GetSatiate()
    {
      return satiate;
    }

    public void Eat()
    {
      gameObject.SetActive(false);
      gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
      EventManager.Instance.Raise(new UpdateScoreEvent(scoreForEat, satiate));
    }

    public void Loss()
    {
      gameObject.SetActive(false);
      gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }

    private void Start()
    {
      rb = this.gameObject.GetComponent<Rigidbody2D>();
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
      rb.bodyType = RigidbodyType2D.Dynamic;
    }

    private void PauseButtonPressedEventHadnler(PauseButtonPressedEvent eventDetails)
    {
      rb.bodyType = RigidbodyType2D.Static; 
      if (eventDetails.isLosed)
      {

      }
    }

    private void ResumeButtonPressedEventHandler(ResumeButtonPressedEvent eventDetails)
    {
      rb.bodyType = RigidbodyType2D.Dynamic;
    }

    #endregion

  }
}
