using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Scene_Manager : MonoBehaviour
{
    // Objects with these tags will NOT be destroyed
    public string[] tagsToPreserve = { "GameController" }; // Add your tags here

    public void SwitchScene(string sceneName)
    {
        // Find all root GameObjects in the scene
        GameObject[] rootObjects = SceneManager.GetActiveScene().GetRootGameObjects();

        foreach (GameObject obj in rootObjects)
        {
            // Check if the object has a tag to preserve
            bool preserve = false;
            foreach (string tag in tagsToPreserve)
            {
                if (obj.CompareTag(tag))
                {
                    preserve = true;
                    break;
                }
            }

            // Destroy the object if it doesn't have a preserving tag
            if (!preserve)
            {
                Destroy(obj);
            }
        }

        // Now load the new scene
        SceneManager.LoadScene(sceneName);
    }
}
