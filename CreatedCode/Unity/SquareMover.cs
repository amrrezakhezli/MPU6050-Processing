using UnityEngine;
using System.Collections;
using Uniduino;

public class SquareMover : MonoBehaviour {
	int x = 3;
	int y = 5;
	int z = 6;
	public Arduino arduino;

	void Start () {
		arduino = Arduino.global;
		arduino.Setup (ConfigurePins);
	}

	void ConfigurePins() {
		arduino.pinMode (x, PinMode.INPUT);
		arduino.pinMode (y, PinMode.INPUT);
		arduino.pinMode (z, PinMode.INPUT);
	}


	float dx = (float)0.0;
	float dy = (float)0.0;
	float dz = (float)0.0;
	// Update is called once per frame
	void Update () {
		int xDeg = arduino.analogRead (x);
		int yDeg = arduino.analogRead (y);
		int zDeg = arduino.analogRead (z);
		//transform.position = new Vector3 (dx, (float)1.0, (float)1.0);
		//dx=(float)(dx+0.1);

		xDeg = (xDeg - 90)*2;
		yDeg = (yDeg - 90)*2;
		zDeg = (zDeg - 90)*2;

		
		dx += (float)(xDeg / 100);
		dy += (float)(yDeg / 100);
		dz += (float)(zDeg / 100);
		if (dx < 10 && dy < 10 && dz < 10) {
			transform.position = new Vector3 ((float)(xDeg / 100), (float)(yDeg / 100), (float)(zDeg / 100));
		}
	}
}
