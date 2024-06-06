using UnityEngine;
using UnityEngine.UI;

public class BackButtonAction : MonoBehaviour
{
    [SerializeField]
    private Button backButton;

    [Space(13)]
    
    [SerializeField] 
    private GameObject openPanel;
    [SerializeField] 
    private GameObject closePanel;

    private void OnEnable()
    {
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (backButton != null)
        {
            backButton.onClick.RemoveAllListeners();
            backButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                openPanel.SetActive(true);
                closePanel.SetActive(false);
            });
        }
    }
}
