using System;
using UnityEngine;

namespace Game.Dice.Data
{
    [Serializable]
    [CreateAssetMenu(menuName = "Configs/Die Config", fileName = "Die Config")]
    public class DieConfig : ScriptableObject
    {
        //Gdybym mial odina dodalbym BoxGroups
        [SerializeField] private Vector2 _rollButtonForceRange; //Gdybym mial odina dodalbym MinMaxSlider
        [SerializeField] private Vector2 _mouseButtonForceRange; //Gdybym mial odina dodalbym MinMaxSlider
        [SerializeField] private float _holdingHeight;
        [SerializeField] private float _minRotationThreshold;
        [SerializeField, Range(0, 25)] private float _maxRotationDifference;
        [SerializeField, Range(0, 12)] private int _startingTotalNumber;
        [SerializeField, Range(12, 500)] private int _maxTotalNumber;
        [SerializeField] private bool _addRandomTorque; 
        [SerializeField] private float _randomTorqueForce; //Gdybym mial odina dodalbym showif _addRandomTorque
        [SerializeField] private DieDefaultTexts _defaultTexts;

        public Vector2 RollButtonForceRange => _rollButtonForceRange;
        public Vector2 MouseButtonForceRange => _mouseButtonForceRange;
        public float HoldingHeight => _holdingHeight;
        public float MinRotationThreshold => _minRotationThreshold;
        public float MaxRotationDifference => _maxRotationDifference;
        public int StartingTotalNumber => _startingTotalNumber;
        public int MaxTotalNumber => _maxTotalNumber;
        public bool AddRandomTorque => _addRandomTorque;
        public float RandomTorqueForce => _randomTorqueForce;
        public string ResultText => _defaultTexts.ResultText;
        public string TotalText => _defaultTexts.TotalText;
        public string CongratsText => _defaultTexts.CongratsText;
        public string IllegalMoveText => _defaultTexts.IllegalMoveText;
    }
}