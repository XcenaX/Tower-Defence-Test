using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TurretPriceList{
    public GameObject[] upgradePrefabs;
    // public GameObject upgradedPrefab; типа если хочешь модель менять при апргрейде
    public int cost;
    public int upgradeCost;
}

public class Shop : MonoBehaviour
{
[Header("Buttons")]
[SerializeField]
private Button standartTurretBtn,missleTurretBtn,laserTurretBtn;

[Header("Prefabs")]
[SerializeField]
private TurretPriceList standartTurret,missleTurret, laserTurret;

[Header("Money")]
[SerializeField]
private Text moneyText;
[SerializeField]
private Text livesText;
[SerializeField]
private Text waveText;
    void Start()
    {
        standartTurretBtn.onClick.AddListener(SetStandartTurret);
        missleTurretBtn.onClick.AddListener(SetMissleTurret);
        laserTurretBtn.onClick.AddListener(SetLaserTurret);
    }

    private void SetStandartTurret(){
        BuildManager.instance.SetTurretToBuild(standartTurret);
    }
    
    private void SetMissleTurret(){
        BuildManager.instance.SetTurretToBuild(missleTurret);
    }

    private void SetLaserTurret(){
        BuildManager.instance.SetTurretToBuild(laserTurret);
    }

    private void OnDestroy()
    {
        standartTurretBtn.onClick.RemoveAllListeners();
        missleTurretBtn.onClick.RemoveAllListeners();
        laserTurretBtn.onClick.RemoveAllListeners();
    }
    
    void Update()
    {
        moneyText.text = PlayerStats.Money.ToString();
        livesText.text = PlayerStats.Lives.ToString();
        waveText.text = "Wave : " + PlayerStats.CurrentWave.ToString();
    }
}
