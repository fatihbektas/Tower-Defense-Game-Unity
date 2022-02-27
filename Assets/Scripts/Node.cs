using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] private Color hoverColor;
    public Vector3 positionOffset;
    private Renderer _rend;
    private Color _startColor;
    private GameObject _turret;

    private void Start()
    {
        _rend = GetComponent<Renderer>();
        _startColor = _rend.material.color;
    }

    private void OnMouseDown()
    {
        if (_turret != null)
        {
            Debug.Log("Can't build there!  - TODO: Display on screen");
            return;
        }

        // Build a turret
        var turretToBuild = BuildManager.instance.GetTurretToBuild();
        _turret = Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }

    private void OnMouseEnter()
    {
        _rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        _rend.material.color = _startColor;
    }
}