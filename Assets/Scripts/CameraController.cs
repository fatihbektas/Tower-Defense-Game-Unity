using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f;
    public float panBorderThickness = 10f;
    public float scrollSpeed = 5f;
    public float minY = 50f;
    public float maxY = 150f;

    private bool _doMovement = true;

    // Update is called once per frame
    private void Update()
    {
        if (GameManager.GameIsOver)
        {
            enabled = false;
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.Escape)) _doMovement = !_doMovement;

        if (!_doMovement) return;

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.Self);

        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.Self);

        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.Self);

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.Self);

        var scroll = Input.GetAxis("Mouse ScrollWheel");

        var pos = transform.position;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;

        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }
}