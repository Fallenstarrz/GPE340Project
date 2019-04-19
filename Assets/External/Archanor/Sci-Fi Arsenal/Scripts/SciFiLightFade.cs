﻿using UnityEngine;
using System.Collections;
 
namespace SciFiArsenal
{
    public class SciFiLightFade : MonoBehaviour
    {
        [Header("Seconds to dim the light")]
        public float life = 0.2f;
        public bool killAfterLife = true;
 
        private Light li;
        private float initIntensity;
 
        // Use this for initialization
        void Start()
        {
            if (gameObject.GetComponent<Light>())
            {
                li = gameObject.GetComponent<Light>();
                initIntensity = li.intensity;
            }
            else
                print("No light object found on " + gameObject.name);
        }
 
        /// <summary>
        /// make light component pulse
        /// </summary>
        // Update is called once per frame
        void Update()
        {
            if (gameObject.GetComponent<Light>())
            {
                li.intensity -= initIntensity * (Time.deltaTime / life);
                if (killAfterLife && li.intensity <= 0)
                    Destroy(gameObject);
            }
        }
    }
}