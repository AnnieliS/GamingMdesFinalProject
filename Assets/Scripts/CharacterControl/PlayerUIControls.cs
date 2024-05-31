using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerUIControls : MonoBehaviour
{
     GameObject mainMenu;
    private void Start() {
        mainMenu = GameObject.FindGameObjectWithTag("MainMenu");
        mainMenu.SetActive(false);
    }
  public void OpenMainMenu(InputAction.CallbackContext context){
    mainMenu.SetActive(true);
    Time.timeScale = 0;
  }
}
