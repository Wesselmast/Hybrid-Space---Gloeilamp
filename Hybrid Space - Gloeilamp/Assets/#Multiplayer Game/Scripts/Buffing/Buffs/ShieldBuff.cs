using UnityEngine;

public class ShieldBuff : Buff {
    private ScriptableShieldBuff settings;
    private DestroyBoat destroyBoat;
    private GameObject shieldSphere;

    public ShieldBuff(float duration, ScriptableBuff buff, GameObject obj) : base(duration, buff, obj) {
        destroyBoat = obj.GetComponent<DestroyBoat>();
        settings = (ScriptableShieldBuff)buff;
        shieldSphere = obj.transform.GetChild(0).gameObject;
    }

    public override void Activate() {
        destroyBoat.enabled = false;
        shieldSphere.SetActive(true);

    }

    protected override void End() {
        destroyBoat.enabled = true;
        shieldSphere.SetActive(false);
    }
}
