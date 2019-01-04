using UnityEngine;

public abstract class Buff {
    protected float duration;
    protected ScriptableBuff buff;
    protected GameObject obj;
    public bool IsFinished { get { return duration <= 0 ? true : false; } }

    public abstract void Activate();
    protected abstract void End();

    public Buff(float duration, ScriptableBuff buff, GameObject obj) {
        this.duration = duration;
        this.buff = buff;
        this.obj = obj;
    }

    public void Tick(float time) {
        duration -= time;
        if (duration <= 0) End();
    }
}
