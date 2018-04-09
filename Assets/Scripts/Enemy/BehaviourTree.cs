using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree {

    public abstract class Node<T> {

        public abstract bool BTUpdate(T context);

    }

    public abstract class NodeBranch<T> : Node<T> {
        protected Node<T>[] childArray;

        protected NodeBranch(params Node<T>[] c) {
            childArray = c;
        }
    }

    // Excute next child if failed. Return true if any child succeeded
    public class NodeSelector<T> : NodeBranch<T> {

        public NodeSelector(params Node<T>[] c) {
            childArray = c;
        }

        public override bool BTUpdate(T context) {
            foreach (Node<T> child in childArray) {
                if (child.BTUpdate(context))
                    return true;
            }
            return false;
        }
    }

    // Excute next child if succeeded. Return true if all childs succeeded
    public class NodeSequence<T> : NodeBranch<T> {

        public NodeSequence(params Node<T>[] c) {
            childArray = c;
        }

        public override bool BTUpdate(T context) {
            foreach (Node<T> child in childArray) {
                if (child.BTUpdate(context) == false)
                    return false;
            }
            return true;
        }
    }

    // Excute only the first child. Return true if the first child failed
    public class NodeNot<T> : NodeBranch<T> {

        public NodeNot(params Node<T>[] c) {
            childArray = c;
        }

        public override bool BTUpdate(T context) {
            return !childArray[0].BTUpdate(context);
        }
    }
}
