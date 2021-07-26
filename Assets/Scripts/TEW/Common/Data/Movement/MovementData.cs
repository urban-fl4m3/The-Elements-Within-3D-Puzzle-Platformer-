using Modules.Actors.Runtime;
using UnityEngine;

namespace TEW.Common.Data.Movement
{
    [CreateAssetMenu(fileName = "Movement_Data", menuName = "Data/Movement/Movement")]
    public class MovementData : ActorData
    {
        public bool IsMoving { get; set; }
        
        protected override void CreateCallback(IActor owner)
        {
            
        }
    }
}