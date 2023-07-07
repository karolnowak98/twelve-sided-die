using UnityEngine;
using Zenject;
using Game.Dice.Data;

namespace Game.Dice.Logic
{
    public class DieInstaller : MonoInstaller
    {
        [SerializeField] private DieConfig _dieConfig;
        [SerializeField] private Rigidbody _rb;

        public override void InstallBindings()
        {
            Container.BindInstance(_dieConfig);
            Container.BindInterfacesAndSelfTo<Die>().AsSingle().WithArguments(_rb);
        }
    }
}