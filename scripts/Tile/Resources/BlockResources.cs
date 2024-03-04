using LocalWorld.BlockNS;

namespace LocalWorld.BlockNS
{
    public static class BlockResources
    {
        // Constants
        public const string BASE_BLOCK_ATLAS_FILEPATH = "res://resources/spatialMaterials/blockMaterial.tres";

        public const int BASE_BLOCK_ATLAS_HEIGHT = 16;
        public const int BASE_BLOCK_ATLAS_WIDTH = 8;

        public const float BASE_BLOCK_TEXTURE_HEIGHT = 1f / BASE_BLOCK_ATLAS_HEIGHT;
        public const float BASE_BLOCK_TEXTURE_WIDTH = 1f / BASE_BLOCK_ATLAS_WIDTH;

        public static readonly BaseBlock[] blockList = new BaseBlock[short.MaxValue];
        static BlockResources()
        {
            blockList[Grass.Instance.BlockID] = Grass.Instance;
        }

        public enum BlockDictionary
        {
            Air = 0,
            Grass = 1,
            Dirt = 2,
            Stone = 3
        }
    }
}