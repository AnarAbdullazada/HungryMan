using DynamicBox.EventManagement;
using SOG.UI.GamePlayUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOG.UI.PauseAndLoose
{
  public class PauseAndLooseController : MonoBehaviour
  {
    [Header("View reference")]
    [SerializeField] private PauseAndLooseView view;

    [SerializeField] private AudioSource audioSource;

    private int BestScore, currentScore;

    public void Resume()
    {
      audioSource.Play();
      SetActiveView(false);
      EventManager.Instance.Raise(new ResumeButtonPressedEvent());
    }

    public void Restart()
    {
      SetActiveView(false);
      audioSource.Play();
      EventManager.Instance.Raise(new RestartButtonPressedEvent());
    }

    public void MainMenu()
    {
      audioSource.Play();
      SetActiveView(false);
      EventManager.Instance.Raise(new MainMenuButtonPressedEvent());
    }

    private void SetActiveView(bool active)
    {
      view.gameObject.SetActive(active);
    }

    #region Unity Events
    private void OnEnable()
    {
      EventManager.Instance.AddListener<PauseButtonPressedEvent>(PauseButtonPressedEventHadnler);
      EventManager.Instance.AddListener<UIScoreUpdateEvent>(UIScoreUpdateEventHandler);
      EventManager.Instance.AddListener<BestScoreEventFromUi>(BestScoreEventHandler);

    }

    private void OnDisable()
    {
      EventManager.Instance.RemoveListener<PauseButtonPressedEvent>(PauseButtonPressedEventHadnler);
      EventManager.Instance.RemoveListener<UIScoreUpdateEvent>(UIScoreUpdateEventHandler);
      EventManager.Instance.RemoveListener<BestScoreEventFromUi>(BestScoreEventHandler);

    }

    #endregion

    #region Handlers
    private void PauseButtonPressedEventHadnler(PauseButtonPressedEvent eventDetails)
    {
      SetActiveView(true);
      if (eventDetails.isLosed)
      {
        view.Losed();
        if (currentScore > BestScore)
        {
          BestScore = currentScore;
          EventManager.Instance.Raise(new BestScoreEventFromUi(BestScore));
        }
      }
      else if (!eventDetails.isLosed) { view.Paused(); }
    }

    private void UIScoreUpdateEventHandler(UIScoreUpdateEvent eventDetails)
    {
      view.UpdateScoreText(eventDetails.newScore);
      currentScore = eventDetails.newScore;
    }

    private void BestScoreEventHandler(BestScoreEventFromUi eventDetails) {
      BestScore = eventDetails.bestScore;
      view.UpdateBestScoreText(BestScore); 
    }
    #endregion

  }
}

