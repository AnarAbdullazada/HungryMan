namespace SOG.Meals
{
  public interface IMeal
  {
    int id { get; set; }

    bool GetSatiate();
    void Eat();
    void Loss();
  }
}

