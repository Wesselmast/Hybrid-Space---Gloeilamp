using UnityEngine;

public class BarrelBarrage : Powerup {
    private readonly Del spawnBarrels;

    public BarrelBarrage(IDestroyable destroy, Del spawnBarrels) : base(destroy) {
        this.spawnBarrels = spawnBarrels;
    }

    public override void PowerUp() {
        spawnBarrels();
    }
}