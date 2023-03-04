using DynamicBox.EventManagement;
using SOG.Player;
using SOG.UI.GamePlayUI;
using SOG.UI.SettingsController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOG.Managers.SaveManager
{
  public class SaveManager : MonoBehaviour
  {
    private int bestScore;
    private float masterMusicVolume;
    private bool isFirstTime;

    private void Save()
    {
      Data data = new Data(bestScore, masterMusicVolume, isFirstTime);
      SaveSystem.SaveData(data);
    }

    private void Load()
    {
      Data data = SaveSystem.LoadData();
      if (data == null)
      {
        bestScore = 0;
        masterMusicVolume = 0.5f;
        isFirstTime = true;
      }
      else
      {
        bestScore = data.bestScore;
        masterMusicVolume = data.masterMusicVolume;
        isFirstTime = data.isFirstTime;
      }
      EventManager.Instance.Raise(new BestScoreEventFromUi(bestScore));
      EventManager.Instance.Raise(new MasterVolumeEvent(masterMusicVolume));
      EventManager.Instance.Raise(new ItIsFirsTimeEvent(isFirstTime));
    }

    private void Start()
    {
      Load();
    }

    private void OnEnable()
    {
      EventManager.Instance.AddListener<BestScoreEventFromUi>(BestScoreEventHandler);
      EventManager.Instance.AddListener<MasterVolumeEvent>(MasterVolumeEventHandler);
      EventManager.Instance.AddListener<FinishedIntroductionEvent>(FinishedIntroductionEventHandler);

    }

    private void OnDisable()
    {
      EventManager.Instance.RemoveListener<BestScoreEventFromUi>(BestScoreEventHandler);
      EventManager.Instance.RemoveListener<MasterVolumeEvent>(MasterVolumeEventHandler);
      EventManager.Instance.RemoveListener<FinishedIntroductionEvent>(FinishedIntroductionEventHandler);

    }

    private void BestScoreEventHandler(BestScoreEventFromUi eventDetails) { bestScore = eventDetails.bestScore; Save();}

    private void MasterVolumeEventHandler(MasterVolumeEvent eventDetails) { masterMusicVolume = eventDetails.masterVolume; Save();}

    private void FinishedIntroductionEventHandler(FinishedIntroductionEvent eventDetails) { isFirstTime = false; Save(); }


  }
}
