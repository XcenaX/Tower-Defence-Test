using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawn : MonoBehaviour {
	[SerializeField]
	private float timeBetweenWaves;
    [SerializeField]
    private Transform enemyPrefab;
    [SerializeField]
    private float enemyInterval;  
    [SerializeField] 
    private Transform spawnPoint;
    [SerializeField]
    private int startTime;
    private int enemyCount= 0;    
	private int waveNumber  = 1;
	private float countDownTimer;

	[SerializeField]
	private Text countDownText;

    private void Start()
    {
		countDownTimer = timeBetweenWaves;        
    }     
    private void Update(){
        if(countDownTimer <= 0){
            StartCoroutine(SpawnWave());
			countDownTimer = timeBetweenWaves;
        }
		else{
			countDownTimer -= Time.deltaTime;
			countDownText.text = countDownTimer.ToString("0");
		}
    }

	private IEnumerator SpawnWave(){
		waveNumber++;
		for (int i = 0; i < waveNumber; i++){
			SpawnEnemy();
			yield return new WaitForSeconds(enemyInterval);
		}
		timeBetweenWaves+=2;
		PlayerStats.CurrentWave++;
		enemyPrefab.GetComponent<Enemy>().SetStartLives(1);
	}

	private void SpawnEnemy(){
		Instantiate(enemyPrefab,spawnPoint.position, spawnPoint.rotation);
	}
}
