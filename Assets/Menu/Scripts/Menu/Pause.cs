using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
	private ShowPanels showPanels;						//Reference to the ShowPanels script used to hide and show UI panels
	private static bool isPaused;								//Boolean to check if the game is paused or not
	private StartOptions startScript;                   //Reference to the StartButton script
	MouseAspect.Aspect savedAspect;
	GameObject player;
	Inventory inventory;
	
	//Awake is called before Start()
	void Awake()
	{
		//Get a component reference to ShowPanels attached to this object, store in showPanels variable
		showPanels = GetComponent<ShowPanels>();
		//Get a component reference to StartButton attached to this object, store in startScript variable
		startScript = GetComponent<StartOptions>();
		//Change mouse aspect
		MouseAspect.ChangeAspect(MouseAspect.Aspect.Mouse);
		savedAspect = MouseAspect.CurrentAspect();
	}

    private void Start()
	{
		MouseAspect.ChangeAspect(MouseAspect.Aspect.Mouse);
		savedAspect = MouseAspect.CurrentAspect();
	}

    // Update is called once per frame
    void Update ()
	{
		string sceneName = SceneManager.GetActiveScene().name;
		if (DialogueManager.IsInDialogue() || sceneName.Equals("World Map") || sceneName.Equals("Outro")) return;

		//Check if the Cancel button in Input Manager is down this frame (default is Escape key) and that game is not paused, and that we're not in main menu
		if (Input.GetButtonDown ("Cancel") && !isPaused && !startScript.inMainMenu) 
		{
            Debug.Log("pausing");
			//Call the DoPause function to pause the game
			DoPause();
		} 
		//If the button is pressed and the game is paused and not in main menu
		else if (Input.GetButtonDown ("Cancel") && isPaused && !startScript.inMainMenu) 
		{
			Debug.Log("unpausing");
			//Call the UnPause function to unpause the game
			UnPause();
		}	
	}

	public void DoPause()
	{
		//Change mouse aspect
		savedAspect = MouseAspect.CurrentAspect();
		MouseAspect.ChangeAspect(MouseAspect.Aspect.Mouse);
		//Disable weapons
		player = GameObject.FindGameObjectWithTag("Player");
		inventory = FindObjectOfType<Inventory>();
		if(player)
			player.GetComponentInChildren<LanceIncendie>().enabled = false;
		if(inventory)
			inventory.gameObject.SetActive(false);
		//Set isPaused to true
		isPaused = true;
		//Set time.timescale to 0, this will cause animations and physics to stop updating
		Time.timeScale = 0;
		//call the ShowPausePanel function of the ShowPanels script
		showPanels.ShowPausePanel();
	}

	public void UnPause()
	{
		//Set isPaused to false
		isPaused = false;
		//Set time.timescale to 1, this will cause animations and physics to continue updating at regular speed
		Time.timeScale = 1;
		//call the HidePausePanel function of the ShowPanels script
		showPanels.HidePausePanel();
		//Change mouse aspect
		MouseAspect.ChangeAspect(savedAspect);
		//Enable weapons
		if (player)
			player.GetComponentInChildren<LanceIncendie>().enabled = true;
		if (inventory)
			inventory.gameObject.SetActive(true);
	}

	public static bool IsPaused()
    {
		return isPaused;
    }
}
