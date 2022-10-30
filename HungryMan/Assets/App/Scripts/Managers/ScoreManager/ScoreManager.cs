using DynamicBox.EventManagement;
using SOG.UI.GamePlayUI;
using SOG.UI.PauseAndLoose;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOG.Managers.ScoreManager
{
  public class ScoreManager : MonoBehaviour
  {
    [SerializeField] private int currentScore;

    [SerializeField] private int bestScore;



    #region Unity Events
    private void OnEnable()
    {
      EventManager.Instance.AddListener<UpdateScoreEvent>(UpdateScoreEventHandler);
      EventManager.Instance.AddListener<RestartButtonPressedEvent>(RestartButtonPressedEventHadnler);
    }

    private void OnDisable()
    {
      EventManager.Instance.RemoveListener<UpdateScoreEvent>(UpdateScoreEventHandler);
      EventManager.Instance.RemoveListener<RestartButtonPressedEvent>(RestartButtonPressedEventHadnler);
    }
    #endregion


    #region Handlers
    private void UpdateScoreEventHandler(UpdateScoreEvent eventDetails)
    {
      currentScore += eventDetails.score;
      EventManager.Instance.Raise(new UIScoreUpdateEvent(currentScore));
    }

    private void RestartButtonPressedEventHadnler(RestartButtonPressedEvent eventDetails)
    {
      currentScore = 0;
      EventManager.Instance.Raise(new UIScoreUpdateEvent(currentScore));
    }
    #endregion

  }
}

