using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CreatePost : MonoBehaviour
{
    public RawImage anotherImage; // Assuming a RawImage component is present in the scene

    // Start is called before the first frame update
    void Start()
    {    
        System.Random random = new System.Random();
        Debug.Log("Create post script");
        // In a script in the "createPost" scene:
string imagePath = Application.persistentDataPath + "/" + random.Next(10,50) + ".png";
Debug.Log("Path: " + imagePath + " | " + System.IO.File.Exists(imagePath));

if (System.IO.File.Exists(imagePath))
{
    byte[] imageData = System.IO.File.ReadAllBytes(imagePath);
    Texture2D loadedImage = new Texture2D(500, 400); // Set appropriate dimensions
    loadedImage.LoadImage(imageData);
    loadedImage.Apply();

    // Use the loadedImage for display or other processing
    anotherImage.texture = loadedImage;
}
else
{
    Debug.Log("No image found at: " + imagePath);
}

        // if (ImageManager.capturedImage != null)
        // {
        //     ImageManager.capturedImage.Apply(); // Ensure it's ready for use
        //     anotherImage.texture = ImageManager.capturedImage;

        //     // Clear the image for subsequent captures (if needed)
        //     ImageManager.capturedImage = null;
        // }
        // else
        // {
        //     Debug.LogWarning("ImageManager doesn't contain a captured image");
        // }
    }

    // ... rest of your code
}
