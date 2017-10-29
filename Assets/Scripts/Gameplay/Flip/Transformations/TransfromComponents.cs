using UnityEngine;

namespace Scripts.Gameplay.Flip.Transformations
{
    public class TransfromComponents
    {
        public Vector3 Position { get; set; }
        public Quaternion Rotation { get; set; }

        public TransfromComponents(Transform transfrom)
        {
            var srcPosition = transfrom.position;
            Position = new Vector3(srcPosition.x, srcPosition.y, srcPosition.z);

            var srcRotation = transfrom.rotation;
            Rotation = new Quaternion(srcRotation.x, srcRotation.y, srcRotation.z, srcRotation.w);
        }
    }
}