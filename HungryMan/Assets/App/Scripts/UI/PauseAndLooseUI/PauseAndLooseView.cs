using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SOG.UI.PauseAndLoose
{
  public class PauseAndLooseView : MonoBehaviour
  {
    [Header("Controller reference")]
    [SerializeField] private PauseAndLooseController controller;

    [Header("View properties")]
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text bestText;
    [SerializeField] private TMP_Text pausedOrLosedText;
    [SerializeField] private Button resumeButton;

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

    public void UpdateBestScoreText(int bestScore)
    {
      bestText.text ="Best Score: " + Convert.ToString(bestScore);
    }

    public void UpdateScoreText(int score)
    {
      scoreText.text = Convert.ToString(score);
    }

    public void Paused()
    {
      resumeButton.gameObject.SetActive(true);
      pausedOrLosedText.text = "Pause";
    }

    public void Losed()
    {
      resumeButton.gameObject.SetActive(false);
      pausedOrLosedText.text = "Game Over";
    }

  }
}