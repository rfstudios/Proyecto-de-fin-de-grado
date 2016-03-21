using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour 
{
	public GUISkin gui_ac;
	static private int p=0;
	static private int p_total=0;
	static private int v=3;

	private bool puert;

	public int puntuacion
	{
		get
		{
			return p;
		}
		set
		{
			p=value;
			if(p<0)
			{
				p=0;
			}
			if(p>=100)
			{
				p=0;
				vida++;
			}
		}
	}

	public int vida
	{
		get
		{
			return v;
		}
		set
		{
			v=value;
		}
	}

	public void OnGUI()
	{
		int v = vida;
		if(0 > v) v = 0;

		GUI.skin = gui_ac;
		GUI.Label(new Rect (40, 5, 300, 50)," x"+v.ToString());	
		GUI.Label(new Rect (40, 53, 300, 50)," x"+puntuacion.ToString());		
	}
}
