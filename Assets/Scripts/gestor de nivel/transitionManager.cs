using UnityEngine;
using System.Collections;

public class transitionManager : MonoBehaviour
{
	private string target = "";
	private float delay = 0.0f;

	private float waitToOut = 0.0f;
	private float fadetime = 0.0f;
	private bool isFading = false;
	private bool isFadingIn = false;
	private float alpha = 0.0f;
	private Texture2D fadeTexture;

	void Start()
	{
		DontDestroyOnLoad(transform.gameObject);

		fadeTexture = new Texture2D(1,1);
		fadeTexture.SetPixel(0, 0, new Color(0, 0, 0, 1.0f));
		fadeTexture.Apply();
		fadeTexture.wrapMode = TextureWrapMode.Repeat;
	}

	void OnGUI()
	{
		if(true == isFading)
		{
			if(true == isFadingIn)
			{
				if(1.0f > alpha)
				{
					alpha += Mathf.Clamp01(Time.deltaTime)/(fadetime * 2.0f);
				}
			}
			else
			{
				if(0.0f >= waitToOut)
				{
					if(0.0f < alpha)
					{
						alpha -= Mathf.Clamp01(Time.deltaTime)/(fadetime * 2.0f);
					}
				}
				else
				{
					waitToOut -= Time.deltaTime;
				}
			}

			if(0 >= alpha)
			{
				isFading = false;
				target = "";
				delay = 0.0f;
			}
		}

		if(0 < alpha)
		{
			Color oldColor = GUI.color;
			Color newColor = oldColor;
			newColor.a = alpha;

			GUI.color = newColor;
			GUI.DrawTextureWithTexCoords(
				new Rect(0, 0, Screen.width, Screen.height),
				fadeTexture,
				new Rect(0, 0, 1, 1)
			);
			GUI.color = oldColor;
		}
	}
	void Update()
	{
		if(true == isFading)
		{
			if(0.0f < delay && 1.0f <= alpha)
			{
				isFadingIn = false;
				Application.LoadLevel(target);
			}
		}		
		else
		{
			FadeTransition.instance = null;
			Destroy(gameObject);
		}
	}

	public void _FadeTransition(string _target)
	{
		_FadeTransition(_target, 3.0f);
	}
	public void _FadeTransition(string _target, float _delay, float _wto = 0.0f)
	{
		if(null != FadeTransition.instance)
		{
			Destroy(gameObject);
		}

		FadeTransition.instance = this;

		target = _target;
		delay = _delay;
		isFading = true;
		isFadingIn = true;

		waitToOut = _wto;
		fadetime = delay * 0.5f;
	}
}

public class FadeTransition 
{
	public static transitionManager instance = null;

	public static void FadeTo(string target)
	{
		FadeTo(target, 3.0f);
	}

	public static void FadeTo(string target, float delay, float waitToOut = 0.0f)
	{
		GameObject f = new GameObject();
		f.AddComponent<transitionManager>();
		f.GetComponent<transitionManager>()._FadeTransition(target, delay, waitToOut);
		f.transform.name = "FadeTransition";
		Object.Instantiate(f, new Vector3(0,0,0), Quaternion.identity);
	}
}
