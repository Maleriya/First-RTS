using Zenject;

public class CoreInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<TimeModel>().AsSingle();

        // если появится еще лишний интерфейс, для которого не нужна привязка, то будет актуально это
        // Container.Bind(typeof(ITimeModule), typeof(ITickable)).To(typeof(TimeModel)).AsSingle();
    }
}
