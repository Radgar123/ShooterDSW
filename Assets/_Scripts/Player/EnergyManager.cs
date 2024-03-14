using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnergyManager : MonoBehaviour
{
    
    public Slider energySlider;
    
    public int maxEnergy = 100;
    
    public int currentEnergy;
   
    public TextMeshProUGUI energyText;
   
    public GameObject energyFillObject;

    void Start()
    {
       
        currentEnergy = maxEnergy;
      
    }

 

    public void UseEnergy(int energyAmount)
    {
        currentEnergy -= energyAmount;
        if (currentEnergy <= 0)
        {
            currentEnergy = 0;
            
        }
        UpdateEnergyUI();
    }

    public void EnergyCollect(int energyAmount)
    {
        currentEnergy += energyAmount;

        if (currentEnergy > maxEnergy)
        {
            currentEnergy = maxEnergy;
        }

        UpdateEnergyUI();
    }


    void UpdateEnergyUI()
    {
        energySlider.value = (float)currentEnergy / maxEnergy;
        energyText.text = currentEnergy.ToString();

    }

}
