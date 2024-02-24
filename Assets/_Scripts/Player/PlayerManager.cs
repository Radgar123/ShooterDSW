using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Slider energySlider;
    public int maxHealth = 100;
    public int maxEnergy = 100;
    private int currentHealth;
    public int currentEnergy;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI energyText;
    public GameObject healthFillObject;
    public GameObject energyFillObject;

    void Start()
    {
        currentHealth = maxHealth;
        currentEnergy = maxEnergy;
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
          
        }
        UpdateHealthUI();
    }

    public void UseEnergy(int energyAmount)
    {
        currentEnergy -= energyAmount;
        if (currentEnergy <= 0)
        {
            currentEnergy = 0;
            energyFillObject.SetActive(false);
        }
        UpdateEnergyUI(); 
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

    public void EnergyCollect(int energyAmount)
    {
        currentEnergy += energyAmount;

        if(currentEnergy > maxEnergy)
        {
            currentEnergy = maxEnergy;
        }

        UpdateEnergyUI();
    }

    
    void UpdateHealthUI()
    {
        healthSlider.value = (float)currentHealth / maxHealth;
        healthText.text = currentHealth.ToString();
    }

    void UpdateEnergyUI()
    {
        energySlider.value = (float)currentEnergy / maxEnergy;
        energyText.text = currentEnergy.ToString();

    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("healthCollect"))

        {
            Heal(50);
            Destroy(other);
        }


        if (other.gameObject.CompareTag("energyCollect"))
        {
            EnergyCollect(50);
            Destroy(other);
        }
    }
}

