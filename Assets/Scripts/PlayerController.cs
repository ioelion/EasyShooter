using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int health = 100;
    public float rotationSpeed = 3f; 
    public float movementSpeed = 10f;
    public float bulletSpeed = 5f;
    public GameObject projectile;
    public Transform initialProjectilePosition; 
    public Camera cam;
    public LevelManager levelManager;
    private Rigidbody _rb;
    private Vector2 _rotation = Vector2.zero;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        #region MOVEMENT
            float _x = Input.GetAxis("Horizontal") ;
            float _z = Input.GetAxis("Vertical");
            Vector3 _movementDirection = transform.forward *_z + transform.right * _x;
            if (_movementDirection != Vector3.zero)
            {
                _rb.velocity = _movementDirection * movementSpeed;
                transform.position = new Vector3(transform.position.x,0,transform.position.z);
            }
            else
            {
                _rb.velocity = Vector2.zero;
            }
        #endregion
        #region ROTATION
            _rotation.y += Input.GetAxis("Mouse X");
            _rotation.x -= Input.GetAxis("Mouse Y");
            _rotation.x = Mathf.Clamp(_rotation.x, -30f, 30f);
            transform.eulerAngles = (Vector2)_rotation * rotationSpeed;
        #endregion
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            Shoot();
        }
    }

    public bool WantsToMove(){
        return Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0 ;
    }

    public bool WantsToLook(){
        return Input.GetAxisRaw("Mouse X") != 0 || Input.GetAxisRaw("Mouse Y") != 0 ;
    }

    public void TakeDamage(int qty){
        health -= qty;
        levelManager.UpdateHealth(health);
        CheckForDeath();
    }

    private void CheckForDeath(){
        if(health<=0){
           levelManager.ResetLevel();
        }
    }

    private void Shoot(){
        Rigidbody bulletRb = Instantiate(projectile, initialProjectilePosition.position, Quaternion.identity).GetComponent<Rigidbody>();
        bulletRb.transform.LookAt(cam.transform.position, Vector3.up);
        bulletRb.velocity = transform.forward * bulletSpeed;
    }

}

