using System.Collections;
using System.Collections.Generic;
using _Scripts.Building;
using UnityEngine;

public class PlayerBuilding : MonoBehaviour, IBuildingable
{
    public bool toBuild = false;
    public EnergyManager energyManager;
    
    public void Build(BuildingItem buildingItem, Transform buildPivot)
    {
        /*if (toBuild)
        {
            GameObject build = Instantiate(buildingItem.itemToBuild, buildPivot);
        }*/
        
        if(energyManager.currentEnergy >= 20)
        {
            GameObject build = Instantiate(buildingItem.itemToBuild, buildPivot);
            build.transform.SetParent(null);
          
        }
     
    }

    public void ViewOnPlayerBuild(BuildingItem buildingItem, Transform buildPivot)
    {
        toBuild = true;
        if (!toBuild)
        {
            buildingItem.exampleToBuild.SetActive(true);
            toBuild = true;
        }
        else
        {
            buildingItem.exampleToBuild.SetActive(false);
            toBuild = false;
        }
        
    }
}
