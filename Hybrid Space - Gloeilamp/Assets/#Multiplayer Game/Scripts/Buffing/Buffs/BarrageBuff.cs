using System.Collections;
using UnityEngine;

public class BarrageBuff : Buff {
    private ScriptableBarrageBuff settings;
    private ItemDropper dropper;
    private Animation barrelReleaseAnim;

    public BarrageBuff(BuffContainer container) : base(container) {
        dropper = container.Obj.GetComponent<ItemDropper>();
        settings = (ScriptableBarrageBuff)container.Buff;
        barrelReleaseAnim = dropper.barrelReleaseAnim;
    }

    public override void Activate() {
        dropper.StartCoroutine(BarrelBarrage());
        barrelReleaseAnim.Play();
    }

    private IEnumerator BarrelBarrage() {
        while (container.Duration > 0) {
            dropper.InstantiateBarrel();
            yield return new WaitForSeconds(settings.Interval);
        }
    }

    protected override void End() { }
}
