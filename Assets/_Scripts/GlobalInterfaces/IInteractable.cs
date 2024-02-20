using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public void StartInteract();
    public void StayInInteract();
    public void EndInteract();
    public void TriggerEvent();
}
