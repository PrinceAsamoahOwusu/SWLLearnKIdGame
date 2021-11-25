using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
    public AudioClip wrongAudioClip, correctAudioClip;
    private AudioSource audioSource;

    private GameObject winAnim;

    private int curPuzzleCount;
    public int CurPuzzleCount
    {
        set
        {
            curPuzzleCount = value;

            if (value == 4)
            {
                winAnim.SetActive(true);

                Invoke("OpenMain", 3f);
            }
        }
        get
        {
            return curPuzzleCount;
        }
    }

    void Awake()
	{
        audioSource = GetComponent<AudioSource>();
        winAnim = transform.GetChild(0).gameObject;

        CurPuzzleCount = 0;
    }

	void OpenMain()
	{
		SceneManager.LoadScene(0);
	}

    public void PlayWrongAudio()
    {
        audioSource.PlayOneShot(wrongAudioClip);
    }

    public void PlayCorrectAudio()
    {
        audioSource.PlayOneShot(correctAudioClip);
    }
}