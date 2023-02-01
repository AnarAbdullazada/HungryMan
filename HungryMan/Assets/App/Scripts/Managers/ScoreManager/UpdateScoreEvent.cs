using DynamicBox.EventManagement;

namespace SOG.Managers.ScoreManager
{
  public class UpdateScoreEvent : GameEvent
  {
    public int score;

    public bool isItSatiate;

    public UpdateScoreEvent(int _score, bool _isItSatiate)
    {
      score = _score;
      isItSatiate = _isItSatiate;
    }
  }
}

