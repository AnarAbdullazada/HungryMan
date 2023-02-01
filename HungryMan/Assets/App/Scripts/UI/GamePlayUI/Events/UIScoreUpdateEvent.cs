using DynamicBox.EventManagement;

namespace SOG.UI.GamePlayUI
{
  public class UIScoreUpdateEvent : GameEvent
  {
    public int newScore;

    public bool isItSatiate;

    public UIScoreUpdateEvent(int _newScore, bool _isItSatiate)
    {
      newScore = _newScore;
      isItSatiate = _isItSatiate;
    }
  }
}

