[System.Serializable]
public class GameData
{
    public int coin;

    public bool[] levelUnlock;
    public bool[] levelCompleted;
    
    public bool[] accessoriesPurchased;

    public GameData()
    {
        coin = 0;

        levelUnlock = new bool[6];
        levelUnlock[0] = true;
        levelUnlock[1] = false;
        levelUnlock[2] = false;
        levelUnlock[3] = false;
        levelUnlock[4] = false;
        levelUnlock[5] = false;
        
        levelCompleted = new bool[6];
        levelCompleted[0] = false;
        levelCompleted[1] = false;
        levelCompleted[2] = false;
        levelCompleted[3] = false;
        levelCompleted[4] = false;
        levelCompleted[5] = false;
        
        accessoriesPurchased = new bool[4];
        accessoriesPurchased[0] = false;
        accessoriesPurchased[1] = false;
        accessoriesPurchased[2] = false;
        accessoriesPurchased[3] = false;
    }
}
