using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace AI
{
    public class Enemy : MonoBehaviour
    {

        public Renderer rend;
        #region Variables
        [Header("Variables:")]
        //enemy's rigidbody
        public Rigidbody rigid;

        #endregion Variables

        #region Start
        void Start()
        {
            rend = GetComponent<Renderer>();
            rend.enabled = true;

        }
        #endregion

        #region TriggerEnter
        private void OnTriggerEnter(Collider other)
        {
            //if other gameobject is player
            if (other.gameObject.CompareTag("bullet"))
            {
                //set target to the thing in zone
                //switch state to seek
                Destroy(gameObject);
            }
        }
        #endregion
    }
}

