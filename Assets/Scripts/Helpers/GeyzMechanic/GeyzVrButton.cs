using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Helpers.GeyzMechanic
{
    public class GeyzVrButton : MonoBehaviour
    {
        [SerializeField] float watchDuration = 3f;
        [SerializeField] Image loadingSliderImage;
        [SerializeField] UnityEvent onClickEvent;

        float currentWatchDuration = 0f;

        void Start()
        {
            loadingSliderImage.fillAmount = 0;
        }

        public void UpdateClickAnimationValue()
        {
            loadingSliderImage.gameObject.SetActive(true);

            currentWatchDuration += Time.deltaTime;
            loadingSliderImage.fillAmount = currentWatchDuration/watchDuration;

            if (currentWatchDuration >= watchDuration)
            {
                currentWatchDuration = watchDuration;

                ClickAction();
            }
        }

        void ClickAction()
        {
            onClickEvent?.Invoke();
        }
    }
}