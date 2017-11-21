using Scripts.Gameplay.Flip.FromDirectFactories;
using Scripts.Gameplay.Flip.Transformations;
using System;
using UnityEngine;
using Scripts.Gameplay.Animations;

namespace Scripts.Gameplay.Flip
{
    public class FlipBehavior : MonoBehaviour, IFlipBehavior
    {
        private const float DeltaAngle = 90f;

        private IBlockAnimation _blockAnimation;
        private Transform _block;

        private Transformation Transformation { get; set; }

        private IFromDirectAbstractFactory FromDirectFactory { get; set; }

        #region MonoBehaviour members

        private void Start()
        {
            _blockAnimation = GetComponent<BlockAnimation>();
            _block = GetComponent<Transform>();
            Transformation = new Transformation
            {
                Source = new TransfromComponents(_block),
                Target = new TransfromComponents(_block)
            };
        }

        private void Update()
        {
            if (_blockAnimation.IsOnAnimation)
            {
                _block.SetPositionAndRotation(Transformation.Source.Position, Transformation.Source.Rotation);
                _block.RotateAround(
                    _block.position + Transformation.DeltaPoint, 
                    Transformation.Axis,
                    DeltaAngle * _blockAnimation.ElapsedPart
                );
            }
            else
            {
                _block.SetPositionAndRotation(Transformation.Target.Position, Transformation.Target.Rotation);
            }
        }

        #endregion

        #region IFlipBehavior members

        public void Init(Orientation blockOrientation)
        {
            SetCurrentFlipState(blockOrientation);
        }

        public Orientation Flip(Direct direct)
        {
            var flipResult = new FlipResult();
            var axis = new Vector3();

            switch (direct)
            {
                case Direct.Down:
                    axis = new Vector3(-1f, 0f, 0f);
                    flipResult = FromDirectFactory.FlipDown(_block);
                    break;
                case Direct.Up:
                    axis = new Vector3(1f, 0f, 0f);
                    flipResult = FromDirectFactory.FlipUp(_block);
                    break;
                case Direct.Left:
                    axis = new Vector3(0f, 0f, 1f);
                    flipResult = FromDirectFactory.FlipLeft(_block);
                    break;
                case Direct.Right:
                    axis = new Vector3(0f, 0f, -1f);
                    flipResult = FromDirectFactory.FlipRight(_block);
                    break;
                default:
                    throw new Exception("unknown direct");
            }

            SetCurrentFlipState(flipResult.Orientation);

            SetTransformation(flipResult.DeltaPoint, axis);

            return flipResult.Orientation;
        }

        #endregion

        private void SetCurrentFlipState(Orientation orientation)
        {
            switch (orientation)
            {
                case Orientation.X:
                    FromDirectFactory = new FromDirectXFactory();
                    break;
                case Orientation.Y:
                    FromDirectFactory = new FromDirectYFactory();
                    break;
                case Orientation.Z:
                    FromDirectFactory = new FromDirectZFactory();
                    break;
                default:
                    throw new Exception("unknown orientation");
            }
        }

        private void SetTransformation(Vector3 deltaPoint, Vector3 axis)
        {
            Transformation.Axis = axis;
            Transformation.DeltaPoint = deltaPoint;

            Transformation.Source = new TransfromComponents(_block);

            _block.RotateAround(_block.position + deltaPoint, axis, DeltaAngle );

            Transformation.Target = new TransfromComponents(_block);

            //_block.RotateAround(_block.position - deltaPoint, axis * -1, -DeltaAngle);
            _block.SetPositionAndRotation(Transformation.Source.Position, Transformation.Source.Rotation);
        }
    }
}