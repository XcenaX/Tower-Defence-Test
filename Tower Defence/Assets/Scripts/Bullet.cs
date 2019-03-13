using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	
private Transform target;
[SerializeField]
private float speed;

private int damage = 5;
		
	void Update () {
		if(target == null){
			Destroy(gameObject);
			return;
		}		
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
        if(Vector3.Distance(transform.position, target.position) < 1f){   
			HitTarget();
			return;
        }   
	}

	private void HitTarget(){
		Destroy(gameObject);		
		target.GetComponent<Enemy>().SetLives(damage);
		if(target.GetComponent<Enemy>().GetLives() < 0){
			PlayerStats.Money += 10 * PlayerStats.CurrentWave;
			Destroy(target.gameObject);
		}		
	}

	public void Seek(Transform Target){
		this.target = Target;		
	}
}
