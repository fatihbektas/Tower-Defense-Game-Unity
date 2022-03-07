using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    [SerializeField] private Color hoverColor;
    public Vector3 positionOffset;
    private Renderer _rend;
    private Color _startColor;
    public Color notEnoughMoneyColor;
    [Header("Optional")] public GameObject turret;
    private BuildManager _buildManager;

    private void Start()
    {
        _rend = GetComponent<Renderer>();
        _startColor = _rend.material.color;
        _buildManager = BuildManager.Instance;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (!_buildManager.CanBuild) return;

        if (turret != null)
        {
            Debug.Log("Can't build there!  - TODO: Display on screen");
            return;
        }

        _buildManager.BuildTurretOn(this);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (!_buildManager.CanBuild) return;

        if (_buildManager.HasMoney)
        {
            _rend.material.color = hoverColor;
        }
        else
        {
            _rend.material.color = notEnoughMoneyColor;
        }
    }

    private void OnMouseExit()
    {
        _rend.material.color = _startColor;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
}