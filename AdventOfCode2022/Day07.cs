namespace AdventOfCode2022
{
    public static class Day07
    {
        private class File
        {
            public File(string name, int size)
            {
                this.Name = name;
                this.Size = size;
            }
            
            public string Name { get; set; }

            public int Size { get; set; }
        }
        
        private class Directory
        {
            public Directory(string name)
            {
                this.Name = name;
            }
            
            public string Name { get; set; }

            public HashSet<Directory> Directories { get; set; } = new HashSet<Directory>();

            public HashSet<File> Files { get; set; } = new HashSet<File>();

            public int GetSize()
            {
                var size = 0;

                foreach (var file in this.Files)
                {
                    size += file.Size;
                }

                foreach (var directory in this.Directories)
                {
                    size += directory.GetSize();
                }

                return size;
            }
        }

        
        private static List<Directory> directories = new List<Directory>();
        private static Stack<Directory> currentLocation = new Stack<Directory>();

        public static void Task01(string input)
        {
            var inputLines = input.Split(Environment.NewLine).ToList();

            // first line of input is: "$ cd /"
            var root = new Directory("/");
            currentLocation.Push(root);

            // read next lines of input
            var queue = new Queue<string>();
            for (int i = 1; i < inputLines.Count; i++)
            {
                queue.Enqueue(inputLines[i]);
            }
            ReadInput(queue);
            directories.Add(root);

            var totalSizeOfDirsBelow100000 = 0;
            foreach (var dir in directories)
            {
                var size = dir.GetSize();

                if (size <= 100000)
                {
                    totalSizeOfDirsBelow100000 += size;
                }
            }
            Console.WriteLine(totalSizeOfDirsBelow100000);
        }

        public static void Task02(string input)
        {
            var inputLines = input.Split(Environment.NewLine).ToList();

            // first line of input is: "$ cd /"
            var root = new Directory("/");
            currentLocation.Push(root);

            // read next lines of input
            var queue = new Queue<string>();
            for (int i = 1; i < inputLines.Count; i++)
            {
                queue.Enqueue(inputLines[i]);
            }
            ReadInput(queue);
            directories.Add(root);

            var totalSpace = 70000000;
            var neededSpace = 30000000;

            var rootSize = root.GetSize();
            var unusedSpace = totalSpace - rootSize;

            var diff = neededSpace - unusedSpace;
            var smallest = int.MaxValue;

            foreach (var dir in directories)
            {
                var size = dir.GetSize();

                if (size >= diff && size < smallest)
                {
                    smallest = size;
                }
            }
            Console.WriteLine(smallest);
        }

        private static void ReadInput(Queue<string> inputLines)
        {            
            var line = inputLines.Dequeue();
            while (inputLines.Count > 0)
            {
                var lineParts = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (lineParts[0] == "$") // command
                {
                    if (lineParts[1] == "cd") // change dir
                    {
                        var goTo = lineParts[2];

                        if (goTo == "..") // move out
                        {
                            var dir = currentLocation.Pop();
                            directories.Add(dir);
                        }
                        else // move in
                        {
                            currentLocation.Push(currentLocation.Peek().Directories.First(dir => dir.Name == goTo));
                        }

                        line = inputLines.Dequeue();
                        continue;
                    }
                    else if (lineParts[1] == "ls") // list
                    {
                        while (true)
                        {
                            if (inputLines.Count == 0)  // new command
                            {
                                break;
                            }

                            line = inputLines.Dequeue();

                            if (line.StartsWith("$"))  // new command
                            {
                                break;
                            }
                            else // listed dir or file
                            {
                                var dirOrFileParams = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                                if (dirOrFileParams[0] == "dir") // listed dir
                                {
                                    var dirName = dirOrFileParams[1];
                                    currentLocation.Peek().Directories.Add(new Directory(dirName));
                                }
                                else // listed file
                                {
                                    var fileSize = int.Parse(dirOrFileParams[0]);
                                    var fileName = dirOrFileParams[1];
                                    currentLocation.Peek().Files.Add(new File(fileName, fileSize));
                                }
                            }
                        }
                        continue;
                    }
                }
            }
            var lastDir = currentLocation.Pop();
            directories.Add(lastDir);
        }
    }
}
