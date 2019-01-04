using System.Collections;
using UnityEngine;

public class BarrageBuff : Buff {
    private ScriptableBarrageBuff settings;
    private ItemDropper dropper;

    public BarrageBuff(float duration, ScriptableBuff buff, GameObject obj) : base(duration, buff, obj) {
        dropper = obj.GetComponent<ItemDropper>();
        settings = (ScriptableBarrageBuff)buff;
    }

    public override void Activate() {
        dropper.StartCoroutine(BarrelBarrage());
    }

    private IEnumerator BarrelBarrage() {
        while (duration > 0) {
            dropper.InstantiateBarrel();
            yield return new WaitForSeconds(settings.Interval);
        }
    }

    protected override void End() { }
}
