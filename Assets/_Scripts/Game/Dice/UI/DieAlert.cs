using Zenject;
using Global.UI;
using Game.Dice.Logic;

namespace Game.Dice.UI
{
    public class DieAlert : Alert
    {
        private Die _die;

        [Inject]
        private void Construct(Die die)
        {
            _die = die;
        }

        private void Start()
        {
            gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            _die.OnWinGame += ShowCongrats;
            _die.OnIllegalMove += ShowIllegalMove;
        }

        private void OnDestroy()
        {
            _die.OnWinGame -= ShowCongrats;
            _die.OnIllegalMove -= ShowIllegalMove;
        }

        private void ShowCongrats()
        {
            AlertTmp.gameObject.SetActive(true);
            AlertTmp.text = _die.DieConfig.CongratsText;
            WaitSecondsAndHideAlert();
        }

        private void ShowIllegalMove()
        {
            AlertTmp.gameObject.SetActive(true);
            AlertTmp.text = _die.DieConfig.IllegalMoveText;
            WaitSecondsAndHideAlert();
        }
    }
}