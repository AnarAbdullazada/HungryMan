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

    [SerializeField] private AudioSource audioSource;

    private float hungerTime, hungerTimer;

    public void PauseButton()
    {
      SetActiveView(false);
      audioSource.Play();
      EventManager.Instance.Raise(new PauseButtonPressedEvent(false));
    }

    public void SetActiveView(bool active)
    {
      view.gameObject.SetActive(active);
    }

    private void UpdateHungerBar()
    {
      if (hungerTimer >= 0)
      {
        hungerTimer -= Time.deltaTime;
        view.UpdateHungerBar((hungerTimer*1000)/hungerTime);
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
        UpdateHungerBar();
      }

    }

    #region Unity Events
    private void OnEnable()
    {
      EventManager.Instance.AddListener<GetHungerTimeEvent>(GetHungerTimeEventHandler);
      EventManager.Instance.AddListener<UIScoreUpdateEvent>(UIScoreUpdateEventHandler);
      EventManager.Instance.AddListener<PlayButtonPressedEvent>(PlayButtonPressedEventHandler);
      EventManager.Instance.AddListener<ResumeButtonPressedEvent>(ResumeButtonPressedEventHadnler);
      EventManager.Instance.AddListener<RestartButtonPressedEvent>(RestartButtonPressedEventHadnler);
      EventManager.Instance.AddListener<PauseButtonPressedEvent>(PauseButtonPressedEventHadnler);
    }

    private void OnDisable()
    {
      EventManager.Instance.RemoveListener<GetHungerTimeEvent>(GetHungerTimeEventHandler);
      EventManager.Instance.RemoveListener<UIScoreUpdateEvent>(UIScoreUpdateEventHandler);
      EventManager.Instance.RemoveListener<PlayButtonPressedEvent>(PlayButtonPressedEventHandler);
      EventManager.Instance.RemoveListener<ResumeButtonPressedEvent>(ResumeButtonPressedEventHadnler);
      EventManager.Instance.RemoveListener<RestartButtonPressedEvent>(RestartButtonPressedEventHadnler);
      EventManager.Instance.RemoveListener<PauseButtonPressedEvent>(PauseButtonPressedEventHadnler);
    }

    #endregion

    #region Handlers
    private void UIScoreUpdateEventHandler(UIScoreUpdateEvent eventDetails)
    {
      view.UpdateScoreText(eventDetails.newScore);
      if(eventDetails.isItSatiate) hungerTimer = hungerTime;
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

    private void PauseButtonPressedEventHadnler(PauseButtonPressedEvent eventDetails)
    {
      SetActiveView(false);
    }

    private void GetHungerTimeEventHandler(GetHungerTimeEvent eventDetails)
    {
      hungerTime = eventDetails.hungerTime;
    }

    #endregion

  }
}

