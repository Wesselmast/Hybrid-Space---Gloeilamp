using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

    [SerializeField]
    private string sceneName;

	void Update () {
        if (Input.GetKey(KeyCode.Return)) SceneManager.LoadScene(sceneName);
	}
}
