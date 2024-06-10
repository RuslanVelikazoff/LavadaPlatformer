using UnityEngine;
using UnityEngine.UI;

public class PolicyBackground : MonoBehaviour
{
    public Button agreeButton;
    public Policy policy;
    
    private void OnEnable()
    {
        if (agreeButton != null)
        {
            agreeButton.onClick.RemoveAllListeners();
            agreeButton.onClick.AddListener(() =>
            {
                policy.VerifyPolicy();
            });
        }
    }
}
