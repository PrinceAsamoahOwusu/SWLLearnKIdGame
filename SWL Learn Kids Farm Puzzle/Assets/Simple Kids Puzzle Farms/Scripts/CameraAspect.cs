using UnityEngine;

public class CameraAspect : MonoBehaviour 
{
	void Awake () 
	{
		Camera.main.aspect = 3/2f;
        Time.timeScale = 1;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
}