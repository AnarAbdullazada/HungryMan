using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOG.CameraScript
{
  [System.Serializable]
  public class Sound
  {
    [Header("Properties")]
    public string nameOfClip;

    [Range(0f, 1f)]
    public float volume;

    [Range(0f, 3f)]
    public float pitch;

    [Header("Links")]
    public AudioClip sound;

    [HideInInspector]
    public AudioSource source;
  }
}

