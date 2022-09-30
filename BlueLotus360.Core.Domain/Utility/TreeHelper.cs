using BlueLotus360.Core.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Utility
{
    public class TreeItem<T>
    {
        public T Item { get; set; }
        public IEnumerable<TreeItem<T>> Children { get; set; }
    }

    public static class GenericHelpers
    {

        public static UIMenu BuildTree(this IList<UIMenu> nodes)
        {
            if (nodes == null)
            {
                throw new ArgumentNullException("nodes");
            }
            return new UIMenu().BuildTree(nodes);
        }

        private static UIMenu BuildTree(this UIMenu root, IList<UIMenu> nodes)
        {
            if (nodes.Count == 0) { return root; }

            var children = root.FetchChildren(nodes).ToList();

            foreach (UIMenu menu in children)
            {
                root.SubMenus.Add(menu);
            }

            root.RemoveChildren(nodes);

            for (int i = 0; i < children.Count; i++)
            {
                children[i] = children[i].BuildTree(nodes);
                if (nodes.Count == 0) { break; }
            }

            return root;
        }

        public static IEnumerable<UIMenu> FetchChildren(this UIMenu root, IList<UIMenu> nodes)
        {
            return nodes.Where(n => n.ParentId == root.MenuId);
        }
        public static void RemoveChildren(this UIMenu root, IList<UIMenu> nodes)
        {
            foreach (var node in root.SubMenus)
            {
                nodes.Remove(node);
            }
        }


        public static string GenerateAliasFromString(this string value)
        {
            if (value == null || value.Length == 0)
            {
                return Guid.NewGuid().ToString().Substring(0, 5);
            }

            string[] arr = value.Split(' ');
            if (arr.Length == 0)
            {
                return value.Substring(0, 1).ToUpper();
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach (string item in arr)
                {
                    if (item.Length > 0)
                    {
                        sb.Append(item.Substring(0, 1).ToUpper());
                    }
                }
                return sb.ToString();
            }

            return "";

        }



    }
}
