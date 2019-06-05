using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ninja
{
    public class DashBar : MonoBehaviour
    {

        public float dashMax = 1.5f;
        public float dashTimer;

        //reference to slider
        public Slider dashSlider;
        //reference to fill
        public Image dashFill;
        public Image dashBack;

        private void Start()
        {
            dashFill.enabled = false;
            dashBack.enabled = false;
        }
        void Update()
        {
            //currenthealth divided by maxhealth to make it 0
            dashSlider.value = Mathf.Clamp01(dashTimer / dashMax);
            //if player's current health is less than or equal to 0 and health fill is enabled
            if (Input.GetKey(KeyCode.F))
            {
                dashFill.enabled = true;
                dashBack.enabled = true;
                dashTimer += Time.deltaTime;
                dashTimer = Mathf.Clamp(dashTimer, 0f, dashMax);
                if (dashTimer >= dashMax)
                {

                }
            }
            if (Input.GetKeyUp(KeyCode.F))
            {
                dashFill.enabled = false;
                dashBack.enabled = false;
                print("Launch!");
                dashTimer = 0;
            }
        }
    }
}
