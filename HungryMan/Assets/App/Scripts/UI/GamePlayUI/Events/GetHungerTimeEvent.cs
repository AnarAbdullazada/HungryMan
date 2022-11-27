using DynamicBox.EventManagement;
namespace SOG.UI.GamePlayUI
{
  public class GetHungerTimeEvent : GameEvent
  {
    public float hungerTime;
     public GetHungerTimeEvent(float _hungerTime)
    {
      hungerTime = _hungerTime;
    }
  }
}

