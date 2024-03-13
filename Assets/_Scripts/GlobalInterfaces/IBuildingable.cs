using System.Collections;
using System.Collections.Generic;
using _Scripts.Building;
using UnityEngine;

public interface IBuildingable
{
    public void Build(BuildingItem buildingItem);
}
