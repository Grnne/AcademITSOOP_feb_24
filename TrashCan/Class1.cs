using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrashCan;
internal class Class1
{

    public Node<T>? SearchNode(T item)
    {
        if (_root == null)
        {
            return null;
        }

        if (item.Equals(_root.Item))
        {
            return _root;
        }

        Node<T>? currentNode = _root;

        while (0 == 0)
        {
            int comparisonResult = Compare(item, currentNode.Item);

            if (comparisonResult == 0)
            {
                return currentNode;
            }

            if (comparisonResult < 0)
            {
                if (currentNode.Left is null)
                {
                    return null;
                }

                currentNode = currentNode.Left;
            }
            else
            {
                if (currentNode.Right is null)
                {
                    return null;
                }

                currentNode = currentNode.Right;
            }
        }
    }

}
