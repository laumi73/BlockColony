using System;

namespace LocalWorld.BlockNS
{
    public sealed class Grass : BaseBlock
    {
        // Fields
        private readonly BlockResources.BlockDictionary _blockEnum = BlockResources.BlockDictionary.Grass;

        // Faces
        private static readonly (byte, byte) _topFaceIndex = (5, 0);
        private static readonly (byte, byte) _bottomFaceIndex = (5, 1);
        private static readonly (byte, byte) _leftFaceIndex = _bottomFaceIndex;
        private static readonly (byte, byte) _rightFaceIndex = _bottomFaceIndex;
        private static readonly (byte, byte) _frontFaceIndex = _bottomFaceIndex;
        private static readonly (byte, byte) _backFaceIndex = _bottomFaceIndex;

        // Singleton setup
        private static readonly Lazy<Grass> lazy = new(() => new Grass());
        public static Grass Instance { get { return lazy.Value; } }

        // Properties
        public override BlockResources.BlockDictionary BlockEnum { get { return _blockEnum; } }
        protected override (byte, byte) TopFaceAtlasIndex { get { return _topFaceIndex; } }
        protected override (byte, byte) BottomFaceAtlasIndex { get { return _bottomFaceIndex; } }
        protected override (byte, byte) LeftFaceAtlasIndex { get { return _leftFaceIndex; } }
        protected override (byte, byte) RightFaceAtlasIndex { get { return _rightFaceIndex; } }
        protected override (byte, byte) FrontFaceAtlasIndex { get { return _frontFaceIndex; } }
        protected override (byte, byte) BackFaceAtlasIndex { get { return _backFaceIndex; } }
    }
}