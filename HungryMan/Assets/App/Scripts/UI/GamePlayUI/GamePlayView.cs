using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SOG.UI.GamePlayUI
{
  public class GamePlayView : MonoBehaviour
  {
    [Header("Controller Reference")]
    [SerializeField] private GamePlayController controller;

    [Header("View properties")]
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text bestText;

    public void PauseButton()
    {
      controller.PauseButton();
    }

    public void UpdateScoreText(int score)
    {
      scoreText.text = Convert.ToString(score);
    }

    public void UpdateBestScoreText(int bestScore)
    {
      bestText.text = Convert.ToString(bestScore);
    }

  }
}

