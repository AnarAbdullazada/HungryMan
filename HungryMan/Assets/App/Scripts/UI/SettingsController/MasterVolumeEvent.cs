using DynamicBox.EventManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOG.UI.SettingsController
{
  public class MasterVolumeEvent : GameEvent
  {
    public float masterVolume;

    public MasterVolumeEvent(float volume)
    {
      masterVolume = volume;
    }
  }
}

