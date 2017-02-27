using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ke_DeathClock : MonoBehaviour {

    public float deathClock;
	
	
	void Update () {

        deathClock -= Time.deltaTime;

        if (deathClock <= 0) Destroy(gameObject);
		
	}
}
