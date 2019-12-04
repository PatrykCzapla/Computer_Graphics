using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octree_Color_Quantization
{
    public static class Tools
    {
        private static void initTree(ref TreeNode node, ref TreeNode parent)
        {
            node = new TreeNode();
            node.parent = parent;
            node.level = parent.level + 1;
            parent.childrenCount++;
        }

        public static void InsertTree(ref TreeNode node, Color RGB, ref TreeNode parent)
        {
            if (node == null) initTree(ref node, ref parent);
            if (node.level == 8)
            {
                node.referenceCount++;
                node.red += RGB.R;
                node.green += RGB.G;
                node.blue += RGB.B;
            }
            else
            {
                int child = 0;
                string color = Convert.ToString(RGB.ToArgb(), 2).Remove(0, 8);
                if (color[0 + node.level] == '1') child += 4;
                if (color[8 + node.level] == '1') child += 2;
                if (color[16 + node.level] == '1') child += 1;
                InsertTree(ref node.children[child], RGB, ref node);
            }
        }

        public static void ReduceTree(TreeNode root)
        {
            TreeNode node = new TreeNode();
            node.childrenCount = root.childrenCount;
            node.level = root.level;
            searchReduced(root, ref node);
            for(int i = 0; i < 8; i++)
            {
                if (node.children[i] == null) continue;
                node.referenceCount += node.children[i].referenceCount;
                node.red += node.children[i].red;
                node.green += node.children[i].green;
                node.blue += node.children[i].blue;
                node.children[i] = null;
                node.childrenCount--;
            }
        }

        public static Color getColor(TreeNode node, Color RGB)
        {
            if (node.childrenCount == 0)
                return Color.FromArgb((int)(node.red / node.referenceCount), (int)(node.green / node.referenceCount), (int)(node.blue / node.referenceCount));
            else
            {
                int child = 0;
                string color = Convert.ToString(RGB.ToArgb(), 2).Remove(0, 8);
                if (color[0 + node.level] == '1') child += 4;
                if (color[8 + node.level] == '1') child += 2;
                if (color[16 + node.level] == '1') child += 1;
                if (node.children[child] == null)
                {
                    List<int> goodIndexes = new List<int>();
                    for (int i = 0; i < 8; i++)
                        if (node.children[i] != null)
                            goodIndexes.Add(i);
                    goodIndexes = goodIndexes.OrderBy(x => Math.Min(x, child)).ToList();
                    child = goodIndexes.First();
                }                    
                return getColor(node.children[child], RGB);
            }
        }

        private static void searchReduced(TreeNode currentNode, ref TreeNode node)
        {
            for (int i = 0; i < 8; i++)
            {
                if (currentNode.children[i] == null) continue;
                if (currentNode.level > node.level)
                    node = currentNode;
                if (currentNode.level == node.level && node.referenceCount > currentNode.referenceCount)
                    node = currentNode;
                searchReduced(currentNode.children[i], ref node);
            }
        }

        public static int countColors(TreeNode node)
        {
            int result = 0;
            if (node.childrenCount == 0)
                result++;
            else
                for(int i = 0; i < 8; i++)
                {
                    if (node.children[i] == null) continue;
                    result += countColors(node.children[i]);
                }
            return result;
        }
    }
}
