using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] Transform _aim;
    [SerializeField] Camera _camera;

    private void LateUpdate()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction * 30, Color.red);

        Plane plane = new Plane(-Vector3.forward, Vector3.zero);

        float distance;

        plane.Raycast(ray, out distance);
        Vector3 point = ray.GetPoint(distance);

        _aim.position = point;

        Vector3 toAim = _aim.position - transform.position;
        transform.rotation = Quaternion.LookRotation(toAim);
    }
}
