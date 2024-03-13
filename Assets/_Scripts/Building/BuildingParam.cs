using System.Collections.Generic;

namespace _Scripts.Building
{
    [System.Serializable]
    public class BuildingParam
    {
        public BuildingItem[] buildingItems;
        public BuildingItem currentBuildingItem;
        public float buildingDelay = 0.1f;

        public void BuildingItemById(int id)
        {
            currentBuildingItem = buildingItems[id];
        }
    }
}