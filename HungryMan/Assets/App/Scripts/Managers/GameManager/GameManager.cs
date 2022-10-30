using DynamicBox.EventManagement;
using SOG.UI.GamePlayUI;
using SOG.UI.MainMenuUI;
using SOG.UI.PauseAndLoose;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public static GameManager Instance;

  public GameStateEnum gameState;

  private void Awake()
  {
    if (Instance != null && Instance != this)
    {
      Destroy(this);
    }
    else
    {
      Instance = this;
    }
  }

  private void Start()
  {
    Application.targetFrameRate = 60;
  }


  #region Unity Events
  private void OnEnable()
  {
    EventManager.Instance.AddListener<PlayButtonPressedEvent>(PlayButtonPressedEventHandler);
    EventManager.Instance.AddListener<PauseButtonPressedEvent>(PauseButtonPressedEventHadnler);
    EventManager.Instance.AddListener<ResumeButtonPressedEvent>(ResumeButtonPressedEventHadnler);
    EventManager.Instance.AddListener<RestartButtonPressedEvent>(RestartButtonPressedEventHadnler);
  }

  private void OnDisable()
  {
    EventManager.Instance.RemoveListener<PlayButtonPressedEvent>(PlayButtonPressedEventHandler);
    EventManager.Instance.RemoveListener<PauseButtonPressedEvent>(PauseButtonPressedEventHadnler);
    EventManager.Instance.RemoveListener<ResumeButtonPressedEvent>(ResumeButtonPressedEventHadnler);
    EventManager.Instance.RemoveListener<RestartButtonPressedEvent>(RestartButtonPressedEventHadnler);

  }

  #endregion

  #region Handlers
  private void PlayButtonPressedEventHandler(PlayButtonPressedEvent eventDetails)
  {
    gameState = GameStateEnum.PLAY;
    Time.timeScale = 1f;
  }

  private void ResumeButtonPressedEventHadnler(ResumeButtonPressedEvent eventDetails)
  {
    gameState = GameStateEnum.PLAY;
    Time.timeScale = 1f;
  }

  private void RestartButtonPressedEventHadnler(RestartButtonPressedEvent eventDetails)
  {
    gameState = GameStateEnum.PLAY;
    Time.timeScale = 1f;
  }

  private void PauseButtonPressedEventHadnler(PauseButtonPressedEvent eventDetails)
  {
    gameState = GameStateEnum.PAUSE;
    Time.timeScale = 0f;
  }


  #endregion
}
