using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Game.Dice.UI
{
    [Serializable]
    public struct DiePanelReferences
    {
        [SerializeField] private TextMeshProUGUI _resultTmp;
        [SerializeField] private TextMeshProUGUI _totalTmp;
        [SerializeField] private Button _rollBtn;
 
        public TextMeshProUGUI ResultTmp => _resultTmp;
        public TextMeshProUGUI TotalTmp => _totalTmp;
        public Button RollBtn => _rollBtn;
    }
}