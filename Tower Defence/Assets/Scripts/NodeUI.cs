using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    private Node target;

    [SerializeField]
    private Transform root;

    [SerializeField]
    private Button upgradeButton, sellButton;

    [SerializeField]
    private Text upgradedBtnText;

    private void Start(){
        root.gameObject.SetActive(false);
        upgradeButton.onClick.AddListener(Upgrade);
        sellButton.onClick.AddListener(Sell);
    }

    public void Hide(){
        root.gameObject.SetActive(false);
    }

    public void SetTarget(Node target){
        this.target = target;
        Debug.Log("Max count = " + target.GetMaxCountUpgrades());
        transform.position = target.transform.position + new Vector3(2,6,0);
        if(target.GetCountUpgrades() < target.GetMaxCountUpgrades()){
            upgradedBtnText.text = "Upgrade \n $" + target.Turret.upgradeCost;
            upgradeButton.interactable = true;
        }
        else{
            upgradedBtnText.text = "Max Upgraded";
            upgradeButton.interactable = false;
        }
        root.gameObject.SetActive(true);
    }

    private void Upgrade(){
        if(target == null){
            return;
        }
        target.UpgradeTurrel();
        BuildManager.instance.DiselectNode();
    }
    
    private void Sell(){
        
        target.Sell();        
    }
}
