using UnityEngine;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour
{
    [SerializeField]
    private Button startButton;
    [SerializeField] 
    private Button settingsButton;
    [SerializeField] 
    private Button shopButton;
    [SerializeField]
    private Button exitButton;

    [Space(13)]
    
    [SerializeField] 
    private GameObject levelPanel;
    [SerializeField] 
    private GameObject settingsPanel;
    [SerializeField]
    private GameObject shopPanel;

    private void OnEnable()
    {
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (startButton != null)
        {
            startButton.onClick.RemoveAllListeners();
            startButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                this.gameObject.SetActive(false);
                levelPanel.SetActive(true);
            });
        }

        if (settingsButton != null)
        {
            settingsButton.onClick.RemoveAllListeners();
            settingsButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                this.gameObject.SetActive(false);
                settingsPanel.SetActive(true);
            });
        }

        if (shopButton != null)
        {
            shopButton.onClick.RemoveAllListeners();
            shopButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                this.gameObject.SetActive(false);
                shopPanel.SetActive(true);
            });
        }

        if (exitButton != null)
        {
            exitButton.onClick.RemoveAllListeners();
            exitButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                Application.Quit();
            });
        }
    }
}
