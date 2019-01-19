public delegate void Explode();

public interface IBarrel {
    void Tick(Explode explode);
}