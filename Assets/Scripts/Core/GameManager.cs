using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField] 
    private GameObject loadingPanel;

    private int currentLevelIndex;
    private int maxLevelIndex = 5;

    private void Awake()
    {
        Instance = this;
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(.1f);
        currentLevelIndex = LevelData.Instance.GetCurrentLevelIndex();
        loadingPanel.SetActive(false);
        Debug.Log(currentLevelIndex);
    }

    public void WinGame()
    {
        Time.timeScale = 0f;
        AudioManager.Instance.Play("Win");
        gameOverPanel.SetActive(true);
        CoinData.Instance.AddCoin(CoinManager.Instance.GetCurrentCoinAmount());
        LevelData.Instance.SetLevelComplete(currentLevelIndex);

        if (currentLevelIndex < maxLevelIndex)
        {
            LevelData.Instance.SetLevelUnlock(currentLevelIndex + 1);
        }
    }

    public void LoseGame()
    {
        Time.timeScale = 0f;
        AudioManager.Instance.Play("Lose");
        gameOverPanel.SetActive(true);
        CoinData.Instance.AddCoin(CoinManager.Instance.GetCurrentCoinAmount());
    }
}
