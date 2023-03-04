namespace SOG.Managers.SaveManager
{
  [System.Serializable]
  public class Data
  {
    public int bestScore;
    public float masterMusicVolume;
    public bool isFirstTime;

    public Data(int bestScore, float masterMusicVolume, bool isFirstTime)
    {
      this.bestScore = bestScore;
      this.masterMusicVolume = masterMusicVolume;
      this.isFirstTime = isFirstTime;
    }
  }
}

