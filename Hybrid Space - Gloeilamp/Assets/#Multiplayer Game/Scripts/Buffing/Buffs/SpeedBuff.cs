using UnityEngine;

public class SpeedBuff : Buff {
    private ScriptableSpeedBuff settings;
    private BoatEngine engine;

    public SpeedBuff(BuffContainer container) : base(container) {
        engine = container.Obj.GetComponent<BoatEngine>();
        settings = (ScriptableSpeedBuff)container.Buff;
    }

    public override void Activate() {
        engine.accelerationSpeed += settings.SpeedIncrease;
    }

    protected override void End() {
        engine.accelerationSpeed -= settings.SpeedIncrease;
    }
}