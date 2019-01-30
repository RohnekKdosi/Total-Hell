using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour {
	
	public float minParam;
	public float maxParam;
	public float parameter;
	
	void Start () {
		if (minParam > maxParam) {
			/* Can't use the (a,b) = (b,a); because for some reason this thing uses C# 4.0 */
			float tmp = minParam;
			minParam = maxParam;
			maxParam = tmp;
		}
	}
	
	void Update () {
		if (parameter < minParam) 
			parameter = maxParam;
		else if (parameter > maxParam)
			parameter = minParam;
	}
}
