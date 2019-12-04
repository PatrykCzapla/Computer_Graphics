using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octree_Color_Quantization
{
    public class TreeNode
    {
        public TreeNode parent;
        public int level;
        public long referenceCount;
        public long red;
        public long green;
        public long blue;
        public TreeNode[] children = new TreeNode[8];
        public int childrenCount;
    }
}
