using UnityEngine;

public class HideOnClick : MonoBehaviour
{

    public void OnClick()
    {
        gameObject.SetActive(false);
    }
}
