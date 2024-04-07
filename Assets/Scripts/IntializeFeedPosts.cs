using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IntializeFeedPosts : MonoBehaviour
{
    public GameObject postPrefab;
    public DataHolding data;

    private Color green = new Color(0, 0.3137255f, 0.2078431f);
    private Color yellow = new Color(0.6431373f, 0.5882353f, 0.3960784f);

    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.FindGameObjectsWithTag("Persistent")[0].GetComponent<DataHolding>();

        //instantiating a new postPrefab object, rewrite all of the data
        GameObject newPost = Instantiate(postPrefab, gameObject.transform);
        newPost.transform.SetAsFirstSibling();

        GameObject border = newPost.transform.GetChild(0).gameObject;
        GameObject image = newPost.transform.GetChild(1).gameObject;
        GameObject caption = newPost.transform.GetChild(2).gameObject;

        if (data.isTask1 == true) {
            border.GetComponent<Image>().color = green;
        } else {
            border.GetComponent<Image>().color = yellow;
        }

        image.GetComponent<Image>().sprite = data.sprite;

        caption.GetComponent<TMP_Text>().text = data.caption;
    }
}
