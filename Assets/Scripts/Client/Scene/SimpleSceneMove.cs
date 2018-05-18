using UnityEngine;
using UnityEngine.SceneManagement;
public class SimpleSceneMove : MonoBehaviour {
	public void OnButton (string sceneName) {
        SceneManager.LoadScene(sceneName);
	}
}