using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : MonoBehaviour
{
    [SerializeField] 
    private Sprite activeBuySprite;
    [SerializeField] 
    private Sprite inactiveBuySprite;
    
    [Space(13)]

    [SerializeField] 
    private Button[] buyAccessoriesButton;

    [Space(13)]
    
    [SerializeField] 
    private TextMeshProUGUI coinText;

    private int currentCoinAmount;

    private int[] costAccesories = new[] {100, 100, 250, 400};

    private void OnEnable()
    {
        SetCoinText();
        ButtonClickAction();
        SetButtonSprite();
    }

    private void ButtonClickAction()
    {
        if (buyAccessoriesButton[0] != null)
        {
            buyAccessoriesButton[0].onClick.RemoveAllListeners();
            buyAccessoriesButton[0].onClick.AddListener(() =>
            {
                if (currentCoinAmount >= costAccesories[0])
                {
                    CoinData.Instance.ReduceCoin(costAccesories[0]);
                    ShopData.Instance.BuyAccessories(0);
                    SetCoinText();
                    SetButtonSprite();
                }
            });
        }
        
        if (buyAccessoriesButton[1] != null)
        {
            buyAccessoriesButton[1].onClick.RemoveAllListeners();
            buyAccessoriesButton[1].onClick.AddListener(() =>
            {
                if (currentCoinAmount >= costAccesories[1])
                {
                    CoinData.Instance.ReduceCoin(costAccesories[1]);
                    ShopData.Instance.BuyAccessories(1);
                    SetCoinText();
                    SetButtonSprite();
                }
            });
        }
        
        if (buyAccessoriesButton[2] != null)
        {
            buyAccessoriesButton[2].onClick.RemoveAllListeners();
            buyAccessoriesButton[2].onClick.AddListener(() =>
            {
                if (currentCoinAmount >= costAccesories[2])
                {
                    CoinData.Instance.ReduceCoin(costAccesories[2]);
                    ShopData.Instance.BuyAccessories(2);
                    SetCoinText();
                    SetButtonSprite();
                }
            });
        }
        
        if (buyAccessoriesButton[3] != null)
        {
            buyAccessoriesButton[3].onClick.RemoveAllListeners();
            buyAccessoriesButton[3].onClick.AddListener(() =>
            {
                if (currentCoinAmount >= costAccesories[3])
                {
                    CoinData.Instance.ReduceCoin(costAccesories[3]);
                    ShopData.Instance.BuyAccessories(3);
                    SetCoinText();
                    SetButtonSprite();
                }
            });
        }
    }

    private void SetCoinText()
    {
        currentCoinAmount = CoinData.Instance.GetCoinAmount();
        coinText.text = currentCoinAmount.ToString();
    }

    private void SetButtonSprite()
    {
        for (int i = 0; i < costAccesories.Length; i++)
        {
            if (currentCoinAmount >= costAccesories[i])
            {
                buyAccessoriesButton[i].GetComponent<Image>().sprite = activeBuySprite;
            }
            else
            {
                buyAccessoriesButton[i].GetComponent<Image>().sprite = inactiveBuySprite;
            }
        }

        for (int i = 0; i < buyAccessoriesButton.Length; i++)
        {
            if (ShopData.Instance.GetStatusAccessories(i))
            {
                buyAccessoriesButton[i].gameObject.SetActive(false);
            }
            else
            {
                buyAccessoriesButton[i].gameObject.SetActive(true);
            }
        }
    }
}
