using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance { get; private set; }

    [SerializeField] 
    private TextMeshProUGUI coinText;
    
    private int currentCoin;

    private void Awake()
    {
        Instance = this;
        coinText.text = currentCoin.ToString();
    }

    public void AddCoin()
    {
        AudioManager.Instance.Play("AddCoin");
        currentCoin++;
        coinText.text = currentCoin.ToString();
    }

    public int GetCurrentCoinAmount()
    {
        return currentCoin;
    }
}
