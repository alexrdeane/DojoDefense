using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Shooting : MonoBehaviour
    {
        public GameObject bulletPrefab;
        public float bulletSpeed = 200f;
        public float shoot = 0;
        private GameObject clone;
        private Rigidbody rigid;

        void Update()
        {

            if (Input.GetKeyUp(KeyCode.E))
            {
                Shoot();
            }
        }

        void Shoot()
        {
            clone = Instantiate(bulletPrefab, transform.position, transform.rotation);
            rigid = clone.GetComponent<Rigidbody>();
            rigid.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
        }
    }
}

