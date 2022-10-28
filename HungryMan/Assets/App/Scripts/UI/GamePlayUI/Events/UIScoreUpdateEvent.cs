using DynamicBox.EventManagement;

namespace SOG.UI.GamePlayUI
{
  public class UIScoreUpdateEvent : GameEvent
  {
    public int newScore;

    public UIScoreUpdateEvent(int _newScore)
    {
      newScore = _newScore;
    }
  }
}

