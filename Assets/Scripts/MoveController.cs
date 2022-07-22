using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class MoveController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private DynamicJoystick _dynamicJoystick;
    [SerializeField] private float _speed;

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_dynamicJoystick.Horizontal*_speed, _rigidbody.velocity.y, _dynamicJoystick.Vertical*0);
    }
}
