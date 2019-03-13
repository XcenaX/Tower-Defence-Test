using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private GameObject turretObject;
    private TurretPriceList turret;

[SerializeField]
    private Color startColor;
    [SerializeField]
    private Color hoverColor;
    private Renderer render;
    
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
            Debug.Log("НУЖНО БОЛЬШЕ ЗОЛОТА!");
            return;
        }        
        turret =  BuildManager.instance.GetTurretToBuild();
        if(turret == null)return;
        if(PlayerStats.Money < turret.cost){
            Debug.Log("НУЖНО БОЛЬШЕ ЗОЛОТА");
            return;
        }                
            turretObject = Instantiate(turret.prefab,transform.position + new Vector3(0,0.5f,0), transform.rotation);
            PlayerStats.Money -= turret.cost;
        
    }

    void Start()
    {
        render = GetComponent<MeshRenderer>();  
        render.material.color = startColor;  
    }
    
    void Update()
    {
        
    }
}
