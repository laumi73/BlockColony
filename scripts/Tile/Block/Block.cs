using System;

namespace LocalWorld.BlockNS
{
    public abstract class Block {
        public static readonly Block[] blockList = new Block[short.MaxValue];

        static Block() {
            blockList[Grass.Instance.BlockID] = Grass.Instance;
        }

        // Properties
        public abstract string BlockName {get;}
        public abstract short BlockID {get;}
        public abstract (byte, byte)[] BlockFaceTextureAtlasIndexes{get;}
        public abstract (float, float)[] BlockFaceTextureAtlasCoordinates{get;}

        // Methods
        protected static (float, float)[] ConvertToFractionalCoordinateArray((byte, byte)[] IndexArray) {
            (float, float)[] outputArray = new (float, float)[6];
            for (byte i = 0; i < 6; i++) {
                outputArray[i] = 
                    (IndexArray[i].Item1 * BlockResources.BASE_BLOCK_TEXTURE_WIDTH,
                    IndexArray[i].Item2 * BlockResources.BASE_BLOCK_TEXTURE_HEIGHT);
            }
            return outputArray;
        }
    }
}