using UnityEngine;
using System.Collections;

public class OculusSwitchScript : MonoBehaviour {

	private bool init = false;

	public static bool Oculus = true;
	public OVRCameraRig rig;
	public OVRManager manager;

	public Camera ovrCam1;
	public Camera ovrCam2;

	public Camera backupcam;

	public void SwitchToOculus() {
		//if (Oculus)
		//	return;
		rig.enabled = true;
		manager.enabled = true;
		ovrCam1.enabled = true;
		ovrCam2.enabled = true;

		backupcam.enabled = false;
		Oculus = true;
		Debug.Log ("Oculus");
	}

	public void SwitchToBackup() {
		//if (!Oculus)
		//	return;
		rig.enabled = false;
		manager.enabled = false;
		ovrCam1.enabled = false;
		ovrCam2.enabled = false;
		
		backupcam.enabled = true;
		Oculus = false;
		Debug.Log ("Normal Camera");
		
	}


	void Update() {

		if (!init) {
		Debug.Log ("InitCamera");
			
			if (!Oculus)
				SwitchToBackup ();
			else
				SwitchToOculus();
				
			init = true;
		}

		if (Input.GetButtonDown("SwitchCamera")) {
			if (Oculus)
				SwitchToBackup();
			else
				SwitchToOculus();
		}
	}


}
