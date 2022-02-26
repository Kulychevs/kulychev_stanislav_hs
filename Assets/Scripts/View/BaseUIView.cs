using UnityEngine;


namespace HotSiberiansTest
{
    public abstract class BaseUIView : MonoBehaviour
    {
        public void SetActive(bool isActive)
        {
            GetComponent<Canvas>().enabled = isActive;
        }
    }
}
