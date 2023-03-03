using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SOG.UI.SettingsController
{
  public class SettingsView : MonoBehaviour
  {
    [Header("Setting controller")]
    [SerializeField] private SettingsController controller;

    [Header("View properties")]
    [SerializeField] private Image buttonImage;
    [SerializeField] private Slider musicSlider;

    [Header("Links")]
    [SerializeField] private Sprite volumeSprite;
    [SerializeField] private Sprite notVolumeSprite;

    public void VolumeButtonPressed() { controller.VolumeButtonPressed();}
    public void BackToMainMenuButton() { controller.BackToMainMenuButton(); }

    public void IsVolumeOn(bool volumeState)
    {
      if (volumeState) buttonImage.sprite = volumeSprite;
      if (!volumeState) buttonImage.sprite = notVolumeSprite;
    }

    public float SliderValue() { return musicSlider.value; }
    public void SetSliderValue(float val) { musicSlider.value = val; }
    public void SetActivePanel(bool active) { gameObject.SetActive(active); }

    private void Start()
    {
      musicSlider.onValueChanged.AddListener(val => controller.MasterVolume(val));
    }

  }
}