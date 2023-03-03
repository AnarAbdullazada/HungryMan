using DynamicBox.EventManagement;
using SOG.UI.MainMenuUI;
using SOG.UI.PauseAndLoose;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOG.UI.CreditsController
{
  public class CreditsController : MonoBehaviour
  {
    [Header("View")]
    [SerializeField] private CreditsView view;

    public void BackToMenuButtonPressed()
    {
      view.SetActivePanel(false);
      EventManager.Instance.Raise(new MainMenuButtonPressedEvent());
    }

    private void OnEnable()
    {
      EventManager.Instance.AddListener<CreditsButtonPressedEvent>(CreditsButtonPressedEventHandler);
    }

    private void CreditsButtonPressedEventHandler(CreditsButtonPressedEvent eventDetails)
    {
      view.SetActivePanel(true);
    }
  }
}

