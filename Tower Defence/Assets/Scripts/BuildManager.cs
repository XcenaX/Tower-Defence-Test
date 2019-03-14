using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;
    private TurretPriceList turretToBuild;    
    private Node selectedNode;

    [SerializeField]
    private NodeUI nodeUI;

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
        nodeUI.Hide();
    }
 
    void Start()
    {
        
    }   

    public void DiselectNode(){
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectNode(Node node){
        if(selectedNode == node){
            DiselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;
        nodeUI.SetTarget(node);
    }     
}
