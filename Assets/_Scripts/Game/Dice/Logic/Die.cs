using System;
using UnityEngine;
using Random = UnityEngine.Random;
using Zenject;
using Input.Logic;
using Game.Dice.Data;

namespace Game.Dice.Logic
{
    //Jest możliwość podziału klasy na mniejsze np. odpowiedzialnej za fizyke, input oraz np. rozdzielnie eventów do oddzielnej, jednakże ja uważam, że rozmiar tej klasy jest akceptowalny
    public class Die : IInitializable, IDisposable, ITickable, IFixedTickable
    {
        private InputManager _inputManager;
        private DieConfig _dieConfig;
        private Rigidbody _rigidbody;
        private Transform _transform;
        private TwelveSidedDieCoords _coords;
        private Camera _camera;
        private Vector3 _initialPosition;
        private Vector3 _throwStartPosition;
        private Vector3 _throwEndPosition;
        private Quaternion _initialRotation;
        private LayerMask _floorLayer;
        private bool _isHeld;
        private bool _isMoving;
        private int _totalNumber;

        public int TotalNumber
        {
            private set
            {
                _totalNumber = Mathf.Clamp(value, 0, _dieConfig.MaxTotalNumber);

                if (_totalNumber == _dieConfig.MaxTotalNumber)
                {
                    OnWinGame?.Invoke();
                }
            }
            get => _totalNumber;
        }

        public DieConfig DieConfig => _dieConfig;

        public event Action OnThrowDie;
        public event Action<int> OnStopDie; // <resultNumber>
        public event Action OnWinGame;
        public event Action OnIllegalMove;

        [Inject]
        private void Construct(InputManager inputManager, DieConfig dieConfig, Rigidbody rigidbody)
        {
            _inputManager = inputManager;
            _dieConfig = dieConfig;
            _rigidbody = rigidbody;
            _transform = rigidbody.transform;

            _coords = new TwelveSidedDieCoords();
        }

        public void Initialize()
        {
            _camera = Camera.main;
            _floorLayer = LayerMask.GetMask("Floor");
            _initialPosition = _transform.position;
            _initialRotation = _transform.rotation;
            TotalNumber = _dieConfig.StartingTotalNumber;

            _inputManager.OnLmbPressed += HoldDie;
            _inputManager.OnLmbCanceled += ThrowDieUsingMouse;
        }

        public void Dispose()
        {
            _inputManager.OnLmbPressed -= HoldDie;
            _inputManager.OnLmbCanceled -= ThrowDieUsingMouse;
        }

        public void Tick()
        {
            if (!_isHeld) return;
            if (!RaycastFloor( out var hit)) return;

            var targetPosition = new Vector3(hit.point.x, _initialPosition.y * _dieConfig.HoldingHeight, hit.point.z);
            
            _transform.position = _throwEndPosition = targetPosition;
        }

        public void FixedTick()
        {
            if (_isMoving && _rigidbody.IsSleeping())
            {
                _isMoving = false;
                CalculateResult();
            }
        }

        public void ThrowDieUsingButton()
        {
            if (_isMoving) return;
            
            var throwDirection = Random.insideUnitCircle.normalized;
            var throwForce = Random.Range(_dieConfig.RollButtonForceRange.x, _dieConfig.RollButtonForceRange.y);
            var throwVector = new Vector3(throwDirection.x, 0f, Mathf.Max(throwDirection.y, 0f)) * throwForce;
            
            _transform.position = _initialPosition;

            ThrowDie(throwVector, throwForce);
        }

        private void HoldDie()
        {
            if (_isMoving || !RaycastFloor( out _)) return;
    
            _isHeld = true;
            _isMoving = false;
            _throwStartPosition = InputManager.GetMouseWorldPosition(_floorLayer);
            _throwEndPosition = _throwStartPosition;
            
            ResetDie();
        }

        private void ThrowDieUsingMouse()
        {
            if (_isMoving) return;
            if (!RaycastFloor( out _)) return;

            var throwStartPosition = _throwStartPosition;
            var throwDistance = Vector3.Distance(_throwEndPosition, throwStartPosition);
            var throwForce = Mathf.Lerp(_dieConfig.MouseButtonForceRange.x, _dieConfig.MouseButtonForceRange.y, throwDistance);

            ThrowDie((_throwEndPosition - throwStartPosition).normalized, throwForce);
        }

        private void ThrowDie(Vector3 throwDirection, float throwForce)
        {
            _rigidbody.AddForce(throwDirection * throwForce, ForceMode.Impulse);

            if (_dieConfig.AddRandomTorque)
            {
                var randomTorque = Random.insideUnitSphere * _dieConfig.RandomTorqueForce;
                _rigidbody.AddTorque(randomTorque, ForceMode.Impulse);
            }

            _isHeld = false;
            _isMoving = true;

            OnThrowDie?.Invoke();
        }

        private void CalculateResult()
        {
            var rotation = _transform.rotation;
            var currentCoordinates = new Vector2(rotation.eulerAngles.x, rotation.eulerAngles.z);
            var rotationDifference = Quaternion.Angle(rotation, _initialRotation);

            if (rotationDifference < _dieConfig.MinRotationThreshold)
            {
                OnIllegalMove?.Invoke();
                return;
            }

            var result = _coords.GetSideByCoordinates(currentCoordinates, _dieConfig.MaxRotationDifference);

            if (result == 0)
            {
                OnIllegalMove?.Invoke();
                return;
            }

            TotalNumber += result;
            OnStopDie?.Invoke(result);
        }

        private void ResetDie()
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
            _initialRotation = _transform.rotation;
            _transform.position = _throwStartPosition;
        }
        
        private bool RaycastFloor(out RaycastHit hit) => Physics.Raycast(_camera.ScreenPointToRay(InputManager.MousePosition), out hit, Mathf.Infinity, _floorLayer);
    }
}