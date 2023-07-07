using UnityEngine;

namespace Global.UI
{
    public class Panel : MonoBehaviour
    {
        protected void Hide() => gameObject.SetActive(false);
        protected void Show() => gameObject.SetActive(true);
    }
}