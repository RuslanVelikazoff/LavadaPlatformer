using UnityEngine;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour
{
    [SerializeField]
    private Button startButton;
    [SerializeField] 
    private Button settingsButton;
    [SerializeField]
    private Button exitButton;

    [SerializeField] 
    private GameObject settingsPanel;

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
                Debug.Log("Start");
            });
        }

        if (settingsButton != null)
        {
            settingsButton.onClick.RemoveAllListeners();
            settingsButton.onClick.AddListener(() =>
            {
                settingsPanel.gameObject.SetActive(true);
                this.gameObject.SetActive(false);
            });
        }

        if (exitButton != null)
        {
            exitButton.onClick.RemoveAllListeners();
            exitButton.onClick.AddListener(() =>
            {
                Application.Quit();
            });
        }
    }
}
