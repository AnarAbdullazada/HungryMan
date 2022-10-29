using DynamicBox.EventManagement;
using SOG.UI.MainMenuUI;
using SOG.UI.PauseAndLoose;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOG.UI.GamePlayUI
{
  public class GamePlayController : MonoBehaviour
  {
    [Header("View Reference")]
    [SerializeField] private GamePlayView view;

    public void PauseButton()
    {
      SetActiveView(false);
      EventManager.Instance.Raise(new PauseButtonPressedEvent());
    }

    public void SetActiveView(bool active)
    {
      view.gameObject.SetActive(active);
    }


    #region Unity Events
    private void OnEnable()
    {
      EventManager.Instance.AddListener<UIScoreUpdateEvent>(UIScoreUpdateEventHandler);
      EventManager.Instance.AddListener<PlayButtonPressedEvent>(PlayButtonPressedEventHandler);
      EventManager.Instance.AddListener<ResumeButtonPressedEvent>(ResumeButtonPressedEventHadnler);
      EventManager.Instance.AddListener<RestartButtonPressedEvent>(RestartButtonPressedEventHadnler);
    }

    private void OnDisable()
    {
      EventManager.Instance.RemoveListener<UIScoreUpdateEvent>(UIScoreUpdateEventHandler);
      EventManager.Instance.RemoveListener<PlayButtonPressedEvent>(PlayButtonPressedEventHandler);
      EventManager.Instance.RemoveListener<ResumeButtonPressedEvent>(ResumeButtonPressedEventHadnler);
      EventManager.Instance.RemoveListener<RestartButtonPressedEvent>(RestartButtonPressedEventHadnler);

    }

    #endregion

    #region Handlers
    private void UIScoreUpdateEventHandler(UIScoreUpdateEvent eventDetails)
    {
      view.UpdateScoreText(eventDetails.newScore);
    }

    private void PlayButtonPressedEventHandler(PlayButtonPressedEvent eventDetails)
    {
      SetActiveView(true);
    }

    private void ResumeButtonPressedEventHadnler(ResumeButtonPressedEvent eventDetails)
    {
      SetActiveView(true);
    }

    private void RestartButtonPressedEventHadnler(RestartButtonPressedEvent eventDetails)
    {
      SetActiveView(true);
    }

    #endregion

  }
}

