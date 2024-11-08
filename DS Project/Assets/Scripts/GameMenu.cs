using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public GameObject changeBG;
    public GameObject nameHomie;
    public GameObject dressUp;
    public GameObject showcase;

    //Updated so that all arrays are now circular linked lists with the current 
    public List<GameObject> shirts;
    public List<GameObject> pants;
    public List<GameObject> hair;
    public List<GameObject> shoes;
    public List<GameObject> hats;
    public List<GameObject> glasses;
    public List<GameObject> pets;
    public List<Material> bgs;

    private LinkedList<GameObject> shirtsLL;
    private LinkedList<GameObject> pantsLL;
    private LinkedList<GameObject> hairLL;
    private LinkedList<GameObject> shoesLL;
    private LinkedList<GameObject> hatsLL;
    private LinkedList<GameObject> glassesLL;
    private LinkedList<GameObject> petsLL;
    private LinkedList<Material> bgsLL;

    private LinkedListNode<GameObject> currShirt;
    private LinkedListNode<GameObject> currPants;
    private LinkedListNode<GameObject> currHair;
    private LinkedListNode<GameObject> currShoes;
    private LinkedListNode<GameObject> currHat;
    private LinkedListNode<GameObject> currGlasses;
    private LinkedListNode<GameObject> currPet;
    private LinkedListNode<Material> currbg;

    public AudioClip festiveBling;
    public TextMeshProUGUI playerText;
    public GameObject screenshotText;
    public TMP_InputField field;

    public string player;

    public GameObject planeBG;

    void Start()
    {
        shirtsLL = new LinkedList<GameObject>(shirts);
        pantsLL = new LinkedList<GameObject>(pants);
        hairLL = new LinkedList<GameObject>(hair);
        shoesLL = new LinkedList<GameObject>(shoes);
        hatsLL = new LinkedList<GameObject>(hats);
        glassesLL = new LinkedList<GameObject>(glasses);
        petsLL = new LinkedList<GameObject>(pets);
        bgsLL = new LinkedList<Material>(bgs);

        currShirt = shirtsLL.First;
        currPants = pantsLL.First;
        currHair = hairLL.First;
        currShoes = shoesLL.First;
        currHat = hatsLL.First;
        currGlasses = glassesLL.First;
        currPet = petsLL.First;
        currbg = bgsLL.First;
    }

    //SCREEN MANAGEMENT--------------------------------------------------------------------
    void SetScreen(GameObject screen)
    {
        // disable all other screens
        changeBG.SetActive(false);
        nameHomie.SetActive(false);
        dressUp.SetActive(false);
        showcase.SetActive(false);
        // activate the requested screen
        screen.SetActive(true);
    }

    public void BackToMainMenu()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = festiveBling;
        audio.Play();
        SceneManager.LoadScene("Menu");
    }

    public void ToBGChoice()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = festiveBling;
        audio.Play();
        SetScreen(changeBG);
    }

    public void ToNaming()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = festiveBling;
        audio.Play();
        SetScreen(nameHomie);
    }

    public void ToMenu()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = festiveBling;
        audio.Play();
        SetScreen(dressUp);
    }

    public void ToShowcase()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = festiveBling;
        audio.Play();
        SetScreen(showcase);
    }

    public void ToCredits()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = festiveBling;
        audio.Play();
        SceneManager.LoadScene("Credits");
    }

    public void TakeScreenshotButton()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = festiveBling;
        audio.Play();
        ScreenCapture.CaptureScreenshot("Slay.png");
    }

    //TEXT-------------------------------------------------------------------------------
    public void SetName()
    {
        player = field.text;
    }

    public void SetWinText()
    {
        playerText.text = "You look FABULOUS, " + player + "!!!";
    }

    //CYCLING BGS--------------------------------------------------------------------
    public void BGSelectButton()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = festiveBling;
        audio.Play();

        if (currbg != null)
        {
            planeBG.gameObject.GetComponent<MeshRenderer>().material = currbg.Value;
        }

        if (currbg.Next != null)
        {
            currbg = currbg.Next;
        }
        else
        {
            currbg = bgsLL.First;
        }
    }

    /*public void BGSelectButton()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = festiveBling;
        audio.Play();
        if (maxbgReached == true)
        {
            currbgOption = 0;
            maxbgReached = false;
        }

        if (currbgOption < 6)
        {
            planeBG.gameObject.GetComponent<MeshRenderer>().material = bg[currbgOption];
        }
        currbgOption++;

        if (currbgOption == 6)
        {
            planeBG.gameObject.GetComponent<MeshRenderer>().material = bg[6];
            maxbgReached = true;
        }
    }*/

    //CYCLING CLOTHES--------------------------------------------------------------------
    void CycleThroughItems(ref LinkedListNode<GameObject> currentItem, LinkedList<GameObject> itemList)
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = festiveBling;
        audio.Play();

        if (currentItem != null)
        {
            currentItem.Value.SetActive(false);
        }

        if (currentItem.Next != null)
        {
            currentItem = currentItem.Next;
        }
        else
        {
            currentItem = itemList.First;
        }
    }

    public void HatRightButton()
    {
        CycleThroughItems(ref currHat, hatsLL);
        Debug.Log("Clicked");
    }

    public void HairRightButton()
    {
        CycleThroughItems(ref currHair, hairLL);
    }

    public void GlassesRightButton()
    {
        CycleThroughItems(ref currGlasses, glassesLL);
    }

    public void ShirtsRightButton()
    {
        CycleThroughItems(ref currShirt, shirtsLL);
    }

    public void PantsRightButton()
    {
        CycleThroughItems(ref currPants, pantsLL);
    }

    public void ShoesRightButton()
    {
        CycleThroughItems(ref currShoes, shoesLL);
    }

    public void PetsRightButton()
    {
        CycleThroughItems(ref currPet, petsLL);
    }
}
