using UnityEngine;

public interface ILightControl
{
    public void SetLight(Transform lightTransform);
    public GameObject GrabLight();

    public bool CheckLight();
}
