using Modules.Actors.Runtime;
using UnityEngine;

namespace TEW.Common.Data.Bindings
{
    [CreateAssetMenu(fileName = "Bindings_Data", menuName = "Data/Bindings/Key")]
    public class KeyBindingsData : ActorData
    {
        public string HorizontalKeyAxis => _horizontalKeyAxis;
        public string VerticalKeyAxis => _verticalKeyAxis;
        
        [SerializeField] private string _horizontalKeyAxis;
        [SerializeField] private string _verticalKeyAxis;

        protected override void CreateCallback(IActor owner)
        {
            
        }
    }
}