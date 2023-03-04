using DynamicBox.EventManagement;

namespace SOG.Managers.SaveManager
{
  public class ItIsFirsTimeEvent : GameEvent
  {
    public bool isFirstTime;

    public ItIsFirsTimeEvent(bool Is)
    {
      isFirstTime = Is;
    }
  }
}
