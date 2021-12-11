using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ReplayButton : MonoBehaviour
{
	public Button restartButton;

	void Start()
	{
		Button btn = restartButton.GetComponent<Button>();
		btn.onClick.AddListener(restart);
	}

	void restart()
	{
		SceneManager.LoadScene(0);
	}
}