using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    private const string SaveKey = "MainSaveLevel";
    
    private bool[] _levelUnlock;
    private bool[] _levelCompleted;

    private int currentLevelIndex;
    
    public static LevelData Instance;

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

        _levelUnlock = data.levelUnlock;
        _levelCompleted = data.levelCompleted;
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
            levelUnlock = _levelUnlock,
            levelCompleted = _levelCompleted
        };

        return data;
    }

    public void SetCurrentLevelIndex(int index)
    {
        currentLevelIndex = index;
    }

    public int GetCurrentLevelIndex()
    {
        return currentLevelIndex;
    }

    public bool[] GetLevelUnlockArray()
    {
        return _levelUnlock;
    }

    public void SetLevelUnlock(int index)
    {
        _levelUnlock[index] = true;
    }

    public bool[] GetLevelCompletedArray()
    {
        return _levelCompleted;
    }

    public void SetLevelComplete(int index)
    {
        _levelCompleted[index] = true;
    }
}
