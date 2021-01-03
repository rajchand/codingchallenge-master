using System.Collections.Generic;
using System.Linq;

namespace ConstructionLine.CodingChallenge
{
    public class SearchEngine
    {
        private List<List<Shirt>> _sortedShirts { get; set; } = new List<List<Shirt>>();
        private List<ColorCount> _colourCount { get; set; } = new List<ColorCount>();
        private List<SizeCount> _sizeCount { get; set; } = new List<SizeCount>();

        public SearchEngine(List<Shirt> shirts)
        {
            // TODO: data preparation and initialisation of additional data structures to improve performance goes here.
            // Create new List of color/size variations to split the shirts into categories
            foreach (var size in Size.All)
            {
                foreach (var color in Color.All)
                {
                    _sortedShirts.Add(shirts.Where(x => x.Color == color && x.Size == size).ToList());
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

            // Loop through each variation of color / shirt combination and only add with the ones that match the search options            
            foreach (var variation in _sortedShirts.Where(x => x.Any() 
            && options.Colors.Contains(x.First().Color) 
            && options.Sizes.Contains(x.First().Size)))
            {
                searchShirts.AddRange(variation);
                _colourCount[Color.All.FindIndex(a => a.Name == variation.First().Color.Name)].Count += variation.Count();
                _sizeCount[Size.All.FindIndex(a => a.Name == variation.First().Size.Name)].Count += variation.Count();
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