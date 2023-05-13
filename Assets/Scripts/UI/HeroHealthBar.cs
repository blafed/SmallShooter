using UnityEngine.UI;
using UnityEngine;

public class HeroHealthBar : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] Image fillingBar;
    private void Update()
    {
        canvasGroup.alpha = Hero.current ? 1 : 0;
        if (Hero.current)
        {
            var from = fillingBar.fillAmount;
            var to = Hero.current.health.hp;
            fillingBar.fillAmount = Mathf.Lerp(from, to, Time.deltaTime * 5);
        }
    }
}