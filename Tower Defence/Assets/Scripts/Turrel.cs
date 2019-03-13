using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrel : MonoBehaviour {

	[Header("Shooting Settings")]
	[SerializeField]
	private float radius;
	private Transform target;

	[SerializeField]
	private Bullet bullet;
	[SerializeField]
	private Transform firePoint;
	[SerializeField]
	private float fireRate;
	private float fireCountDown = 0;

	private List<Transform> enemies = new List<Transform>();

	[SerializeField]
	private Transform partToRotate;
	[SerializeField]
	private float speedRotation;


	void Start () {
		InvokeRepeating("CheckTarget", 0f,0.3f);
	}
		
	private void CheckTarget(){
		var enemies = GameObject.FindGameObjectsWithTag("Enemy");
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;

		for(int i = 0 ; i < enemies.Length;i++){
			var enemy = enemies[i];
			var distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
			if(distanceToEnemy < shortestDistance){
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
			if(nearestEnemy != null && shortestDistance <= radius){
				target = nearestEnemy.transform;
			}
			else{
				target = null;
			}
		}
	}

	private void OnDrawGizmosSelected(){
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(transform.position, radius);
	}

	void Update () {
		if(target==null)return;
		Rotate();

		if(fireCountDown <= 0){
			Shoot();
			fireCountDown = 1f/fireRate;
		}
		fireCountDown -= Time.deltaTime;
	}

	private void Shoot(){
		var Bullet = Instantiate(bullet,firePoint.position, firePoint.rotation);
		Bullet.Seek(target);
	}

	private void Rotate(){
		var direction = target.position-transform.position;
		var lookRotation = Quaternion.LookRotation(direction);
		var rotation= Quaternion.Lerp(partToRotate.rotation, lookRotation, speedRotation*Time.deltaTime).eulerAngles;
		partToRotate.rotation = Quaternion.Euler(0f,rotation.y,0f);
	}
}
