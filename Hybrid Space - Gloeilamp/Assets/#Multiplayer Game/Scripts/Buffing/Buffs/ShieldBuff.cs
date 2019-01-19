using UnityEngine;

public class ShieldBuff : Buff {
    private ScriptableShieldBuff settings;
    private DestroyBoat destroyBoat;
    private GameObject shieldSphere;

    public ShieldBuff(BuffContainer container) : base(container) {
        destroyBoat = container.Obj.GetComponent<DestroyBoat>();
        settings = (ScriptableShieldBuff)container.Buff;
        shieldSphere = container.Obj.transform.GetChild(0).gameObject;
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
