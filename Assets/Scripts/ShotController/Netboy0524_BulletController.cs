using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Netboy0524_BulletController : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}
