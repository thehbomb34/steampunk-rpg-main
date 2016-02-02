﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OnClick : MonoBehaviour {

	public Slider loadingBar;
	public GameObject loadingImage;


	private AsyncOperation async;

	public void ClickAsync(string sceneName)
	{
		loadingImage.SetActive(true);
		StartCoroutine(LoadLevelWithBar(sceneName));
	}


	IEnumerator LoadLevelWithBar (string sceneName)
	{
		async = Application.LoadLevelAsync(sceneName);
		while (!async.isDone)
		{
			loadingBar.value = async.progress;
			yield return null;
		}
	}

	public void QuitScene() {
		Application.Quit ();
	}
}
