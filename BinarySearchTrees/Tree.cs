﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTrees
{
    abstract class Tree
    {
        public Tree()
        {}

        abstract public void Include(int key);

        public void NotUniqueKey(int key)
        {
            System.Console.WriteLine($"key {key} already exists!");
            // throw new SystemException($"key {key} already exists!");
        }
    }
}
