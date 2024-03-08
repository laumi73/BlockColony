using System;

namespace LocalWorld.BlockNS
{
    public sealed class Stone : BaseBlock
    {
        // Fields
        private readonly BlockResources.BlockDictionary _blockEnum = BlockResources.BlockDictionary.Stone;

        // Faces
        private static readonly (byte, byte) _topFaceIndex = (2, 5);
        private static readonly (byte, byte) _bottomFaceIndex = _topFaceIndex;
        private static readonly (byte, byte) _leftFaceIndex = _topFaceIndex;
        private static readonly (byte, byte) _rightFaceIndex = _topFaceIndex;
        private static readonly (byte, byte) _frontFaceIndex = _topFaceIndex;
        private static readonly (byte, byte) _backFaceIndex = _topFaceIndex;

        // Singleton setup
        private static readonly Lazy<Stone> lazy = new(() => new Stone());
        public static Stone Instance { get { return lazy.Value; } }

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