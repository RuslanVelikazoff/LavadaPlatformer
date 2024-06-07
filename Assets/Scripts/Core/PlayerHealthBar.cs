using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public static PlayerHealthBar Instance { get; private set; }

    private float currentHealth;
    private float maxHealh = 100f;
    
    [SerializeField] 
    private Slider healthBarSlider;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        currentHealth = maxHealh;
        healthBarSlider.maxValue = maxHealh;
        healthBarSlider.value = currentHealth;
    }

    public void DamagePlayer(int damage)
    {
        currentHealth -= damage;
        healthBarSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
            GameManager.Instance.LoseGame();
        }
    }
}
