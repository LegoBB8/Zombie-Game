using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowLife : MonoBehaviour {

	Text text;
	PlayerLife playerlife; 

	void Start () {
		text = GetComponent<Text>();
		playerlife = (PlayerLife) FindObjectOfType(typeof(PlayerLife));

	}

	void Update () {
		text.text = "Life: " + Mathf.Floor(playerlife.life).ToString();
	}
}
