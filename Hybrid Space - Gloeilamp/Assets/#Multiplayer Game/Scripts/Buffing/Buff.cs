using UnityEngine;

public abstract class Buff {
    protected BuffContainer container;
    public bool IsFinished { get { return container.Duration <= 0 ? true : false; } }

    public abstract void Activate();
    protected abstract void End();

    public Buff(BuffContainer container) {
        this.container = container;
    }

    public void Tick(float time) {
        container.Duration -= time;
        if (container.Duration <= 0) End();
    }
}

public struct BuffContainer {
    public float Duration { get; set; }
    public ScriptableBuff Buff { get; set; }
    public GameObject Obj { get; set; }

    public BuffContainer(float duration, ScriptableBuff buff, GameObject obj) {
        Duration = duration;
        Buff = buff;
        Obj = obj;
    }
}