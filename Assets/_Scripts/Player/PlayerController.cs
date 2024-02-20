using System;
using _Scripts.GlobalInterfaces;
using _Scripts.InterectableObjects;
using _Scripts.RotatableObjects;
using _Scripts.UnityExtensions;
using _Scripts.Weapons;
using UnityEngine;

namespace _Scripts.Player
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(PlayerJump))]
    [RequireComponent(typeof(PlayerInteractable))]
    [RequireComponent(typeof(PlayerInputHandler))]
    [RequireComponent(typeof(PlayerShootable))]
  
    public class PlayerController : MonoBehaviour
    {
        #region Variables
        private IMovable _movable;
        private IJumpable _jumpable;
        private IInteractable _interactable;
        private IShootable _playerShootable;
        
        private PlayerInputHandler _playerInputHandler;
        
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Animator _playerAnimatro;

        [SerializeField] private RotatableObject _rotatableObject;
        [SerializeField] private Transform _lightPivot;
        [SerializeField] private LayerMask _groundLayer;
        
        //Amunition for test
        [SerializeField] private WeaponChanger _weaponChanger;
        private Weapon _currentWeapon;
        
        [SerializeField] private Ammunition _ammunition;
        [SerializeField] private float _shootSpeed;
        [SerializeField] private float _shootDelay;
        [SerializeField] private Transform _shootPivot;

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
            _playerShootable = GetComponent<IShootable>();
            
            _playerInputHandler = GetComponent<PlayerInputHandler>();
        }

        private void Start()
        {
            _playerInputHandler.JumpEvent.AddListener(() => _jumpable.Jump(jumpForce,isGrounded,_rigidbody));
            _playerInputHandler.ShootEvent.
                AddListener(() => _playerShootable.Shoot(_ammunition,_shootSpeed,_shootPivot));
            //_playerShootable.
        }

        private void Update()
        {
            _rotatableObject?.Rotate(_playerInputHandler.MoveInput);
            _movable?.Move(moveSpeed,_playerInputHandler.MoveInput);
            //ControlParticle(_playerInputHandler.MoveInput);
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