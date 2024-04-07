using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Firebase.Firestore;
using System.Threading.Tasks;
using Firebase.Extensions;
using System;

public class CameraManager : MonoBehaviour
{
    private WebCamTexture backCam;
    private Texture defaultBackground;

    public RawImage background;
    public Button cameraButton;

    Firebase.FirebaseApp app;

    string photoId;

    void Awake()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                app = Firebase.FirebaseApp.DefaultInstance;

                // Set a flag here to indicate whether Firebase is ready to use by your app.
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });
    }

    // Start is called before the first frame update
    void Start()
    {
        app = Firebase.FirebaseApp.DefaultInstance;
        //  Firebase.FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://ninerquest-71c43.firebaseio.com/"); // Replace with your Firestore database URL
        OpenCamera();
        // cameraButton.onClick.AddListener(OpenCamera);
        cameraButton.onClick.AddListener(TakePicture);
    }

    public void OpenCamera()
    {
        defaultBackground = background.texture;
        WebCamDevice[] devices = WebCamTexture.devices;
        Debug.Log(devices.Length + " cameras found");
        if (devices.Length == 0)
        {
            Debug.Log("No camera detected");
            //camAvailable = false;
            return;
        }

        for (int i = 0; i < devices.Length; i++)
        {
            if (!devices[i].isFrontFacing)
            {
                backCam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
            }
        }

        if (backCam == null)
        {
            Debug.Log("Unable to find back Camera");
            return;
        }

        backCam.Play();
        background.texture = backCam;
    }
    private async void TakePicture()
    {
        // Get the current frame as a Texture2D
        Texture2D image = new Texture2D(backCam.width, backCam.height);
        Color32[] pixels = image.GetPixels32();  // Get the pixels as Color32 array
        backCam.GetPixels32(pixels);          // Assign pixels directly from WebCamTexture
        image.Apply();

        // Do something with the captured image, e.g., save it or display it:
        Debug.Log("Picture taken!");
        // You can save the image using:
        // image.EncodeToPNG();
        // Or display it on a UI element:
        // anotherImage.texture = image;

        // Stop the camera if needed
        backCam.Stop();

        byte[] imageBytes = image.EncodeToPNG();

        // Upload image to Firestore
        await UploadImageToFirestore(imageBytes);

        // Save the image data
        SaveImage(imageBytes);

        PlayerPrefs.SetString("photoId", photoId);

        SceneManager.LoadScene("createPost");
    }

    private async Task UploadImageToFirestore(byte[] imageData)
    {
        string encodedImageData = Convert.ToBase64String(imageData); // Encode as Base64
        Debug.Log(encodedImageData);
        PlayerPrefs.SetString("imageData", encodedImageData);
        // Get a reference to the "images" collection
        CollectionReference imagesRef = Firebase.Firestore.FirebaseFirestore.DefaultInstance.Collection("images");

        // Create a document reference with a unique ID
        DocumentReference imageRef = imagesRef.Document();

        // Prepare image metadata for Firestore
        System.Random random = new System.Random();
        string imageName = random.Next(10, 50) + ".png"; // Adjust as needed

        // Create a Firestore document with image data and metadata
        await imageRef.SetAsync(new
        {
            data = imageData,
            name = imageName,
        });

        photoId = imageRef.Id;
        Debug.Log("Image uploaded to Firestore: " + imageRef.Id);
    }


    private void SaveImage(byte[] imageData)
    {
        // Get a path to save the image
        System.Random random = new System.Random();
        string imagePath = Application.persistentDataPath + "/" + random.Next(10, 50) + ".png";

        // Write image data to the file
        System.IO.File.WriteAllBytes(imagePath, imageData);

        Debug.Log("Image saved to: " + imagePath);
    }


}
