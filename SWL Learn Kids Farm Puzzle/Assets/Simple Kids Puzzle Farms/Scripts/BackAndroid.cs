using UnityEngine;
using UnityEngine.SceneManagement;

public class BackAndroid : MonoBehaviour 
{
	public string ParentLeveleName;

	void LateUpdate()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (ParentLeveleName != "Quit")
				SceneManager.LoadScene(ParentLeveleName);
			else
				Application.Quit();
		}
	}
}