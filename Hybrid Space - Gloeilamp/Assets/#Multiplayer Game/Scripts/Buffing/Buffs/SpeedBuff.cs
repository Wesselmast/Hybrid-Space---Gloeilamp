using UnityEngine;

public class SpeedBuff : Buff {
    private ScriptableSpeedBuff settings;
    private BoatEngine engine;

    public SpeedBuff(float duration, ScriptableBuff buff, GameObject obj) : base(duration, buff, obj) {
        engine = obj.GetComponent<BoatEngine>();
        settings = (ScriptableSpeedBuff)buff;
    }

    public override void Activate() {
        engine.AccelerationSpeed += settings.SpeedIncrease;
    }

    protected override void End() {
        engine.AccelerationSpeed -= settings.SpeedIncrease;
    }
}