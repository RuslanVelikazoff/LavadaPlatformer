using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    [SerializeField] 
    private Button pauseButton;
    [SerializeField] 
    private GameObject pausePanel;
    [SerializeField] 
    private GameObject gamePanel;

    [Space(13)]
    
    [SerializeField]
    private Button restartButton;
    [SerializeField]
    private Button continueButton;
    [SerializeField]
    private Button exitButton;

    private void OnEnable()
    {
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (pauseButton != null)
        {
            pauseButton.onClick.RemoveAllListeners();
            pauseButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                Time.timeScale = 0f;
                pausePanel.SetActive(true);
                gamePanel.SetActive(false);
            });
        }

        if (continueButton != null)
        {
            continueButton.onClick.RemoveAllListeners();
            continueButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                gamePanel.SetActive(true);
                pausePanel.SetActive(false);
                Time.timeScale = 1f;
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

        if (restartButton != null)
        {
            restartButton.onClick.RemoveAllListeners();
            restartButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                Loader.LoaderCallback();
            });
        }
    }
}
