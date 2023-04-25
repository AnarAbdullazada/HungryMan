using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOG.Meals;
using DynamicBox.EventManagement;
using SOG.UI.PauseAndLoose;
using SOG.UI.GamePlayUI;
using SOG.CameraScript;
using System;
//Elshad Alma
namespace SOG.Player
{
  public class Eating : MonoBehaviour
  {
    [Header("Properties")]
    [SerializeField] private float hungerTime;
    private float hungerTimer;

    [Header("Links")]
    [SerializeField] private Sound[] sounds;
    [SerializeField] private AudioSource audioSource;


    private void TimerForHunger()
    {
        if (hungerTimer >= 0)
        {
          hungerTimer -= Time.deltaTime;
        }
        else
        {
        EventManager.Instance.Raise(new PauseButtonPressedEvent(true));
        }
    }

    private void Play(string name)
    {
      Sound s = Array.Find(sounds, sound => sound.nameOfClip == name);
      if (s == null) return;
      s.source.Play();
    }

    private void Start()
    {
      hungerTimer = hungerTime;
    }

    private void Update()
    {
      if (GameManager.Instance.gameState == GameStateEnum.PLAY)
      {
        TimerForHunger();
      }
        
    }

    private void Awake()
    {
      EventManager.Instance.Raise(new GetHungerTimeEvent(hungerTime));
      foreach (Sound s in sounds)
      {
        s.source = gameObject.AddComponent<AudioSource>();
        s.source.clip = s.sound;
        s.source.volume = s.volume;
        s.source.pitch = s.pitch;
        s.source.playOnAwake = false;
      }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      if (collision.gameObject.CompareTag("Eatable"))
      {
        IMeal meal = collision.gameObject.GetComponent<IMeal>();
        meal.Eat();
        if (meal.GetSatiate())
        {
          Play("Drink");
          hungerTimer = hungerTime;
        }
        else Play("Crunch");
      }
    }



    #region Unity Events
    private void OnEnable()
    {
      EventManager.Instance.AddListener<RestartButtonPressedEvent>(RestartButtonPressedEventHadnler);
    }

    private void OnDisable()
    {
      EventManager.Instance.RemoveListener<RestartButtonPressedEvent>(RestartButtonPressedEventHadnler);

    }

    #endregion

    #region Handlers

    private void RestartButtonPressedEventHadnler(RestartButtonPressedEvent eventDetails)
    {
      hungerTimer = hungerTime;
    }

    #endregion


  }
}

