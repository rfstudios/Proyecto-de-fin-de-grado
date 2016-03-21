using UnityEngine;
using System.Collections;

public class splashscreen : MonoBehaviour
{
	public AudioClip fx;

	void Start()
	{
		Invoke("cargar", 3.0f);
		SoundManager.PlayFX(fx);
	}

	public void cargar()
	{
		FadeTransition.FadeTo("gestor");
	}
}
