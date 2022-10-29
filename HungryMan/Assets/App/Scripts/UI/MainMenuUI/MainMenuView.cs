using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOG.UI.MainMenuUI
{
  public class MainMenuView : MonoBehaviour
  {
    [Header("Controller reference")]
    [SerializeField] private MainMenuController controller;

    public void PlayButton()
    {
      controller.PlayButton();
    }

    public void SettingsButton()
    {
      controller.SettingsButton();
    }

    public void CreditsButton()
    {
      controller.CreditsButton();
    }

  }
}