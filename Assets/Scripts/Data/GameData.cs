[System.Serializable]
public class GameData
{
    public int coin;

    public bool[] levelUnlock;

    public bool[] costumePurchased;
    public bool[] accessoriesPurchased;

    public GameData()
    {
        coin = 0;

        levelUnlock = new bool[10];

        costumePurchased = new bool[3];
        accessoriesPurchased = new bool[3];
    }
}
