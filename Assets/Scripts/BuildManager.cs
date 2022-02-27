using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    public GameObject standardTurretPrefab;
    private GameObject _turretToBuild;

    private void Awake()
    {
        if (instance != null) Debug.LogError("More than one Buildmanager in scene!");
        instance = this;
    }

    private void Start()
    {
        _turretToBuild = standardTurretPrefab;
    }

    public GameObject GetTurretToBuild()
    {
        return _turretToBuild;
    }
}