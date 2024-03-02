using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public Slider healthSlider;
   
    public int maxHealth = 100;
    
    private int currentHealth;
   
    public TextMeshProUGUI healthText;
   
    public GameObject healthFillObject;

    public GameObject deathMenu;
    

    void Start()
    {
        currentHealth = maxHealth;
       
        healthText.text = currentHealth.ToString();
        UpdateHealthUI();
    }
   

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            healthFillObject.SetActive(false);
            Invoke("ShowDeathMenu", 2);
          
        }
        UpdateHealthUI();
    }


  
    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UpdateHealthUI();
    }

    
    void UpdateHealthUI()
    {
        healthSlider.value = (float)currentHealth / maxHealth;
        healthText.text = currentHealth.ToString();
    }


    void ShowDeathMenu()
    {
        deathMenu.gameObject.SetActive(true);
    }
    

   
}

