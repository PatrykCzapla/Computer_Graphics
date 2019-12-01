﻿using System;
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
            parent.childCount++;
        }

        public static void InsertTree(ref TreeNode node, Color RGB, ref TreeNode parent)
        {
            if (node == null) initTree(ref node, ref parent);
            if (node.level == 8)
            {
                node.references++;
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
                if (child < 0 || child > 7) throw new IndexOutOfRangeException("Wrong child index.");
                InsertTree(ref node.children[child], RGB, ref node);
            }
        }

        public static void ReduceTree(TreeNode root, int colorsCount)
        {
            while (countLeafs(root) > colorsCount)
            {
                TreeNode node = new TreeNode();
                node.childCount = root.childCount;
                node.references = root.references;
                node.red = root.red;
                node.green = root.green;
                node.blue = root.blue;

                searchReduced(root, ref node);

                for(int i = 0; i < 8; i++)
                {
                    if (node.children[i] == null) continue;
                    node.references += node.children[i].references;
                    node.red += node.children[i].red;
                    node.green += node.children[i].green;
                    node.blue += node.children[i].blue;
                    node.children[i] = null;
                }
                node.childCount = 0;
            }
        }

        public static Color getColor(TreeNode node, Color RGB)
        {
            if (node.childCount == 0)
                return Color.FromArgb((int)(node.red / node.references), (int)(node.green / node.references), (int)(node.blue / node.references));
            else
            {
                int child = 0;
                string color = Convert.ToString(RGB.ToArgb(), 2).Remove(0, 8);
                if (color[0 + node.level] == '1') child += 4;
                if (color[8 + node.level] == '1') child += 2;
                if (color[16 + node.level] == '1') child += 1;
                if (child < 0 || child > 7) throw new IndexOutOfRangeException("Wrong child index.");
                return getColor(node.children[child], RGB);
            }
        }

        private static void searchReduced(TreeNode currentNode, ref TreeNode node)
        {
            for (int i = 0; i < 8; i++)
            {
                if (currentNode.children[i] == null) continue;
                if (currentNode.level != 7) searchReduced(currentNode.children[i], ref node);
                else
                {
                    if (currentNode.level > node.level)
                        node = currentNode;
                    if (currentNode.level == node.level && node.references > currentNode.references)
                        node = currentNode;
                }                  
            }
        }

        private static int countLeafs(TreeNode node)
        {
            int result = 0;
            if (node.level == 8)
                result++;
            else
                for(int i = 0; i < 8; i++)
                {
                    if (node.children[i] == null) continue;
                    result += countLeafs(node.children[i]);
                }
            return result;
        }
    }
}
