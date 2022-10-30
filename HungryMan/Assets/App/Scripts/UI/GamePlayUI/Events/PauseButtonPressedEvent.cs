using DynamicBox.EventManagement;

namespace SOG.UI.GamePlayUI
{
  public class PauseButtonPressedEvent : GameEvent
  {
    public bool isLosed;

    public PauseButtonPressedEvent(bool _isLosed)
    {
      isLosed = _isLosed;
    }
  }
}
