using TMPro;
using UnityEngine;

namespace UI.EndGame
{
    public class BlockUICell : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI countText;

        public void Initialize(int count, string name)
        {
            SetText(count, name);
        }

        private void SetText(int count, string name)
        {
            nameText.text = name;
            countText.text = "X" + count;
        }
    }
}