using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Camera cam;
    public LayerMask layerMask;
    private StarterAssetsInputs _input;
    public Transform ball;
    public GameObject bullet;
    public Transform spawner;
    private void Awake()
    {
        cam = GameObject.Find("MainCamera").GetComponent<Camera>();
        _input = GetComponent<StarterAssetsInputs>();
    }
    private void Update()
    {
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2, Screen.height / 2);
        Vector3 mouseWorldPosition = Vector3.zero;
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);

        if (Physics.Raycast(ray, out RaycastHit hit, 999f, layerMask))
        {
            ball.position = hit.point;
            mouseWorldPosition = hit.point;
        }
        if (_input.shoot == true)
        {
            _input.shoot = false;
            Vector3 aimdir = (mouseWorldPosition - spawner.position).normalized;
            Instantiate(bullet, spawner.position, Quaternion.LookRotation(aimdir, Vector3.up));
        }

    }


}//class
