[System.Serializable]
public class GameData
{
    public int coin;

    public bool[] levelUnlock;
    
    public bool[] accessoriesPurchased;

    public GameData()
    {
        coin = 0;

        levelUnlock = new bool[10];
        
        accessoriesPurchased = new bool[4];
    }
}
