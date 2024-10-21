using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWarsProject
{
    public class KataFinder
    {
        public static List<(int, int)> GetNextMove(int x, int y)
        {
            return new List<(int, int)>()
            {
                (x - 1, y), 
                (x + 1, y), 
                (x, y - 1),
                (x, y + 1) 
            };
        }

        public static bool PathFinder(string maze)
        {
            var paths = maze.Split("\n");
            int height = paths.Length;
            int width = paths[0].Length;

            var searchPaths = new Queue<List<(int, int)>>();
            searchPaths.Enqueue(new List<(int, int)> { (0, 0) });

            var visitedCoordinates = new HashSet<(int, int)>() { (0, 0) };

            while (searchPaths.Any())
            {
                var currentPath = searchPaths.Dequeue();
                var currentCoordinate = currentPath.Last();

                if (currentCoordinate == (width - 1, height - 1))
                    return true;

                foreach (var (nextX, nextY) in GetNextMove(currentCoordinate.Item1, currentCoordinate.Item2))
                {
                    if (nextX < 0 || nextX >= width || nextY < 0 || nextY >= height)
                        continue;

                    if (visitedCoordinates.Contains((nextX, nextY)))
                        continue;

                    if (paths[nextY][nextX] == 'W') 
                        continue;

                    visitedCoordinates.Add((nextX, nextY));
                    var newPath = new List<(int, int)>(currentPath) { (nextX, nextY) };
                    searchPaths.Enqueue(newPath);
                }
            }

            return false;
        }
    }
}