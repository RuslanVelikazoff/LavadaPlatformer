using UnityEngine;
using UnityEngine.UI;

public class OtrherBackground : MonoBehaviour
{
    public Button backWebViewButton;
    public Button forwardWebViewButton;

    public Policy policy;

    private void OnEnable()
    {
        if (backWebViewButton != null)
        {
            backWebViewButton.onClick.RemoveAllListeners();
            backWebViewButton.onClick.AddListener(() =>
            {
                policy.BackButtonAction();
            });
        }

        if (forwardWebViewButton != null)
        {
            forwardWebViewButton.onClick.RemoveAllListeners();
            forwardWebViewButton.onClick.AddListener(() =>
            {
                policy.ForwardButtonAction();
            });
        }
    }
}
