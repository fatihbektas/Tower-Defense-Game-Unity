using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private BuildManager _buildManager;

    private void Start()
    {
        _buildManager = BuildManager.instance;
    }

    public void PurchaseStandardTurret()
    {
        Debug.Log("Standard turret selected.");
        _buildManager.SetTurretToBuild(_buildManager.standardTurretPrefab);
    }
    public void PurchaseAnotherTurret()
    {
        Debug.Log("Another turret selected.");
        _buildManager.SetTurretToBuild(_buildManager.anotherTurretPrefab);
    }
}
