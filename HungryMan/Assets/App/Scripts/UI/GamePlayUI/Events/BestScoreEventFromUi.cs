using DynamicBox.EventManagement;

namespace SOG.UI.GamePlayUI
{
  public class BestScoreEventFromUi : GameEvent
  {
    public int bestScore;

    public BestScoreEventFromUi(int best)
    {
      bestScore = best;
    }
  }
}

