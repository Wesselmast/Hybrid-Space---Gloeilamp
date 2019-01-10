using UnityEngine;

public class FMODCom {
    private FMOD.Studio.EventInstance FMODEvent;
    FMOD.Studio.PLAYBACK_STATE playbackState;

    public FMODCom(string eventName) {
        //FMODUnity.RuntimeManager.StudioSystem.setNumListeners(2);
        //FMODEvent = FMODUnity.RuntimeManager.CreateInstance("event:/" + eventName);
    }

    public void Play3D(Transform transform, Rigidbody rb) {
        //FMODUnity.RuntimeManager.AttachInstanceToGameObject(FMODEvent, transform, rb);
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
       // Play();
    }

    public void SetParameter(string name, float amt) {
       // FMOD.Studio.ParameterInstance par;
=======
        //Play();
    }

    public void SetParameter(string name, float amt) {
        //FMOD.Studio.ParameterInstance par;
>>>>>>> Stashed changes
=======
        //Play();
    }

    public void SetParameter(string name, float amt) {
        //FMOD.Studio.ParameterInstance par;
>>>>>>> Stashed changes
=======
        //Play();
    }

    public void SetParameter(string name, float amt) {
        //FMOD.Studio.ParameterInstance par;
>>>>>>> Stashed changes
        //FMODEvent.getParameter(name, out par);
        //par.setValue(amt);
    }

    public void Play() {
        //FMODEvent.getPlaybackState(out playbackState);
        //if (playbackState != FMOD.Studio.PLAYBACK_STATE.STOPPED) return;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
       // FMODEvent.start();
=======
        //FMODEvent.start();
>>>>>>> Stashed changes
=======
        //FMODEvent.start();
>>>>>>> Stashed changes
=======
        //FMODEvent.start();
>>>>>>> Stashed changes
    }
}