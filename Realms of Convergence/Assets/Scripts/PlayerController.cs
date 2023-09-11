using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject[] weapons;
    private int currentWeaponIndex = 0;

    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public int startingBulletPoolSize = 10;
    public int maxBulletPoolSize = 20;
    public float bulletForce = 10f;

    public GameObject[] bulletPool;
    private int currentBulletIndex;
    private bool isReloading;
    private float currentReloadTime;

    private float defaultReloadTime;
    private float pistolReloadTime;
    private float shotgunReloadTime;
    private float rifleReloadTime;
    private float sniperReloadTime;
    private float lmgReloadTime;

    public float damage;

    public GameObject dustBlitzPrefab;
    public float throwForce = 10f;

    private bool canThrowGrenade = true;
    private BlitzController.DustType currentDustType;

    public GameObject fireDustParticlesPrefab;
    public GameObject iceDustParticlesPrefab;
    public GameObject electricDustParticlesPrefab;
    public GameObject windDustParticlesPrefab;

    public float deleteDelay = 5f;

    public enum GunType
    {
        Pistol,
        Shotgun,
        Rifle,
        Sniper,
        LMG
    }
    private GunType currentGunType;


    public GameObject specialAbilityObject;
    public KeyCode specialAbilityKey = KeyCode.Q;

    public KeyCode interactKey = KeyCode.F;
    private bool isInteracting = false;

    void Start()
    {
        // Set the first weapon active
        ActivateWeapon(currentWeaponIndex);
    }

    void Update()
    {
        // Weapon switching with mouse scroll wheel
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheel > 0f)
        {
            SwitchWeapon(1);
        }
        else if (scrollWheel < 0f)
        {
            SwitchWeapon(-1);
        }

        // Shooting
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        // Special ability activation
        if (Input.GetKeyDown(specialAbilityKey))
        {
            ActivateSpecialAbility();
        }

        // Opening menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenMenu();
        }

        // Object interaction
        if (Input.GetKeyDown(interactKey))
        {
            if (!isInteracting)
            {
                // Perform interaction logic
                Interact();
            }
        }

        if ((currentBulletIndex >= bulletPool.Length || Input.GetKeyDown(KeyCode.R)) && !isReloading)
        {
            Reload();
        }


        // Dust Blitz Grenade
        if (canThrowGrenade && Input.GetKeyDown(KeyCode.G))
        {
            ThrowGrenade();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetDustType(BlitzController.DustType.Fire);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetDustType(BlitzController.DustType.Ice);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetDustType(BlitzController.DustType.Electric);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SetDustType(BlitzController.DustType.Wind);
        }
    }

    void ActivateWeapon(int index)
    {
        // Deactivate all weapons
        foreach (GameObject weapon in weapons)
        {
            weapon.SetActive(false);
        }

        // Activate the selected weapon
        weapons[index].SetActive(true);
    }

    void SwitchWeapon(int direction)
    {
        // Calculate the new weapon index
        currentWeaponIndex += direction;
        if (currentWeaponIndex < 0)
        {
            currentWeaponIndex = weapons.Length - 1;
        }
        else if (currentWeaponIndex >= weapons.Length)
        {
            currentWeaponIndex = 0;
        }

        // Activate the new weapon
        ActivateWeapon(currentWeaponIndex);
    }

    void CreateBulletPool(int size)
    {
        bulletPool = new GameObject[size];
        for (int i = 0; i < size; i++)
        {
            bulletPool[i] = Instantiate(bulletPrefab);
            bulletPool[i].SetActive(false);
        }
    }

    void Shoot()
    {
        if (currentBulletIndex >= bulletPool.Length)
        {
            Reload();
            return;
        }

        GameObject bullet = bulletPool[currentBulletIndex];
        currentBulletIndex++;

        bullet.transform.position = bulletSpawnPoint.position;
        bullet.transform.rotation = bulletSpawnPoint.rotation;
        bullet.SetActive(true);

        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.velocity = Vector3.zero;
        bulletRb.AddForce(bulletSpawnPoint.forward * bulletForce, ForceMode.Impulse);
    }

    void Reload()
    {
        if (isReloading)
            return;

        isReloading = true;
        currentReloadTime = CalculateReloadTime();

        StartCoroutine(ReloadCoroutine());
    }

    float CalculateReloadTime()
    {
        float reloadTime = defaultReloadTime;
        switch (currentGunType)
        {
            case GunType.Pistol:
                reloadTime = pistolReloadTime;
                break;
            case GunType.Shotgun:
                reloadTime = shotgunReloadTime;
                break;
            case GunType.Rifle:
                reloadTime = rifleReloadTime;
                break;
            case GunType.Sniper:
                reloadTime = sniperReloadTime;
                break;
            case GunType.LMG:
                reloadTime = lmgReloadTime;
                break;
            // add more cases for additional guns
            default:
                break;
        }
        return reloadTime;
    }

    IEnumerator ReloadCoroutine()
    {
        yield return new WaitForSeconds(currentReloadTime);

        int currentPoolSize = bulletPool.Length;
        int newSize = Mathf.Min(currentPoolSize + startingBulletPoolSize, maxBulletPoolSize);
        if (newSize > currentPoolSize)
        {
            GameObject[] newPool = new GameObject[newSize];
            for (int i = 0; i < currentPoolSize; i++)
            {
                newPool[i] = bulletPool[i];
            }
            for (int i = currentPoolSize; i < newSize; i++)
            {
                newPool[i] = Instantiate(bulletPrefab);
                newPool[i].SetActive(false);
            }
            bulletPool = newPool;
        }

        currentBulletIndex = 0;
        isReloading = false;
    }

    void ActivateSpecialAbility()
    {
        // Special ability activation logic goes here
        specialAbilityObject.SetActive(true);
        // ...
    }

    void OpenMenu()
    {
        // Menu opening logic goes here
        // ...
    }

    void Interact()
    {
        // Object interaction logic goes here
    }

    private void SetDustType(BlitzController.DustType dustType)
    {
        currentDustType = dustType;
        Debug.Log("Current Dust type: " + currentDustType.ToString());
    }

    private void ThrowGrenade()
    {
        GameObject dustBlitz = Instantiate(dustBlitzPrefab, transform.position, transform.rotation);
        BlitzController dustBlitzController = dustBlitz.GetComponent<BlitzController>();
        dustBlitzController.dustType = currentDustType;

        // Attach particle system prefabs
        GameObject particlesPrefab = null;
        switch (currentDustType)
        {
            case BlitzController.DustType.Fire:
                particlesPrefab = fireDustParticlesPrefab;
                break;
            case BlitzController.DustType.Ice:
                particlesPrefab = iceDustParticlesPrefab;
                break;
            case BlitzController.DustType.Electric:
                particlesPrefab = electricDustParticlesPrefab;
                break;
            case BlitzController.DustType.Wind:
                particlesPrefab = windDustParticlesPrefab;
                break;
        }

        if (particlesPrefab != null)
        {
            GameObject particles = Instantiate(particlesPrefab, dustBlitz.transform.position, dustBlitz.transform.rotation);
            particles.transform.parent = dustBlitz.transform;
        }

        

        Rigidbody rb = dustBlitz.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.Impulse);

        // Set cooldown
        canThrowGrenade = false;
        Invoke(nameof(ResetThrowCooldown), 3f);
    }

    private void ResetThrowCooldown()
    {
        canThrowGrenade = true;
    }

    
}