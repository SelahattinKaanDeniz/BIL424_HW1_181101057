using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float aciYukari = 30f;
    [SerializeField] private float aciAsagi = -20f;
    public float dondurmeHassasiyet = 70f; 
    public Transform playerCam; 
    float rotateX = 0f; 
    

    private void Start() {
        Cursor.visible = false; 
        Cursor.lockState = CursorLockMode.Locked; 
    }

    private void Update() {
        float mouseX = Input.GetAxis("Mouse X") * dondurmeHassasiyet * Time.deltaTime; 
        float mouseY = Input.GetAxis("Mouse Y") * dondurmeHassasiyet * Time.deltaTime; 
        rotateX -= mouseY;
        rotateX = Mathf.Clamp(rotateX, aciAsagi, aciYukari); 
        transform.localRotation = Quaternion.Euler(rotateX, 0f, 0f); 
        playerCam.Rotate(Vector3.up * mouseX); 
    }
}
