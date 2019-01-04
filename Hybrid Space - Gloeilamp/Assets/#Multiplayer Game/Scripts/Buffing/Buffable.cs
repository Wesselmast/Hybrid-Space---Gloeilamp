using System.Collections.Generic;
using UnityEngine;

public class Buffable : MonoBehaviour {

    private List<Buff> activeBuffs = new List<Buff>();

	private void Update () {
        foreach (Buff buff in activeBuffs.ToArray()) {
            buff.Tick(Time.deltaTime);
            if (buff.IsFinished) activeBuffs.Remove(buff);
        }
    }

    public void AddBuff(ScriptableBuff scriptableBuff) {
        Buff buff = scriptableBuff.InitializeBuff(gameObject);
        buff.Activate();
        activeBuffs.Add(buff);
    }
}
