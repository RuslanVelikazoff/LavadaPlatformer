using UnityEngine;

public class ShopData : MonoBehaviour
{
    private const string SaveKey = "MainSaveShop";
    
    private bool[] _accessoriesPurchased;
    
    public static ShopData Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Load();
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            Save();
        }
    }

    private void OnDisable()
    {
        Save();
    }

    private void Load()
    {
        var data = SaveManager.Load<GameData>(SaveKey);
        
        _accessoriesPurchased = data.accessoriesPurchased;
    }

    private void Save()
    {
        SaveManager.Save(SaveKey,GetSaveSnapshot());
        PlayerPrefs.Save();
    }

    private GameData GetSaveSnapshot()
    {
        var data = new GameData()
        {
            accessoriesPurchased = _accessoriesPurchased
        };

        return data;
    }

    public bool GetStatusAccessories(int index)
    {
        return _accessoriesPurchased[index];
    }

    public void BuyAccessories(int index)
    {
        _accessoriesPurchased[index] = true;
        Save();
    }
}
