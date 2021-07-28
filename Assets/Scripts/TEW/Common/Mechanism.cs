using Modules.Common.Runtime;
using UnityEngine;

namespace TEW.Common
{
    public abstract class Mechanism : MonoBehaviour
    {
        public abstract DynamicDynamicProperty<bool> DynamicProperty { get; }
    }
}