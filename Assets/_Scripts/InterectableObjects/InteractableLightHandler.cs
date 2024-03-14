using System;
using Sirenix.OdinInspector;
//using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Events;

namespace _Scripts.InterectableObjects
{
    public class InteractableLightHandler : InteractableObject, ILightControl
    {
        [Header("Interactable Lights")]
        #region Variable
        [SerializeField] private Transform _lightPivot;
        public GameObject _lightObject;

        public bool withLight;

        [FoldoutGroup("Interactable Light Handler Events")]
        public UnityEvent OnSetLight, OnGrabLight;
        #endregion

        #region Light Control Methods

        private void Awake()
        {
            _lightObject.transform.localPosition = _lightPivot.localPosition;

            if (_lightObject)
                withLight = true;
        }

        public void SetLight(Transform lightTransform)
        {
           OnSetLight?.Invoke();
        }

        public GameObject GrabLight()
        {
            return _lightObject;
        }

        public bool CheckLight()
        {
            throw new NotImplementedException();
        }


        public void InteractionWithLights(Transform lightPivot, Transform currentLight)
        {
            if (withLight)
            {
                _lightObject.transform.SetParent(lightPivot);
                currentLight = _lightObject.transform;
                _lightObject.transform.localPosition = new Vector3(0, 0, 0);
                _lightObject = null;
                withLight = false;
                OnGrabLight?.Invoke();
            }
            else
            {
                _lightObject.transform.SetParent(_lightPivot);
                _lightObject.transform.localPosition = new Vector3(0, 0, 0);
                withLight = true;
                OnSetLight?.Invoke();
            }
        }
        
        #endregion
    }
}