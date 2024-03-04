using System;

namespace LocalWorld.BlockNS
{
    public sealed class Grass : Block
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
        public override (byte, byte) TopFaceAtlasIndex { get { return _topFaceIndex; } }
        public override (byte, byte) BottomFaceAtlasIndex { get { return _bottomFaceIndex; } }
        public override (byte, byte) LeftFaceAtlasIndex { get { return _leftFaceIndex; } }
        public override (byte, byte) RightFaceAtlasIndex { get { return _rightFaceIndex; } }
        public override (byte, byte) FrontFaceAtlasIndex { get { return _frontFaceIndex; } }
        public override (byte, byte) BackFaceAtlasIndex { get { return _backFaceIndex; } }
    }
}