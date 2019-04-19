using UnityEngine;
using System.Collections;

namespace SciFiArsenal
{

    /// <summary>
    /// set pitch to random percent
    /// </summary>
	public class SciFiPitchRandomizer : MonoBehaviour
	{
	
		public float randomPercent = 10;
	
		void Start ()
		{
        transform.GetComponent<AudioSource>().pitch *= 1 + Random.Range(-randomPercent / 100, randomPercent / 100);
		}
	}
}