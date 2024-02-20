using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace _Scripts.InterectableObjects
{
    public abstract class InteractableObject : MonoBehaviour, IInteractable
    {
        #region Variables
        [Header("Interactable")]
        [SerializeField] protected bool inInteract;
        [FoldoutGroup("Interactable States Events")]
        public UnityEvent OnInteractStart, OnInteractStay, OnInteractEnd;
        public bool InteractStatus
        {
            protected set { inInteract = value; }
            get { return inInteract; }
        }
        #endregion
        
        #region Interact Events

        public virtual void StartInteract()
        {
            SetInteractionStatus(true);
            OnInteractStart?.Invoke();
        }

        public virtual void StayInInteract()
        {
            OnInteractStay?.Invoke();
        }

        public virtual void EndInteract()
        {
            SetInteractionStatus(false);
            OnInteractEnd?.Invoke();
        }

        public void TriggerEvent()
        {
            Debug.Log("Custom Event is Empty");
        }

        #endregion

        #region Base Interact Methods

        protected void SetInteractionStatus(bool interactStatus)
        {
            InteractStatus = interactStatus;
        }

        #endregion
       
    }
}