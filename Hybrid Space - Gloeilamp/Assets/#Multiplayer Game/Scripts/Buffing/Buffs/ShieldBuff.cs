using UnityEngine;

public class ShieldBuff : Buff {
    private ScriptableShieldBuff settings;
    private DestroyBoat destroyBoat;

    public ShieldBuff(float duration, ScriptableBuff buff, GameObject obj) : base(duration, buff, obj) {
        destroyBoat = obj.GetComponent<DestroyBoat>();
        settings = (ScriptableShieldBuff)buff;
    }

    public override void Activate() {
        destroyBoat.enabled = false;
    }

    protected override void End() {
        destroyBoat.enabled = true;
    }
}
