﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenFader : MonoBehaviour
{
	public Image FadeImg;
	public float fadeSpeed = 1.5f;
	public bool sceneStarting = true;
	public bool sceneEnding = false;
	public int sceneNum = 1;
	AudioSource music;
	
	
	void Awake()
	{
		FadeImg.rectTransform.localScale = new Vector2(Screen.width, Screen.height);
		music = GameObject.FindObjectOfType<AudioSource>();
	}
	
	void Update()
	{
		// If the scene is starting...
		if (sceneStarting)
			// ... call the StartScene function.
			StartScene();
		// If the scene is ending...
		if (sceneEnding)
			// ... call the StartScene function.
			EndScene(sceneNum);
	}
	
	
	void FadeToClear()
	{
		// Lerp the colour of the image between itself and transparent.
		FadeImg.color = Color.Lerp(FadeImg.color, Color.clear, fadeSpeed * Time.deltaTime);
	}
	
	
	void FadeToBlack()
	{
		// Lerp the colour of the image between itself and black.
		FadeImg.color = Color.Lerp(FadeImg.color, Color.black, fadeSpeed * Time.deltaTime);
	}
	
	
	void StartScene()
	{
		// Fade the texture to clear.
		FadeToClear();
		
		// If the texture is almost clear...
		if (FadeImg.color.a <= 0.05f)
		{
			// ... set the colour to clear and disable the RawImage.
			FadeImg.color = Color.clear;
			FadeImg.enabled = false;
			
			// The scene is no longer starting.
			sceneStarting = false;
		}
	}
	
	
	public void EndScene(int SceneNumber)
	{
		// Make sure the RawImage is enabled.
		FadeImg.enabled = true;

		if (!sceneEnding) {
			sceneEnding = true;
		}

		// Fading out music (using same speed as Black Fade Out 
		if (music.volume > .1F) {
			music.volume = Mathf.Lerp(music.volume, 0F,fadeSpeed * Time.deltaTime); 
		}
		
		// Start fading towards black.
		FadeToBlack();
		// If the screen is almost black...
		if (FadeImg.color.a >= 0.95f) {
			Debug.Log("TRIGGERED!");
			// ... reload the level
			Application.LoadLevel (SceneNumber);
		}
	}
}   