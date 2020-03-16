using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public enum players
    {
        Player1,
        Player2,
        Player3,
        Player4
    }
    public players player;
    public float cameraMoveSpeed = 120f;
    public GameObject cameraFollowObj;
    Vector3 followPos;
    public float clampAngle = 80f;
    public float inputSensitivity = 150f;
    public GameObject camerObj;
    public GameObject playerObj;
    public float camDistanceXToPlayer;
    public float camDistanceYToPlayer;
    public float camDistanceZToPlayer;
    public float mouseX;
    public float mouseY;
    public float finalInputX;
    public float finalInputZ;
    public float smoothX;
    public float smoothY;
    private float rotY = 0f;
    private float rotX = 0f;
    private float inputX;
    private float inputZ;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerCheck();
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        finalInputX = inputX + mouseX;
        finalInputZ = inputZ + mouseY;

        rotY += finalInputX * inputSensitivity * Time.deltaTime;
        rotX += finalInputZ * inputSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;

    }

    private void LateUpdate()
    {
        CameraUpdater();
    }

    void CameraUpdater()
    {
        Transform target = cameraFollowObj.transform;

        float step = cameraMoveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }

    void PlayerCheck()
    {
        if (player == players.Player1)
        {
            inputX = Input.GetAxis("RightStickHorizontal");
            inputZ = Input.GetAxis("RightStickVertical");
        }

        if (player == players.Player2)
        {
            inputX = Input.GetAxis("RightStickHorizontalP2");
            inputZ = Input.GetAxis("RightStickVerticalP2");
        }

        if (player == players.Player3)
        {
            inputX = Input.GetAxis("RightStickHorizontalP3");
            inputZ = Input.GetAxis("RightStickVerticalP3");
        }

        if (player == players.Player4)
        {
            inputX = Input.GetAxis("RightStickHorizontalP4");
            inputZ = Input.GetAxis("RightStickVerticalP4");
        }
    }
}
