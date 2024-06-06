using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI coinText;
    [SerializeField] 
    private TextMeshProUGUI timerText;

    [Space(13)]
    
    [SerializeField]
    private Button restartButton;
    [SerializeField] 
    private Button exitButton;

    private void OnEnable()
    {
        SetText();
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (restartButton != null)
        {
            restartButton.onClick.RemoveAllListeners();
            restartButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                Loader.LoaderCallback();
            });
        }

        if (exitButton != null)
        {
            exitButton.onClick.RemoveAllListeners();
            exitButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                Loader.Load(Loader.Scene.MainMenuScene);
            });
        }
    }

    private void SetText()
    {
        coinText.text = CoinManager.Instance.GetCurrentCoinAmount().ToString();
        timerText.text = TimerManager.Instance.GetTimerString();
    }
}
