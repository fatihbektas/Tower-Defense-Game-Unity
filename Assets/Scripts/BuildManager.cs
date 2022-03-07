using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance;
    public TurretBlueprint turretToBuild;
    public GameObject buildEffect;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one Build manager in scene!");
            return;
        }

        Instance = this;
    }

    public bool CanBuild => turretToBuild != null;
    public bool HasMoney => PlayerStats.Money >= turretToBuild.cost;

    public void SelectTurretToBuild(TurretBlueprint turretBlueprint)
    {
        turretToBuild = turretBlueprint;
    }

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;
        
        var turret = Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

       var effect=  Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        Debug.Log("Turret build! Money left: "+ PlayerStats.Money);
    }
}