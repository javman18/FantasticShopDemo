using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenNavigation : MonoBehaviour
{
    [SerializeField]
    private GameObject firstScreen;
    private IScreen currentScreen;
    private List<IScreen> previousScreens = new List<IScreen>();
    // Start is called before the first frame update
    void Start()
    {
        currentScreen = firstScreen.GetComponent<IScreen>();
    }

    public void ShowScreen(GameObject screen)
    {
        IScreen screenToShow = screen.GetComponent<IScreen>();
        if (currentScreen != null)
        {
            currentScreen.Hide();
            previousScreens.Add(currentScreen);
        }

        SetCurrentScreen(screenToShow);
        currentScreen.Show();
    }

    public void ShowPreviousScreen()
    {
      
        if (previousScreens.Count > 0)
        {
            currentScreen.Hide(); //if we comment this line, we will have problems in our screens at the time someone tries to go back
            SetCurrentScreen(previousScreens[previousScreens.Count - 1]);
            previousScreens.RemoveAt(previousScreens.Count - 1);
            currentScreen.Show();
        }
    }

    public void HideScreen()
    {
        currentScreen.Hide();
    }
    public void SetCurrentScreen(IScreen screen)
    {
        currentScreen = screen;
    }

    public IScreen GetCurrentScreen()
    {
        return currentScreen;
    }

    public IScreen GetPreviousScreen()
    {
        return previousScreens[previousScreens.Count - 1];
    }
}
