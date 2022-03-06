using System.Security.Cryptography;
using System.Xml;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public TurretBlueprint turretToBuild;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one Build manager in scene!");
            return;
        }

        instance = this;
    }

    public bool CanBuild => turretToBuild != null;

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
        
        GameObject turret = Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("Turret build! Money left: "+ PlayerStats.Money);
    }
}