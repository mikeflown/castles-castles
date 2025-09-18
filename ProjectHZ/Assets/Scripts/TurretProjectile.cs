using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretProjectile : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private void Awake()
    {
        Destroy(this.gameObject, 15f);
    }

    private void FixedUpdate()
    {
        transform.position += Vector3.left * _moveSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        TestWaves testWaves = other.GetComponent<TestWaves>();
        if (testWaves != null)
            Destroy(this.gameObject);
    }
}
