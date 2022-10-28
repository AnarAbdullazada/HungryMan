using DynamicBox.EventManagement;

namespace SOG.Managers.ScoreManager
{
  public class UpdateScoreEvent : GameEvent
  {
    public int score;

    public UpdateScoreEvent(int _score)
    {
      score = _score;
    }
  }
}

