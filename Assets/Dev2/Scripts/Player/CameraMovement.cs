using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Player _player;

    private Vector3 _cameraOffset;
    private int _cameraMovementSpeed;


    public void Initialize(Player player)
    {
        _player = player;
    }

    /*
    private void FixedUpdate()
    {
        //CameraMove();
    }
    */

    private void CameraMove()
    {
        Vector3 cameraPosition = new Vector3(
            _player.transform.position.x + _cameraOffset.x, _player.transform.position.y + _cameraOffset.y, _player.transform.position.z + _cameraOffset.z);

        transform.position = Vector3.Lerp(transform.position, cameraPosition, _cameraMovementSpeed * Time.deltaTime);
    }

    public float minimumAngle;
    public float maximumAngle;
    public float mouseSensitivity;
    public bool stickCamera;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    /*
    void FixedUpdate()
    {
        float aimX = Input.GetAxis("Mouse X");
        float aimY = Input.GetAxis("Mouse Y");
        _player.transform.rotation *= Quaternion.AngleAxis(aimX * mouseSensitivity, Vector3.up);
        _player.transform.rotation *= Quaternion.AngleAxis(-aimY * mouseSensitivity, Vector3.right);


        var angleX = _player.transform.localEulerAngles.x;
        if (angleX > 180 && angleX < maximumAngle)
        {
            angleX = maximumAngle;
        }
        else if (angleX < 180 && angleX > minimumAngle)
        {
            angleX = minimumAngle;
        }

        _player.transform.localEulerAngles = new Vector3(angleX, _player.transform.localEulerAngles.y, 0);

        if (stickCamera)
        {
            _player.transform.rotation = Quaternion.Euler(0, _player.transform.rotation.eulerAngles.y, 0);
        }
    }
    */

}
