using UnityEngine;
using UnityEngine.UI;


namespace HotSiberiansTest
{
    public sealed class HPInfoView : BaseUIView
    {
        [SerializeField] private Image _hpImage;

        public void SetNormalizedHP(float hp)
        {
            _hpImage.fillAmount = hp;
        }
    }
}
