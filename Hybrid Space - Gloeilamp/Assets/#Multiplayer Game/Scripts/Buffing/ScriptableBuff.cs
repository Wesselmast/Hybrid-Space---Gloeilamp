using UnityEngine;

public abstract class ScriptableBuff : ScriptableObject {
    [SerializeField]
    private float duration;
    public float Duration { get { return duration; } }
    public abstract Buff InitializeBuff(GameObject obj);
}