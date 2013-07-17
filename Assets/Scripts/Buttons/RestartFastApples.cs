using UnityEngine;
using System.Collections;

public class RestartFastApples : MonoBehaviour
{

    void OnClick()
    {
        switch (Application.loadedLevel)
        {
            case 3: // Fast Apples
                Application.LoadLevel("Fast Apples");
                break;
            case 4: // Perfectionist
                Application.LoadLevel("Perfectionist");
                break;
            default:
                break;
        }
    }
}