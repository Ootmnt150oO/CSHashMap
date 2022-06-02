using System;

namespace HashTable
{
    class Program
    {
        Node root = null;
        static void Main(string[] args)
        {
            string[] strs = new string[] {"a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z"
                ,"一","二","三","四","五","六","七","八","九","十","零"};
            Program hashmap = new Program();
            for (int i = 0; i < strs.Length; i ++)
            {
                hashmap.put(strs[i], i);
            }
            Console.WriteLine(hashmap.toString());
            Console.WriteLine("key: 零 value: "+hashmap.get("零"));
            Console.WriteLine("key: a value: " + hashmap.get("a"));
            Console.WriteLine("key: p value: " + hashmap.get("p"));
            Console.WriteLine("Delete 七");
            hashmap.remove("七");
            Console.WriteLine("刪除後結果");
            Console.WriteLine(hashmap.toString());
        }
        public void put(string key,int value)
        {
           if(root == null)
            {
                root = new Node(new Hash(key, value));
            }
            else
            {
                Node node = root;
                while(node.getNext() != null)
                {
                    node = node.getNext();
                }
                node.setNext(new Node(new Hash(key, value)));
            }
        }
        public int get(String key)
        {
            Node node = root;
            while (node!=null)
            {
                if (node.getHash().getKey().Equals(key))
                {
                    return node.getHash().getValue();
                }
                node = node.getNext();
            }
            return -1;
        }
        public void remove(String key)
        {
            Node node = root;
            while(node != null)
            {
                if (node.getNext().getHash().getKey().Equals(key))
                {
                    node.setNext(node.getNext().getNext());
                    return;
                }
                node = node.getNext();
            }
        } 
        public string toString()
        {
            String str = String.Empty;
            Node node = root;
            while(node != null)
            {
                str += "key: " + node.getHash().getKey();
                str += " value: " + node.getHash().getValue();
                str += " ↓"+Environment.    NewLine;
                node = node.getNext();
            }
            str += "null";
            return str;
        }
        public int getSize()
        {
            int size = 0;
            Node node = root;
            while (node != null)
            {
                size++;
                node = node.getNext();
            }
            return size;
        }
    }
      
    class Hash
    {
        private string key;
        private int value;
        public Hash(string key,int value)
        {
            this.key = key;
            this.value = value;
        }
        public string getKey()
        {
            return key;
        }
        public int getValue()
        {
            return value;
        }
    }
    class Node
    {
        private Hash hash;
        private Node next = null;
        public Node(Hash hash)
        {
            this.hash = hash;
        }
        public Node getNext()
        {
            return next;
        }
        public void setNext(Node node)
        {
            this.next = node;
        }
        public Hash getHash()
        {
            return hash;
        }
    }
}
