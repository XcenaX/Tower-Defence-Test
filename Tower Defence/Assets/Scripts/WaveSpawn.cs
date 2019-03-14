using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawn : MonoBehaviour {
	[SerializeField]
	private float timeBetweenWaves;
    [SerializeField]
    private Transform[] enemyPrefabs;
	private int currentEnemy = 0;
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
		foreach(var enemy in enemyPrefabs){
			enemy.GetComponent<Enemy>().SetStartLives(2);
		}
		
		Shuffle(enemyPrefabs);
		currentEnemy++;
		if(currentEnemy == enemyPrefabs.Length)currentEnemy = 0;
	}

	private void SpawnEnemy(){
		Instantiate(enemyPrefabs[currentEnemy],spawnPoint.position, spawnPoint.rotation);
	}


	void Shuffle(Transform[] texts)
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < texts.Length; t++ )
        {
            var tmp = texts[t];
            int r = Random.Range(t, texts.Length);
            texts[t] = texts[r];
            texts[r] = tmp;
        }
    }
}
