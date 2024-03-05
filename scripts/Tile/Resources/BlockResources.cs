using System;
using System.Linq;

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

        public static readonly BaseBlock[] blockList = new BaseBlock[((ushort)Enum.GetNames(typeof(BlockDictionary)).Length)];
        static BlockResources()
        {
            foreach (
                BaseBlock block in typeof(BaseBlock).Assembly.GetTypes()
                .Where(t => t.IsSubclassOf(typeof(BaseBlock)) && !t.IsAbstract)
                .Cast<BaseBlock>().ToArray())
            {
                blockList[block.BlockID] = block;
            }
        }

        public enum BlockDictionary : ushort
        {
            Air = 0,
            Grass = 1,
            Dirt = 2,
            Stone = 3
        }
    }
}