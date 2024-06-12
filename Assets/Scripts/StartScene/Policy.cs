using System.Collections;
using UnityEngine;

public class Policy : MonoBehaviour
{
    public LoadingPanel loader;
    public UniWebView policyWebView;
    public string policyUrl;
    public GameObject noConnectionScreen; 
    public GameObject loadingScreen;
    public GameObject webViewScreen;
    public GameObject backgroundForPolicy, backgroundForOther; 
 
    private bool pageLoadCompleteHandled = false; 
 
    private void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        CheckInitialConnection();
    }
 
    private void CheckInitialConnection()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            loadingScreen.SetActive(false);
            noConnectionScreen.SetActive(true);
        }
        else
        {
            NavigateBasedOnPolicyCheck();
        }
    }
 
    private IEnumerator CheckConnectionAndProceed()
    {
        while (Application.internetReachability == NetworkReachability.NotReachable)
        {
            loadingScreen.SetActive(false);
            noConnectionScreen.SetActive(true);
            yield return new WaitForSeconds(5f);
        }
 
        noConnectionScreen.SetActive(false);
        loadingScreen.SetActive(true);
        DisplayPolicyPage();
    }
 
    private void DisplayPolicyPage()
    {
        policyWebView.OnPageFinished += OnPolicyPageLoadComplete; 
        policyWebView.Load(policyUrl);
    }
 
    private void OnPolicyPageLoadComplete(UniWebView webView, int statusCode, string currentUrl)
    {
        if (pageLoadCompleteHandled) return; 
 
        UpdateUIBasedOnUrl(currentUrl);
        policyWebView.Show();
 
        if (policyUrl != currentUrl)
        {
            Destroy(gameObject);
        }
 
        pageLoadCompleteHandled = true; 
    }
 
    private void UpdateUIBasedOnUrl(string currentUrl)
    {
        bool isPolP = currentUrl == policyUrl;
        GameObject activeBackground = isPolP ? backgroundForPolicy : backgroundForOther;
        activeBackground.SetActive(true);
        Screen.orientation = isPolP ? ScreenOrientation.Portrait : ScreenOrientation.AutoRotation;
        PlayerPrefs.SetString("PolicyCheck", isPolP ? "Confirmed" : currentUrl);
    }
 
    public void ConfirmPolicy()
    {
        NavigateBasedOnPolicyCheck();
    }
 
    private void NavigateBasedOnPolicyCheck()
    {
        if (PlayerPrefs.GetString("PolicyCheck", "") == "")
        {
            StartCoroutine(CheckConnectionAndProceed());
        }
        else
        {
            string policyCheck = PlayerPrefs.GetString("PolicyCheck", "");
            if (policyCheck == "Confirmed")
            {
                StartGame();
            }
            else
            {
                ShowURL(policyCheck);
            }
        }
    }

    private void StartGame()
    {
        webViewScreen.SetActive(false);
        policyWebView.gameObject.SetActive(false);
        backgroundForPolicy.SetActive(false);
        loadingScreen.SetActive(true);
        loader.load = true;
    }

    private void ShowURL(string policyCheck)
    {
        webViewScreen.SetActive(true);
        policyWebView.gameObject.SetActive(true);
        policyWebView.Load(policyCheck);
        policyWebView.Show();
        backgroundForOther.SetActive(true);
    }

    public void BackButtonAction()
    {
        if (policyWebView.CanGoBack)
        {
            policyWebView.GoBack();
        }
    }

    public void ForwardButtonAction()
    {
        if (policyWebView.CanGoForward)
        {
            policyWebView.GoForward();
        }
    }
}