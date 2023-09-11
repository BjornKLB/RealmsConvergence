//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class BlitzController : MonoBehaviour
//{
//    public enum DustType
//    {
//        Fire,
//        Ice,
//        Electric,
//        Wind
//    }

//    public DustType dustType;
//    public float explosionRadius = 5f;
//    public float explosionForce = 10f;
//    public float cooldownDuration = 3f;

//    public GameObject fireDustParticlesPrefab;
//    public GameObject iceDustParticlesPrefab;
//    public GameObject electricDustParticlesPrefab;
//    public GameObject windDustParticlesPrefab;

//    private bool isCooldown;
//    private AudioSource audioSource;

//    public float duration = 20f; // Duration in seconds

//    private bool hasCollided = false;
//    private new ParticleSystem particleSystem;

//    private void Start()
//    {
//        particleSystem = GetComponent<ParticleSystem>();
//        Invoke("StopParticleSystem", duration);
//    }

//    private void Awake()
//    {
//        audioSource = GetComponent<AudioSource>();
//    }

//    private void OnCollisionEnter(Collision collision)
//    {
//        if (collision.gameObject.CompareTag("Ground"))
//        {
//            Explode();
//        }

//        if (!hasCollided)
//        {
//            hasCollided = true;
//        }
//    }

//    private void Explode()
//    {
//        if (isCooldown)
//            return;

//        switch (dustType)
//        {
//            case DustType.Fire:
//                CreateParticles(fireDustParticlesPrefab);
//                ApplyFireEffect();
//                break;
//            case DustType.Ice:
//                CreateParticles(iceDustParticlesPrefab);
//                ApplyIceEffect();
//                break;
//            case DustType.Electric:
//                CreateParticles(electricDustParticlesPrefab);
//                ApplyElectricEffect();
//                break;
//            case DustType.Wind:
//                CreateParticles(windDustParticlesPrefab);
//                ApplyWindEffect();
//                break;
//        }

//        audioSource.Play();

//        // Start cooldown
//        isCooldown = true;
//        Invoke(nameof(ResetCooldown), cooldownDuration);

//        // Destroy the grenade object
//        Destroy(gameObject, audioSource.clip.length);
//    }

//    private void CreateParticles(GameObject particlesPrefab)
//    {
//        Instantiate(particlesPrefab, transform.position, Quaternion.identity);
//    }

//    private void ApplyFireEffect()
//    {
//        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
//        foreach (Collider collider in colliders)
//        {
//            if (collider.CompareTag("Enemy"))
//            {
//                // Apply fire effect to the enemy
//                EnemyController enemy = collider.GetComponent<EnemyController>();
//                enemy.ApplyFireEffect();
//            }
//        }
//    }

//    private void ApplyIceEffect()
//    {
//        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
//        foreach (Collider collider in colliders)
//        {
//            if (collider.CompareTag("Enemy"))
//            {
//                // Apply ice effect to the enemy
//                EnemyController enemy = collider.GetComponent<EnemyController>();
//                enemy.ApplyIceEffect();
//            }
//        }
//    }

//    private void ApplyElectricEffect()
//    {
//        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
//        foreach (Collider collider in colliders)
//        {
//            if (collider.CompareTag("Enemy"))
//            {
//                // Apply electric effect to the enemy
//                EnemyController enemy = collider.GetComponent<EnemyController>();
//                enemy.ApplyElectricEffect();
//            }
//        }
//    }

//    private void ApplyWindEffect()
//    {
//        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
//        foreach (Collider collider in colliders)
//        {
//            if (collider.CompareTag("Enemy"))
//            {
//                // Apply wind effect to the enemy
//                EnemyController enemy = collider.GetComponent<EnemyController>();
//                enemy.ApplyWindEffect();
//            }
//        }
//    }

//    private void ResetCooldown()
//    {
//        isCooldown = false;
//    }

//    private void StopParticleSystem()
//    {
//        particleSystem.Stop();
//        Destroy(gameObject, particleSystem.main.duration);
//    }

   
//}