using DynamicBox.EventManagement;
using SOG.UI.PauseAndLoose;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOG.UI.MainMenuUI
{
  public class MainMenuController : MonoBehaviour
  {
    [Header("View reference")]
    [SerializeField] private MainMenuView view;

    [SerializeField] private AudioSource audioSource;


    public void PlayButton()
    {
      SetActiveView(false);
      audioSource.Play();
      EventManager.Instance.Raise(new RestartButtonPressedEvent());
      EventManager.Instance.Raise(new PlayButtonPressedEvent());
    }

    public void SettingsButton()
    {
      audioSource.Play();
      EventManager.Instance.Raise(new SettingsButtonPressedEvent());
    }

    public void CreditsButton()
    {
      audioSource.Play();
      EventManager.Instance.Raise(new CreditsButtonPressedEvent());
    }

    private void SetActiveView(bool active)
    {
      view.gameObject.SetActive(active);
    }


    #region Unity Events
    private void OnEnable()
    {
      EventManager.Instance.AddListener<MainMenuButtonPressedEvent>(MainMenuButtonPressedEventHandler);

    }

    private void OnDisable()
    {
      EventManager.Instance.RemoveListener<MainMenuButtonPressedEvent>(MainMenuButtonPressedEventHandler);
    }

    #endregion

    #region Handlers

    private void MainMenuButtonPressedEventHandler(MainMenuButtonPressedEvent eventDetails)
    {
      SetActiveView(true);
    }

    #endregion
  }
}

