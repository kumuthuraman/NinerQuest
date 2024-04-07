using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CameraManager : MonoBehaviour
{
    private WebCamTexture backCam;
    private Texture defaultBackground;

    public RawImage background;
    public Button cameraButton;

    // Start is called before the first frame update
    void Start()
    {
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
    private void TakePicture()
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

    // Save the image data
    SaveImage(imageBytes);
    
    SceneManager.LoadScene("createPost");
}

private void SaveImage(byte[] imageData)
{
    // Get a path to save the image
    string imagePath = Application.persistentDataPath + "/captured_image.png";

    // Write image data to the file
    System.IO.File.WriteAllBytes(imagePath, imageData);

    Debug.Log("Image saved to: " + imagePath);
}


}
