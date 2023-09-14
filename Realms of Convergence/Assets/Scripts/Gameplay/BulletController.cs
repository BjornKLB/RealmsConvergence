using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Vector3 tempVector;

    public PointsController PointReference;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) ;
        {
            if (collision.gameObject.GetComponent<EnemyController2>() != null)
            {
                collision.gameObject.GetComponent<EnemyController2>().health -= GameObject.Find("John").GetComponent<PlayerController>().damage;
                PointReference.AddToPoints(115);
                gameObject.GetComponent<Rigidbody>().velocity = tempVector;
                GameObject.Find("Enemy").GetComponent<Rigidbody>().velocity = tempVector;
            }
        }
    }
}