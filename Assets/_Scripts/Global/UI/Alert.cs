using System.Collections;
using UnityEngine;
using TMPro;

namespace Global.UI
{
    public abstract class Alert : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _alertTmp;
        [SerializeField] private float _showSeconds; 

        protected TextMeshProUGUI AlertTmp => _alertTmp;
        public float ShowSeconds => _showSeconds;

        protected void WaitSecondsAndHideAlert() => StartCoroutine(HideAlertAfterSeconds(_showSeconds));

        private IEnumerator HideAlertAfterSeconds(float showSeconds)
        {
            yield return new WaitForSeconds(showSeconds);
            _alertTmp.gameObject.SetActive(false);
        }
    }
}