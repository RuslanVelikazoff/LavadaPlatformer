using UnityEngine;
using UnityEngine.UI;

public class LevelPanel : MonoBehaviour
{
    [SerializeField]
    private Color activeLevelColor;
    [SerializeField] 
    private Color inactiveLevelColor;

    [Space(13)]
    
    [SerializeField]
    private Button[] levelButton;

    [Space(13)]
    
    [SerializeField] 
    private Sprite activeStatusSprite;
    [SerializeField] 
    private Sprite inactiveStatusSprite;
    
    [Space(13)]
    
    [SerializeField] 
    private Image[] statusImage;

    private bool[] levelUnlock;
    private bool[] levelCompleted;

    private void OnEnable()
    {
        SetButtonSprite();
        SetStatusImage();
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (levelButton[0] != null)
        {
            levelButton[0].onClick.RemoveAllListeners();
            levelButton[0].onClick.AddListener(() =>
            {
                if (levelUnlock[0])
                {
                    AudioManager.Instance.Play("Click");
                    LevelData.Instance.SetCurrentLevelIndex(0);
                    Loader.Load(Loader.Scene.LevelScene1);
                }
                else
                {
                    AudioManager.Instance.Play("Error");
                }
            });
        }
        
        if (levelButton[1] != null)
        {
            levelButton[1].onClick.RemoveAllListeners();
            levelButton[1].onClick.AddListener(() =>
            {
                if (levelUnlock[1])
                {
                    AudioManager.Instance.Play("Click");
                    LevelData.Instance.SetCurrentLevelIndex(1);
                    Loader.Load(Loader.Scene.LevelScene2);
                }
                else
                {
                    AudioManager.Instance.Play("Error");
                }
            });
        }
        
        if (levelButton[2] != null)
        {
            levelButton[2].onClick.RemoveAllListeners();
            levelButton[2].onClick.AddListener(() =>
            {
                if (levelUnlock[2])
                {
                    AudioManager.Instance.Play("Click");
                    LevelData.Instance.SetCurrentLevelIndex(2);
                    Loader.Load(Loader.Scene.LevelScene3);
                }
                else
                {
                    AudioManager.Instance.Play("Error");
                }
            });
        }
        
        if (levelButton[3] != null)
        {
            levelButton[3].onClick.RemoveAllListeners();
            levelButton[3].onClick.AddListener(() =>
            {
                if (levelUnlock[3])
                {
                    AudioManager.Instance.Play("Click");
                    LevelData.Instance.SetCurrentLevelIndex(3);
                    Loader.Load(Loader.Scene.LevelScene4);
                }
                else
                {
                    AudioManager.Instance.Play("Error");
                }
            });
        }
        
        if (levelButton[4] != null)
        {
            levelButton[4].onClick.RemoveAllListeners();
            levelButton[4].onClick.AddListener(() =>
            {
                if (levelUnlock[4])
                {
                    AudioManager.Instance.Play("Click");
                    LevelData.Instance.SetCurrentLevelIndex(4);
                    Loader.Load(Loader.Scene.LevelScene5);
                }
                else
                {
                    AudioManager.Instance.Play("Error");
                }
            });
        }
        
        if (levelButton[5] != null)
        {
            levelButton[5].onClick.RemoveAllListeners();
            levelButton[5].onClick.AddListener(() =>
            {
                if (levelUnlock[5])
                {
                    AudioManager.Instance.Play("Click");
                    LevelData.Instance.SetCurrentLevelIndex(5);
                    Loader.Load(Loader.Scene.LevelScene6);
                }
                else
                {
                    AudioManager.Instance.Play("Error");
                }
            });
        }
    }

    private void SetButtonSprite()
    {
        levelUnlock = LevelData.Instance.GetLevelUnlockArray();

        for (int i = 0; i < levelUnlock.Length; i++)
        {
            if (levelUnlock[i])
            {
                levelButton[i].GetComponent<Image>().color = activeLevelColor;
            }
            else
            {
                levelButton[i].GetComponent<Image>().color = inactiveLevelColor;
            }
        }
    }

    private void SetStatusImage()
    {
        levelCompleted = LevelData.Instance.GetLevelCompletedArray();

        for (int i = 0; i < levelCompleted.Length; i++)
        {
            if (levelCompleted[i])
            {
                statusImage[i].sprite = activeStatusSprite;
            }
            else
            {
                statusImage[i].sprite = inactiveStatusSprite;
            }
        }
    }
}
