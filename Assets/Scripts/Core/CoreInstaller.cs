using Zenject;
using UnityEngine;

public class CoreInstaller : MonoInstaller
{
    [SerializeField] private GameStatus _gameStatus;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<TimeModel>().AsSingle();
        Container.Bind<IGameStatus>().FromInstance(_gameStatus);

        // если появится еще лишний интерфейс, для которого не нужна привязка, то будет актуально это
        // Container.Bind(typeof(ITimeModule), typeof(ITickable)).To(typeof(TimeModel)).AsSingle();
    }
}
