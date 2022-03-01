using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour
{
    [SerializeField] private Color hoverColor;
    public Vector3 positionOffset;
    private Renderer _rend;
    private Color _startColor;
    private GameObject _turret;
    private BuildManager _buildManager;

    private void Start()
    {
        _rend = GetComponent<Renderer>();
        _startColor = _rend.material.color;
        _buildManager = BuildManager.instance;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        
        if (_buildManager.GetTurretToBuild() == null)
        {
            return;
        }
        
        if (_turret != null)
        {
            Debug.Log("Can't build there!  - TODO: Display on screen");
            return;
        }
        
        var turretToBuild = _buildManager.GetTurretToBuild();
        _turret = Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        
        if (_buildManager.GetTurretToBuild() == null)
        {
            return;
        }
        _rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        _rend.material.color = _startColor;
    }
}