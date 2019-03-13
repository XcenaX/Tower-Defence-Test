using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;
    private TurretPriceList turretToBuild;    
    public TurretPriceList GetTurretToBuild(){
        return turretToBuild;
    }
    private void Awake(){
        if(instance != null){
            Debug.Log("Нельзя создавать больше одного такого скрипта, так как синглтон детка");
            return;
        }
        instance = this;
    }

    public void SetTurretToBuild(TurretPriceList turret){
        turretToBuild = turret;
    }
 
    void Start()
    {
        
    }        
}
