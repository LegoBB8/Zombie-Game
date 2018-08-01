using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	public string sceneName;
	public float loadDelay=0;

	public void LoadScene () {
		Invoke("StartChange", loadDelay);
	}

	void StartChange() {
		SceneManager.LoadScene (sceneName);
	}
}
