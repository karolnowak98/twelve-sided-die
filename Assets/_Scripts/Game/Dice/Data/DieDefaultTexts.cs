using System;
using UnityEngine;

namespace Game.Dice.Data
{
    [Serializable]
    public struct DieDefaultTexts
    {
        //Gdybym mial odina dodalbym dictionary <key, text> 
        
        [SerializeField] private string _resultText; 
        [SerializeField] private string _totalText;
        [SerializeField] private string _congratsText;
        [SerializeField] private string _illegalMoveText;
        
        public string ResultText => _resultText;
        public string TotalText => _totalText;
        public string CongratsText => _congratsText;
        public string IllegalMoveText => _illegalMoveText;
    }
}