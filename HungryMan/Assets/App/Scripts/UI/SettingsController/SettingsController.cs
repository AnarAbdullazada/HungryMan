using DynamicBox.EventManagement;
using SOG.UI.PauseAndLoose;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOG.UI.SettingsController
{
  public class SettingsController : MonoBehaviour
  {
    [Header("Setting view")]
    [SerializeField] private SettingsView view;

    private bool isVolumeOn;
    private float sliderValue;
    private float sliderValueBeforeMute;

    public void VolumeButtonPressed()
    {
      isVolumeOn = !isVolumeOn;
      if (!isVolumeOn) { sliderValueBeforeMute = view.SliderValue(); view.SetSliderValue(0); }
      if (isVolumeOn) { view.SetSliderValue(sliderValueBeforeMute) ; }
    }

    public void BackToMainMenuButton()
    {
      view.SetActivePanel(false);
      EventManager.Instance.Raise(new MainMenuButtonPressedEvent());
    }

    public void MasterVolume(float val){ AudioListener.volume = val; }

    private void Awake() { isVolumeOn = true; }

    private void FixedUpdate()
    {
      sliderValue = view.SliderValue();
      if (sliderValue == 0) isVolumeOn = false;
      if (sliderValue > 0) isVolumeOn = true;
      view.IsVolumeOn(isVolumeOn);
      MasterVolume(sliderValue);
    }


    private void OnEnable()
    {
      EventManager.Instance.AddListener<SettingsButtonPressedEvent>(SettingsButtonPressedEventHandler);
    }

    private void OnDisable()
    {
      EventManager.Instance.RemoveListener<SettingsButtonPressedEvent>(SettingsButtonPressedEventHandler);
    }

    private void SettingsButtonPressedEventHandler(SettingsButtonPressedEvent evenDetails)
    {
      view.SetActivePanel(true);
    }
  }
}

