using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float offset;
    public Rigidbody2D projectile;
    public Transform shotPoint;
    public float shotPower;
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (Input.GetMouseButtonDown(0))
        {
            Rigidbody2D projectileInstance;
            projectileInstance = Instantiate(projectile, shotPoint.position, transform.rotation) as Rigidbody2D;
            projectileInstance.AddForce(shotPoint.up * shotPower);
        }

    }
}
