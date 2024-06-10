using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingPanel : MonoBehaviour
{
    private float timeDownload = 2f;
    private float timeLeft;
    [SerializeField]
    private Slider loaderSlider;
    public bool load = false;
    
    private void Update()
    {
        if (load)
        {
            if (timeLeft < timeDownload)
            {
                timeLeft += Time.deltaTime;
                UpdateLoadingSliderValue();
            }
            else
            {
                SetScreenOrientation();
                MainMenuLoad();
            }
        }
    }

    private void UpdateLoadingSliderValue()
    {
        loaderSlider.value = timeLeft;
    }

    private void SetScreenOrientation()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    private void MainMenuLoad()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
