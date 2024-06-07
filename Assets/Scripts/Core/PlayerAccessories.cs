using System.Collections;
using UnityEngine;

public class PlayerAccessories : MonoBehaviour
{
    [SerializeField]
    private GameObject[] accessories;

    [Space(13)]
    
    [SerializeField]
    private GameObject playerWithGun;
    [SerializeField] 
    private GameObject playerWithoutGun;
    
    [Space(13)]

    [SerializeField] 
    private Animator playerWithGunAnimator;
    [SerializeField] 
    private Animator playerWithoutGunAnimator;
    
    [Space(13)]

    [SerializeField] 
    private PlayerMovement playerMovement;
    [SerializeField] 
    private PlayerAttack playerAttack;
    
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(.1f);

        for (int i = 0; i < accessories.Length; i++)
        {
            if (i == 3)
            {
                if (ShopData.Instance.GetStatusAccessories(i))
                {
                    playerWithGun.SetActive(true);
                    playerWithoutGun.SetActive(false);
                    playerMovement.SetPlayerSprite(playerWithGun);
                    playerMovement.SetPlayerAnimator(playerWithGunAnimator);
                    playerAttack.SetPlayerAnimator(playerWithGunAnimator);
                    playerAttack.SetPlayerGameObject(playerWithGun);
                    playerAttack.IsPlayerWithGun(true);
                }
                else
                {
                    playerWithGun.SetActive(false);
                    playerWithoutGun.SetActive(true);
                    playerMovement.SetPlayerSprite(playerWithoutGun);
                    playerMovement.SetPlayerAnimator(playerWithoutGunAnimator);
                    playerAttack.SetPlayerAnimator(playerWithoutGunAnimator);
                    playerAttack.SetPlayerGameObject(playerWithoutGun);
                    playerAttack.IsPlayerWithGun(false);
                }
            }
            else
            {
                if (ShopData.Instance.GetStatusAccessories(i))
                {
                    accessories[i].SetActive(true);
                }
                else
                {
                    accessories[i].SetActive(false);
                }
            }
        }
    }
}
