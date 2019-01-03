public delegate void Del();

public interface IBarrel {
    void Tick(Del explode);
}