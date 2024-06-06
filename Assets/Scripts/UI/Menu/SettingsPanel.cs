using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField]
    private Color activeColor;
    [SerializeField] 
    private Color inactiveColor;
    
    [Space(13)]
    
    [SerializeField]
    private Button onSoundButton;
    [SerializeField] 
    private TextMeshProUGUI onSoundText;
    [SerializeField] 
    private Button offSoundButton;
    [SerializeField]
    private TextMeshProUGUI offSoundText;

    [Space(13)]
    
    [SerializeField]
    private Button onMusicButton;
    [SerializeField] 
    private TextMeshProUGUI onMusicText;
    [SerializeField] 
    private Button offMusicButton;
    [SerializeField]
    private TextMeshProUGUI offMusicText;

    [Space(13)]
    
    [SerializeField] 
    private Button okButton;
    [SerializeField] 
    private GameObject mainPanel;

    private void OnEnable()
    {
        SetButtonTextColor();
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (okButton != null)
        {
            okButton.onClick.RemoveAllListeners();
            okButton.onClick.AddListener(()=>
            {
                AudioManager.Instance.Play("Click");
                this.gameObject.SetActive(false);
                mainPanel.SetActive(true);
            });
        }

        if (onSoundButton != null)
        {
            onSoundButton.onClick.RemoveAllListeners();
            onSoundButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                AudioManager.Instance.OnSounds();
                SetButtonTextColor();
            });
        }

        if (offSoundButton != null)
        {
            offSoundButton.onClick.RemoveAllListeners();
            offSoundButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                AudioManager.Instance.OffSounds();
                SetButtonTextColor();
            });
        }

        if (onMusicButton != null)
        {
            onMusicButton.onClick.RemoveAllListeners();
            onMusicButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                AudioManager.Instance.OnMusic();
                SetButtonTextColor();
            });
        }

        if (offMusicButton != null)
        {
            offMusicButton.onClick.RemoveAllListeners();
            offMusicButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                AudioManager.Instance.OffMusic();
                SetButtonTextColor();
            });
        }
    }

    private void SetButtonTextColor()
    {
        if (AudioManager.Instance.SoundPlay())
        {
            onSoundText.color = activeColor;
            offSoundText.color = inactiveColor;
        }

        if (!AudioManager.Instance.SoundPlay())
        {
            onSoundText.color = inactiveColor;
            offSoundText.color = activeColor;
        }

        if (AudioManager.Instance.MusicPlay())
        {
            onMusicText.color = activeColor;
            offMusicText.color = inactiveColor;
        }
        
        if (!AudioManager.Instance.MusicPlay())
        {
            onMusicText.color = inactiveColor;
            offMusicText.color = activeColor;
        }
    }
}
