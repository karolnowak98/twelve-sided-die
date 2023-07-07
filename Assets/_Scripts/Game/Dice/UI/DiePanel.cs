using UnityEngine;
using Zenject;
using Global.UI;
using Game.Dice.Logic;

namespace Game.Dice.UI
{
    public class DiePanel : Panel
    {
        [SerializeField] private DiePanelReferences _references;

        private Die _die;
        
        [Inject]
        private void BindDie(Die die)
        {
            _die = die;
        }

        private void Start()
        {
            UpdateResult(0);
            SetResultText();
        }

        private void OnEnable()
        {
            _die.OnStopDie += UpdateResult;
            _die.OnThrowDie += SetResultText;
            _references.RollBtn.onClick.AddListener(() => _die.ThrowDieUsingButton());
        }
        
        private void OnDisable()
        {
            _die.OnStopDie -= UpdateResult;
            _die.OnThrowDie -= SetResultText;
            _references.RollBtn.onClick.RemoveAllListeners();
        }

        private void UpdateResult(int resultNumber)
        {
            _references.TotalTmp.text = _die.DieConfig.TotalText + _die.TotalNumber;
            _references.ResultTmp.text = _die.DieConfig.ResultText + resultNumber;
        }

        private void SetResultText()
        {
            _references.ResultTmp.text = _die.DieConfig.ResultText + "?";
        }
    }
}