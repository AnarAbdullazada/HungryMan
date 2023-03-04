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
    [SerializeField] private AudioSource audioSource;


    private bool isVolumeOn, isSettingsOpened;
    private float sliderValue;
    private float sliderValueBeforeMute;

    public void VolumeButtonPressed()
    {
      isVolumeOn = !isVolumeOn;
      audioSource.Play();
      if (!isVolumeOn) { sliderValueBeforeMute = view.SliderValue(); view.SetSliderValue(0); }
      if (isVolumeOn) { view.SetSliderValue(sliderValueBeforeMute) ; }
    }

    public void BackToMainMenuButton()
    {
      view.SetActivePanel(false);
      isSettingsOpened = false;
      audioSource.Play();
      EventManager.Instance.Raise(new MainMenuButtonPressedEvent());
    }

    public void MasterVolume(float val) { AudioListener.volume = val; EventManager.Instance.Raise(new MasterVolumeEvent(val)); }

    private void Awake() { isVolumeOn = true; isSettingsOpened = false; }

    private void FixedUpdate()
    {
      if (!isSettingsOpened) return;
      sliderValue = view.SliderValue();
      if (sliderValue == 0) isVolumeOn = false;
      if (sliderValue > 0) isVolumeOn = true;
      view.IsVolumeOn(isVolumeOn);
      MasterVolume(sliderValue);
    }


    private void OnEnable()
    {
      EventManager.Instance.AddListener<SettingsButtonPressedEvent>(SettingsButtonPressedEventHandler);
      EventManager.Instance.AddListener<MasterVolumeEvent>(MasterVolumeEventHandler);

    }

    private void OnDisable()
    {
      EventManager.Instance.RemoveListener<SettingsButtonPressedEvent>(SettingsButtonPressedEventHandler);
      EventManager.Instance.RemoveListener<MasterVolumeEvent>(MasterVolumeEventHandler);

    }

    private void SettingsButtonPressedEventHandler(SettingsButtonPressedEvent evenDetails)
    {
      view.SetActivePanel(true);
      isSettingsOpened = true;
    }

    private void MasterVolumeEventHandler(MasterVolumeEvent eventDetails)
    {
      view.SetSliderValue(eventDetails.masterVolume);
      AudioListener.volume = eventDetails.masterVolume;
    }
  }
}

