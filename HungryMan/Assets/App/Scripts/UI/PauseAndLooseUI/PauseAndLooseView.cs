using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOG.UI.PauseAndLoose
{
  public class PauseAndLooseView : MonoBehaviour
  {
    [Header("Controller reference")]
    [SerializeField] private PauseAndLooseController controller;

    public void Resume()
    {
      controller.Resume();
    }

    public void Restart()
    {
      controller.Restart();
    }

    public void MainMenu()
    {
      controller.MainMenu();
    }

  }
}