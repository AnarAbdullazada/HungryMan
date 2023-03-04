using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SOG.UI.GamePlayUI
{
  public class GamePlayView : MonoBehaviour
  {
    [Header("Controller Reference")]
    [SerializeField] private GamePlayController controller;

    [Header("View properties")]
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private Image hungerBar;
    [SerializeField] private GameObject rightPanel;
    [SerializeField] private GameObject leftPanel;
    [SerializeField] private GameObject hungerBarPanel;

    public void PauseButton() { controller.PauseButton(); }

    public void TapTo() { controller.TapTo(); }

    public void UpdateScoreText(int score) { scoreText.text = Convert.ToString(score); }

    public void UpdateHungerBar(float width) { hungerBar.rectTransform.sizeDelta = new Vector2(width, 50);}

    public void RightPanel(bool active) { rightPanel.SetActive(active); }

    public void LefttPanel(bool active) { leftPanel.SetActive(active); }

    public void HungerBarPanel(bool active) { hungerBarPanel.SetActive(active); }


  }
}

