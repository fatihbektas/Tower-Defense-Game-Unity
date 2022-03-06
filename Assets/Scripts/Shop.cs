using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Shop : MonoBehaviour
{
    private BuildManager _buildManager;
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;

    private void Start()
    {
        _buildManager = BuildManager.instance;
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
}