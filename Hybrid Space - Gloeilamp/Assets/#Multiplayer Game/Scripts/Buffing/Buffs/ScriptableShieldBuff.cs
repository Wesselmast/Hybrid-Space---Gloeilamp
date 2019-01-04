using UnityEngine;

[CreateAssetMenu(menuName = "Buffs/ShieldBuff", fileName = "New Buff")]
public class ScriptableShieldBuff : ScriptableBuff {
    public override Buff InitializeBuff(GameObject obj) {
        return new ShieldBuff(Duration, this, obj);
    }
}