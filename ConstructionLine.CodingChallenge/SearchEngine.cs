using System;
using System.Collections.Generic;
using System.Linq;

namespace ConstructionLine.CodingChallenge
{
    public class SearchEngine
    {
        private List<ColorCount> _colourCount { get; set; } = new List<ColorCount>();
        private List<SizeCount> _sizeCount { get; set; } = new List<SizeCount>();

        // color, size, count, chosenShirts
        private List<Tuple<Color, Size, int, List<Shirt>>> _shirtCount { get; set; } = new List<Tuple<Color, Size, int, List<Shirt>>>();

        public SearchEngine(List<Shirt> shirts)
        {
            // TODO: data preparation and initialisation of additional data structures to improve performance goes here.
            // Create new List of color/size variations to split the shirts into categories
            foreach (var size in Size.All)
            {
                foreach (var color in Color.All)
                {
                    var chosenShirts = shirts.Where(x => x.Color == color && x.Size == size).ToList();
                    _shirtCount.Add(new Tuple<Color, Size, int, List<Shirt>>(color, size, chosenShirts.Count, chosenShirts));
                }
            }

            // Setup the size and color counters for the results
            _colourCount.AddRange(Color.All.Select(x => new ColorCount { Color = x }));
            _sizeCount.AddRange(Size.All.Select(x => new SizeCount { Size = x }));            
        }

        public SearchResults Search(SearchOptions options)
        {
            // TODO: search logic goes here.                                                      
            List<Shirt> searchShirts = new List<Shirt>();

            foreach (var variation in _shirtCount.Where(x => 
            options.Colors.Contains(x.Item1) && options.Sizes.Contains(x.Item2)))
            {
                searchShirts.AddRange(variation.Item4);
                _colourCount[Color.All.FindIndex(a => a.Name == variation.Item1.Name)].Count += variation.Item3;
                _sizeCount[Size.All.FindIndex(a => a.Name == variation.Item2.Name)].Count += variation.Item3;
            }

            // Return the final results
            return new SearchResults
            {
                Shirts = searchShirts,
                ColorCounts = _colourCount,
                SizeCounts = _sizeCount
            };
        }
    }
}