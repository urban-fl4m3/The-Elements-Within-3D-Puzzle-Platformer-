using Modules.Ticks.Runtime;
using UnityEngine;

namespace TEW.Game
{
    public class GameStarter : MonoBehaviour
    {
        private void Start()
        {
            TickBuilder
                .New()
                .Build();
        }
    }
}