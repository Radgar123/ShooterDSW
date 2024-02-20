using System;
using _Scripts.InterectableObjects;
using _Scripts.RotatableObjects;
using _Scripts.UnityExtensions;
using UnityEngine;

namespace _Scripts.Player
{
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(PlayerJump))]
    [RequireComponent(typeof(PlayerInteractable))]
    [RequireComponent(typeof(PlayerInputHandler))]
  
    public class PlayerController : MonoBehaviour
    {
        #region Variables
        private IMovable _movable;
        private IJumpable _jumpable;
        private IInteractable _interactable;
        private PlayerInputHandler _playerInputHandler;

        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private Rigidbody _rigidbody;

        [SerializeField] private RotatableObject _rotatableObject;
        [SerializeField] private Transform _lightPivot;
        [SerializeField] private LayerMask _groundLayer;

        public Transform _currentLightTransform;
        public bool isInteract 
        {
            get
            {
                Debug.Log("Value Is get: " + _playerInputHandler.InteractInput);
                return _playerInputHandler.InteractInput;
            }
            set
            {
                _playerInputHandler.InteractInput = value;
            }
        }
        public bool isGrounded;
        
        [SerializeField] private int groundContactCount = 0;
        

        [SerializeField] private IInteractable _currentInteractable;

        public float moveSpeed = 5f;
        public float jumpForce = 5f;
        #endregion
        
        #region Base Methods
        private void Awake()
        {
            _movable = GetComponent<IMovable>();
            _jumpable = GetComponent<IJumpable>();
            _interactable = GetComponent<IInteractable>();
            _playerInputHandler = GetComponent<PlayerInputHandler>();
        }

        private void Start()
        {
            _playerInputHandler.JumpEvent.AddListener(() => _jumpable.Jump(jumpForce,isGrounded,_rigidbody));
        }

        private void Update()
        {
            _rotatableObject?.Rotate(_playerInputHandler.MoveInput);
            _movable?.Move(moveSpeed,_playerInputHandler.MoveInput);
            ControlParticle(_playerInputHandler.MoveInput);
        }
        #endregion
        
        #region Triggers

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<IInteractable>(out IInteractable interactable))
            {
                interactable?.StartInteract();
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent<IInteractable>(out IInteractable interactable))
            {
                interactable?.StayInInteract();
            }
            
            if (other.TryGetComponent<InteractableLightHandler>(out InteractableLightHandler lightControl) && isInteract)
            {
                isInteract = false;
                
                if (lightControl.withLight)
                {
                    _currentLightTransform = lightControl.GrabLight().transform;
                    lightControl.InteractionWithLights(_lightPivot,_currentLightTransform);
                }
                else
                {
                    lightControl._lightObject = _currentLightTransform.gameObject;
                    lightControl.InteractionWithLights(_lightPivot,_currentLightTransform);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<IInteractable>(out IInteractable interactable))
            {
                interactable?.EndInteract();
            }
        }

        #endregion

        #region Collisions
        
        private void OnCollisionEnter(Collision other)
        {
            if (_groundLayer.Contains(other.gameObject.layer))
            {
                groundContactCount++;
                isGrounded = _jumpable.IsGrounded(_groundLayer, other);
            }
        }

        private void OnCollisionExit(Collision other)
        {
            if (_groundLayer.Contains(other.gameObject.layer))
            {
                groundContactCount--;
                if (groundContactCount <= 0)
                {
                    isGrounded = false;
                    groundContactCount = 0;
                }
            }
        }

        #endregion

        #region Particle

        public void ControlParticle(Vector2 moveInput)
        {
            if (moveInput.sqrMagnitude > 0)
            {
                if (!_particleSystem.isPlaying)
                {
                    _particleSystem.Play();
                }
            }
            else
            {
                if (_particleSystem.isPlaying)
                {
                    _particleSystem.Stop();
                }
            }
        }
        #endregion
    }
}