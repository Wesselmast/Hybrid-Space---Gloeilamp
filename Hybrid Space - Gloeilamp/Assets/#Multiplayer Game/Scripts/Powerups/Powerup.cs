public abstract class Powerup : IPowerup {
    protected readonly IDestroyable destroy;
    protected Powerup(IDestroyable destroy) {
        this.destroy = destroy;
    }
    public abstract void PowerUp();
}