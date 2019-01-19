using UnityEngine;

[CreateAssetMenu(menuName = "Buffs/SpeedBuff", fileName = "New Buff")]
public class ScriptableSpeedBuff : ScriptableBuff {
    [SerializeField]
    private float speedIncrease;
    public float SpeedIncrease { get { return speedIncrease; } }

    public override Buff InitializeBuff(GameObject obj) {
        return new SpeedBuff(new BuffContainer(Duration, this, obj));
    }
}