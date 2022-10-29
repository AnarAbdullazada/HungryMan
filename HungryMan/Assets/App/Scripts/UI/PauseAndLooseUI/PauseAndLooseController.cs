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

    public void Resume()
    {
      SetActiveView(false);
      EventManager.Instance.Raise(new ResumeButtonPressedEvent());
    }

    public void Restart()
    {
      SetActiveView(false);
      EventManager.Instance.Raise(new RestartButtonPressedEvent());
    }

    public void MainMenu()
    {
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
    }

    private void OnDisable()
    {
      EventManager.Instance.RemoveListener<PauseButtonPressedEvent>(PauseButtonPressedEventHadnler);
    }

    #endregion

    #region Handlers
    private void PauseButtonPressedEventHadnler(PauseButtonPressedEvent eventDetails)
    {
      SetActiveView(true);
    }


    #endregion

  }
}

