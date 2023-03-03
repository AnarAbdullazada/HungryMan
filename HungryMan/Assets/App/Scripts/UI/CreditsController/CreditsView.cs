using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOG.UI.CreditsController
{
  public class CreditsView : MonoBehaviour
  {
    [Header ("Controller")]
    [SerializeField] private CreditsController controller;

    public void BackToMenuButtonPressed() { controller.BackToMenuButtonPressed(); }

    public void FontCreditButton() { Application.OpenURL("https://www.dafont.com/dogica.font"); }
    public void CrunchVoiceCreditButton() { Application.OpenURL("https://opengameart.org/content/7-eating-crunches"); }
    public void BackgroundMusicCreditButton() { Application.OpenURL("https://pixabay.com/users/nullhertz-29811401/?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=119518"); }
    public void SoundEffectCreditButton() { Application.OpenURL("https://pixabay.com/sound-effects/?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=6008"); }
    public void SoundEffect2CreditButton() { Application.OpenURL("https://pixabay.com/users/universfield-28281460/?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=140881"); }


    public void SetActivePanel(bool active){ gameObject.SetActive(active); }
  }
}