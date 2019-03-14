using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private GameObject turretObject;
    private TurretPriceList turret;
    public TurretPriceList Turret{get{return turret;}}
    public GameObject TurretObject{get{return turretObject;}}

[SerializeField]
    private Color startColor;
    [SerializeField]
    private Color hoverColor;
    private Renderer render;

    private int countUpgrades;
    private bool isCreated = false;


    public int GetCountUpgrades(){
        return countUpgrades;
    }
    public int GetMaxCountUpgrades(){
        return turret.upgradePrefabs.Length;
    }
    private void OnMouseEnter()
    {        
        var turretToBuild = BuildManager.instance.GetTurretToBuild();
        if(turretToBuild == null)return;
        if(PlayerStats.Money < turretToBuild.cost){
            render.material.color = Color.red;
        }
        else{
            render.material.color = hoverColor;
        }
    }

    private void OnMouseExit()
    {
        render.material.color = startColor;    
    }

    void OnMouseDown()
    {
        if(turret != null){
            BuildManager.instance.SelectNode(this);
            return;
        } 
        if(isCreated)return;       
        turret =  BuildManager.instance.GetTurretToBuild();
        if(turret == null)return;
        Debug.Log("Money = " + PlayerStats.Money + " , turret.cost = " + turret.cost);
        if(PlayerStats.Money < turret.cost){
            Debug.Log("НУЖНО БОЛЬШЕ ЗОЛОТА");
            return;
        }             
        if(turretObject != null)return;   
            turretObject = Instantiate(turret.upgradePrefabs[0],transform.position + new Vector3(0,0.5f,0), transform.rotation);
            PlayerStats.Money -= turret.cost;
            isCreated = true;
    }

    void Start()
    {
        render = GetComponent<MeshRenderer>();  
        render.material.color = startColor;  
        countUpgrades = 1;
        turret = null;
    }
    
    void Update()
    {
        
    }
    public void UpgradeTurrel(){
        if(PlayerStats.Money < turret.upgradeCost){
            Debug.Log("Нужно больше золота");
            return;
        }
        if(countUpgrades >= turret.upgradePrefabs.Length)return;    
        if(turret == null)return;
        if(turretObject != null)return;
        PlayerStats.Money -= turret.upgradeCost;
        Destroy(turretObject);
        turretObject = Instantiate(turret.upgradePrefabs[countUpgrades],transform.position + new Vector3(0,0.5f,0), transform.rotation);
        turretObject.GetComponent<Bullet>().SetDamage(5);
        countUpgrades++;
        Debug.Log("countUpgrades = " + countUpgrades);
    }

    public void Sell(){
        if(turretObject == null){
            return;
        }
        isCreated = false;
        Destroy(turretObject);
        countUpgrades = 1;
        PlayerStats.Money += turret.cost/2 + turret.upgradeCost*GetCountUpgrades()/2;
        turretObject= null;
        turret= null;
    }
}
