using System.Net.NetworkInformation;
using UnityEngine;

namespace Core
{
    public class DontDestroyThis: MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}