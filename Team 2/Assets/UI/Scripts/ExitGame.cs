using UnityEngine;

/*
 * @author Marc-Andre Larouche
 * @description Exit the game
 */
public class ExitGame : MonoBehaviour
{

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();  
#endif
    }

}
