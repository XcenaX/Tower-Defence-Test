using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour {

	[SerializeField]
    private float speed;       
    public static Transform[] points;
    int curWayPoint = 0;
	private void Awake() {
		points = new Transform[transform.childCount];
		for(int i = 0 ; i < transform.childCount;i++){
			points[i] = transform.GetChild(i);
		}
		Debug.Log("Length array: " + points.Length);
	}

}
