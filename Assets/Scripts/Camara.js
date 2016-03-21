#pragma strict

public var xMin:int=0;
public var xMax:int=0;
private var prota:GameObject;
protected var limites:Transform[];

function Start () 
{
	prota=GameObject.FindWithTag("Player");
	limites=new Transform[4];
	limites[0]=GameObject.FindWithTag("Arriba").transform;
	limites[1]=GameObject.FindWithTag("Abajo").transform;
	limites[2]=GameObject.FindWithTag("Izquierda").transform;
	limites[3]=GameObject.FindWithTag("Derecha").transform;
	
}

function Update () 
{
	if(prota.transform.position.x-17>limites[2].position.x && prota.transform.position.x+17<limites[3].position.x)
	{
		transform.position.x=prota.transform.position.x;
	}
	
	if(prota.transform.position.y<(transform.position.y-10) && transform.position.y-10>=limites[1].position.y)
	{
		transform.position.y-=20;
	}
	else if(prota.transform.position.y>(transform.position.y+10) && transform.position.y+10<=limites[0].position.y)
	{
		transform.position.y+=20;
	}
}