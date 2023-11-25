using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;
using Cinemachine;

public class Shoot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject GunPickup;
    public GameObject Gun;
    public AudioSource ShootFx;
    private bool Shooting = false;
    public static event Action Shot;
    [SerializeField] private float CameraShakeForce;
    public CinemachineImpulseSource ImpulseSource;
    [SerializeField] private float ShootRate = 0.1f;
    private float ShootCurrentTime = 0f;
    private PlayerInputs movement;
    void Awake() {
        movement = new PlayerInputs();
    }
    void OnEnable() {
        movement.Enable();
    }

    void OnDisable() {
        if (movement != null) movement.Disable();
    }
    void Start()
    {
        ShootCurrentTime = ShootRate;
        movement.Player.Shoot.performed += OnClick;
    }

    // Update is called once per frame
    void Update()
    {
        ShootCurrentTime += Time.deltaTime;
        if (Shooting) {
            if (ShootCurrentTime > ShootRate) {
                IShootable Shoot = GetComponent<IShootable>();
                if (Shoot != null) {
                    // Action Shot For Pets
                    if (Shot != null) {
                        Shot();
                    }
                    Shoot.Shoot();
                    ShootCurrentTime = 0f;
                    if (ImpulseSource != null) {
                        ImpulseSource.GenerateImpulseWithForce(CameraShakeForce);
                    }
                    else {
                        Debug.LogWarning("No ImpulseSource");
                    }
                    if (ShootFx != null) {
                        ShootFx.Play();
                    }
                    else {
                        Debug.LogWarning("No ShootFX");
                    }
                }
            }
        }
    }
    void OnClick(InputAction.CallbackContext context) {
        Shooting = ! Shooting;
    }
}
