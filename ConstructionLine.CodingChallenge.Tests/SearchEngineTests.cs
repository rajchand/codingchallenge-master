using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace ConstructionLine.CodingChallenge.Tests
{
    [TestFixture]
    public class SearchEngineTests : SearchEngineTestsBase
    {
        private List<Shirt> _shirts;
        private SearchEngine _searchEngine;

        [Test]
        public void TestNoShirtsAvailable()
        {
            _shirts = new List<Shirt>();
            _searchEngine = new SearchEngine(_shirts);

            var searchOptions = new SearchOptions
            {
                Colors = new List<Color> { Color.Red },
                Sizes = new List<Size> { Size.Small, Size.Medium }
            };

            var results = _searchEngine.Search(searchOptions);

            AssertResults(results.Shirts, searchOptions);
            AssertValidSearchOptions(searchOptions);
            AssertSizeCounts(_shirts, searchOptions, results.SizeCounts);
            AssertColorCounts(_shirts, searchOptions, results.ColorCounts);
        }

        [Test]
        public void TestSubSetVariationOfColorSizes()
        {
            _shirts = new List<Shirt>
            {
                new Shirt(Guid.NewGuid(), "Red - Small", Size.Small, Color.Red),
                new Shirt(Guid.NewGuid(), "Black - Medium", Size.Medium, Color.Black),
                new Shirt(Guid.NewGuid(), "Blue - Large", Size.Large, Color.Blue),
            };

            _searchEngine = new SearchEngine(_shirts);

            var searchOptions = new SearchOptions
            {
                Colors = new List<Color> { Color.Red },
                Sizes = new List<Size> { Size.Small, Size.Medium }
            };

            var results = _searchEngine.Search(searchOptions);

            AssertResults(results.Shirts, searchOptions);
            AssertValidSearchOptions(searchOptions);
            AssertSizeCounts(_shirts, searchOptions, results.SizeCounts);
            AssertColorCounts(_shirts, searchOptions, results.ColorCounts);
        }

        [Test]
        public void TestAllVariationsOfColorSize()
        {
            _shirts = new List<Shirt>
            {
                new Shirt(Guid.NewGuid(), "Red - Small", Size.Small, Color.Red),
                new Shirt(Guid.NewGuid(), "Black - Small", Size.Small, Color.Black),
                new Shirt(Guid.NewGuid(), "Blue - Small", Size.Small, Color.Blue),
                new Shirt(Guid.NewGuid(), "White - Small", Size.Small, Color.White),
                new Shirt(Guid.NewGuid(), "Yellow - Small", Size.Small, Color.Yellow),

                new Shirt(Guid.NewGuid(), "Red - Medium", Size.Medium, Color.Red),
                new Shirt(Guid.NewGuid(), "Black - Medium", Size.Medium, Color.Black),
                new Shirt(Guid.NewGuid(), "Blue - Medium", Size.Medium, Color.Blue),
                new Shirt(Guid.NewGuid(), "White - Medium", Size.Medium, Color.White),
                new Shirt(Guid.NewGuid(), "Yellow - Medium", Size.Medium, Color.Yellow),

                new Shirt(Guid.NewGuid(), "Red - Large", Size.Large, Color.Red),
                new Shirt(Guid.NewGuid(), "Black - Large", Size.Large, Color.Black),
                new Shirt(Guid.NewGuid(), "Blue - Large", Size.Large, Color.Blue),
                new Shirt(Guid.NewGuid(), "White - Large", Size.Large, Color.White),
                new Shirt(Guid.NewGuid(), "Yellow - Large", Size.Large, Color.Yellow)
            };

            _searchEngine = new SearchEngine(_shirts);

            var searchOptions = new SearchOptions
            {
                Colors = new List<Color> { Color.Red, Color.Black, Color.Blue, Color.White, Color.Yellow },
                Sizes = new List<Size> { Size.Small, Size.Medium, Size.Large }
            };

            var results = _searchEngine.Search(searchOptions);

            AssertResults(results.Shirts, searchOptions);
            AssertValidSearchOptions(searchOptions);
            AssertSizeCounts(_shirts, searchOptions, results.SizeCounts);
            AssertColorCounts(_shirts, searchOptions, results.ColorCounts);
        }
    }
}
