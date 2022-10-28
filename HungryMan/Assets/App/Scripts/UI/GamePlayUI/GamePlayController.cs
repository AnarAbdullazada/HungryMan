using DynamicBox.EventManagement;
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

    }


    #region Unity Events
    private void OnEnable()
    {
      EventManager.Instance.AddListener<UIScoreUpdateEvent>(UIScoreUpdateEventHandler);
    }

    private void OnDisable()
    {
      EventManager.Instance.RemoveListener<UIScoreUpdateEvent>(UIScoreUpdateEventHandler);
    }

    #endregion

    #region Handlers
    private void UIScoreUpdateEventHandler(UIScoreUpdateEvent eventDetails)
    {
      view.UpdateScoreText(eventDetails.newScore);
    }

    #endregion

  }
}

