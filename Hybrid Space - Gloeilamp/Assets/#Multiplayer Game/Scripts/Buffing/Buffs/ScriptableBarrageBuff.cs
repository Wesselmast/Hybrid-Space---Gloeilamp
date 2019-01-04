using UnityEngine;

[CreateAssetMenu(menuName = "Buffs/BarrageBuff", fileName = "New Buff")]
public class ScriptableBarrageBuff : ScriptableBuff {
    [Range(0.33f, 5f)]
    [SerializeField]
    private float interval;
    public float Interval { get { return interval; } }

    public override Buff InitializeBuff(GameObject obj) {
        return new BarrageBuff(Duration, this, obj);
    }
}