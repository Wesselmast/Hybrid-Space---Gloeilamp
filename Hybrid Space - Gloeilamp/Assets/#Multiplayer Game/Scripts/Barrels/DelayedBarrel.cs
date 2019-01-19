public class DelayedBarrel : IBarrel {
    private float explodeTimer;
    private bool hasExploded = false;

    public DelayedBarrel(float startTimer) {
        explodeTimer = startTimer;
    }

    public void Tick(Explode explode) {
        if (explodeTimer <= 0 && !hasExploded) {
            explode();
            hasExploded = true;
        }
        else explodeTimer -= UnityEngine.Time.deltaTime;
    }
}