using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHorizontalController : MonoBehaviour
{
    [Range(0,1)]
    public float Dump = 0.2f;
    private Plane _plane;
    private Vector3 _inputPos;

    // Use this for initialization
    void Start()
    {
        _plane = new Plane(Vector3.up, Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            GetInputPosition();


            // set ball x pos to cast x point
            var pos = transform.position;
            pos.x = Mathf.Lerp(pos.x, _inputPos.x, Dump);
            transform.position = pos;
        }
    }

    private void GetInputPosition()
    {
        // get ball position on screen
        var ballScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        // Create ray from mouser pos
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.y = Screen.height/4;
        var ray = Camera.main.ScreenPointToRay(mousePosition);

        // draw ray
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.yellow);

        // cast ray with zero plane
        float distance;
        _plane.Raycast(ray, out distance);

        // get cast point
        _inputPos = ray.GetPoint(distance);
    }

    private void OnDrawGizmos()
    {
            Gizmos.DrawSphere(_inputPos, .2f);

    }

}
