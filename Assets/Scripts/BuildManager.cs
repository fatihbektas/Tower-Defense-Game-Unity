using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefab;
    private GameObject _turretToBuild;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one Build manager in scene!");
            return;
        }

        instance = this;
    }

    public GameObject GetTurretToBuild()
    {
        return _turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        _turretToBuild = turret;
    }
}