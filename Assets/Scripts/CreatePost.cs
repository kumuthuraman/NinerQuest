using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Firebase.Firestore;
using System.Threading.Tasks;
using Firebase.Extensions;
using System;


public class CreatePost : MonoBehaviour
{
    public RawImage anotherImage; // Assuming a RawImage component is present in the scene

    // Start is called before the first frame update
    async void Start()
    {
        Debug.Log("Create post script");

        string photoId = PlayerPrefs.GetString("photoId"); // Access the passed argument

        string retrievedImageData = PlayerPrefs.GetString("imageData");
        byte[] decodedImageData = Convert.FromBase64String(retrievedImageData); // Decode from Base64
        // Create and apply a Texture2D from the image data
        Texture2D loadedImage = new Texture2D(500, 400); // Adjust dimensions as needed
        loadedImage.LoadImage(decodedImageData);
        loadedImage.Apply();

        // Display the loaded image
        anotherImage.texture = loadedImage;
    }

}
