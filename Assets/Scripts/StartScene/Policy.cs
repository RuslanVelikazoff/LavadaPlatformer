using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Policy : MonoBehaviour
{
    public GameObject webViewer;
    public LoadingPanel load;
    public UniWebView policyViewer;
    public string link;
    public GameObject noConnection;
    public GameObject loadScreen;
    public GameObject policyBackground, otherBackground;
    
    private bool pageComplete = false; 

    private void Start()
    {
        policyViewer.gameObject.SetActive(true);
        webViewer.SetActive(true);
        Screen.orientation = ScreenOrientation.Portrait;
        CheckInternetConnectionGame();
    }

    private void CheckInternetConnectionGame()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            loadScreen.SetActive(false);
            noConnection.SetActive(true);
        }
        else
        {
            CheckingConfirmPolicy();
        }
    }

    private IEnumerator CheckAndOpenPanel()
    {
        while (Application.internetReachability == NetworkReachability.NotReachable)
        {
            loadScreen.SetActive(false);
            noConnection.SetActive(true);
            yield return new WaitForSeconds(5f);
        }

        noConnection.SetActive(false);
        PolicyLoadLink();
    }

    private void PolicyLoadLink()
    {
        policyViewer.OnPageFinished += PageLoaded;
        policyViewer.Load(link);
    }

    private void PageLoaded(UniWebView viewer, int code, string currentLink)
    {
        if (pageComplete) return; 

        UpdateAllPanels(currentLink);
        policyViewer.Show();

        if (link != currentLink)
        {
            Destroy(gameObject);
        }

        pageComplete = true; 
    }

    private void UpdateAllPanels(string currentLink)
    {
        bool isPolicy = currentLink == link;
        GameObject currentBackground = isPolicy ? policyBackground : otherBackground;
        currentBackground.SetActive(true);
        Screen.orientation = isPolicy ? ScreenOrientation.Portrait : ScreenOrientation.AutoRotation;
        PlayerPrefs.SetString("PolicyCheck", isPolicy ? "Verified" : currentLink);
    }

    public void VerifyPolicy()
    {
        webViewer.SetActive(false);
        policyBackground.SetActive(false);
        CheckingConfirmPolicy();
        policyViewer.gameObject.SetActive(false);
    }

    private void CheckingConfirmPolicy()
    {
        if (PlayerPrefs.GetString("PolicyCheck", "") == "")
        {
            StartCoroutine(CheckAndOpenPanel());
        }
        else
        {
            string policyResult = PlayerPrefs.GetString("PolicyCheck", "");
            if (policyResult == "Confirmed")
            {
                loadScreen.SetActive(true);
                load.load = true;
            }
            else
            {
                policyViewer.Load(policyResult);
                policyViewer.Show();
                otherBackground.SetActive(true);
            }
        }
    }

    public void GoBack()
    {
        if (policyViewer.CanGoBack)
        {
            policyViewer.GoBack();
        }
    }

    public void GoForward()
    {
        if (policyViewer.CanGoForward)
        {
            policyViewer.GoForward();
        }
    }
}