using UnityEngine;

public class Shop : MonoBehaviour
{
    private BuildManager _buildManager;
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeamer;

    private void Start()
    {
        _buildManager = BuildManager.Instance;
    }

    public void SelectStandardTurret()
    {
        Debug.Log("Standard turret selected.");
        _buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileLauncher()
    {
        Debug.Log("Missile Launcher selected.");
        _buildManager.SelectTurretToBuild(missileLauncher);
    }

    public void SelectLaserBeamer()
    {
        Debug.Log("Laser Beamer selected.");
        _buildManager.SelectTurretToBuild(laserBeamer);
    }
}