using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour {

	[SerializeField]
    private float speed;       
    private Transform targetPoint;
	int wayPointIndex = 0;
	
	private float lives;
	[SerializeField]
	private float startLives;

	[SerializeField]
	private Image hpImage;

	[SerializeField]
	private Transform camera;


	private Quaternion startRotation;
	void Start () {
		targetPoint = Points.points[0];
		lives = startLives;
		startRotation = hpImage.transform.rotation;
	}
		
	public float GetLives(){
		return lives;
	}

	public void SetLives(int count){
		lives -= count;
		var currentX = (lives/startLives)*hpImage.transform.localScale.x;
		hpImage.transform.localScale= new Vector3(currentX ,hpImage.transform.localScale.y,hpImage.transform.localScale.z);
	}

	public float GetStartLives(){
		return startLives;
	}

	public void SetStartLives(int count){
		startLives += count;
	}

	void Update () {
        transform.LookAt(targetPoint.position);
		//hpImage.transform.LookAt(camera.position);
        this.transform.position = Vector3.MoveTowards(this.transform.position, targetPoint.position, Time.deltaTime * speed);
        if(Vector3.Distance(transform.position, targetPoint.position) < 0.5f){
           GetNextPoint();
        } 
		hpImage.transform.rotation = startRotation;
	}

	private void GetNextPoint(){
		if(wayPointIndex >= Points.points.Length-1){
			PlayerStats.Lives -= 1;
			Destroy(gameObject);
			return;
		}			
		wayPointIndex++;
		targetPoint = Points.points[wayPointIndex];
	}
}
