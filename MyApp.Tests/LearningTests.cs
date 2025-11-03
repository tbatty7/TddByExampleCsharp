using MyApp.Core.Learning;
using Xunit.Abstractions;

namespace MyApp.Core
{
}

namespace MyApp.Tests
{
    public class LearningTests
    {
        private readonly ITestOutputHelper testOutputHelper;

        public LearningTests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void StringInterpolation()
        {
            var name = "World";
            Assert.Equal("Hello World", $"Hello {name}");
        }

        [Fact]
        public void StructTest()
        {
            var point = new Point(1, 2);
            var point2 = new Point(1, 2);
            Assert.Equal(point, point2);
        }

        [Fact]
        public void ListCollections()
        {
            var nums = new List<int> { 1, 2, 3, 4, 5 };
            nums.Add(6);
            var evensEnumerable = nums.Where(n => n % 2 == 0).Select(n => n * 10);
            foreach (var i in evensEnumerable)
            {
                testOutputHelper.WriteLine("Proper log: " + i);
                Console.WriteLine("You cannot see me in tests!");
            }

            var evensList = evensEnumerable.ToList();
            foreach (var i in evensList) testOutputHelper.WriteLine("Proper log: " + i);

            Assert.Equal(evensList, new List<int> { 20, 40, 60 });
        }

        [Fact]
        public void PatternMatching()
        {
            var util = new StringStuff();
            Assert.Equal("Not a string", util.returnIfString(1));
            Assert.Equal("1", util.returnIfString("1"));
        }

        [Fact]
        public void RecordsAreDataClasses()
        {
            var dollarRecord = new DollarRecord(1);
            var dollarRecord2 = new DollarRecord(1);
            Assert.Equal(1, dollarRecord.amount);
            Assert.Equal(dollarRecord, dollarRecord2);
        }

        [Fact]
        public void NullableTypes()
        {
            var util = new StringStuff();
            var result = util.nullCheckName(null);
            Assert.Equal("No name", result);

            var name = util.nullCheckName("Bob");
            Assert.Equal("Bob", name);
        }

        [Fact]
        public void SwitchExpressions()
        {
            var util = new StringStuff();
            Assert.Equal("one", util.numberToString(1));
            Assert.Equal("two", util.numberToString(2));
            Assert.Equal("three", util.numberToString(3));
            Assert.Equal("I'm tired, write out your own numbers...", util.numberToString(4));
        }

        [Fact]
        public void UnsafeDictionaries()
        {
            var dictionaryWithConstructor = new Dictionary<string, string>();

            try
            {
                var noValue = dictionaryWithConstructor["key"];
                Assert.Fail("Exception should have been thrown");
            }
            catch (Exception e)
            {
                Assert.True(true, "Exception thrown when no value is present");
            }
        }

        [Fact]
        public void SafeDictionaryAccess()
        {
            var dictionary = new Dictionary<string, string>();

            var value = dictionary.GetValueOrDefault("key", "not found");

            Assert.Equal("not found", value);
            Assert.False(dictionary.ContainsKey("key"));
        }

        [Fact]
        public void DictionaryInitialization()
        {
            var dictionaryWithValue = new Dictionary<string, string>
            {
                ["key"] = "value"
            };
            Assert.Equal("value", dictionaryWithValue["key"]);
        }

        [Fact]
        public void DictionaryTryGetValue()
        {
            var emptyDict = new Dictionary<string, string>();
            var result = emptyDict.TryGetValue("key", out var value);
            Assert.False(result);
            Assert.Null(value);
            emptyDict.Add("key", "value");
            result = emptyDict.TryGetValue("key", out value);
            Assert.True(result);
            Assert.Equal("value", value);
        }

        [Fact]
        public void UsingTryGetValue()
        {
            var emptyDict = new Dictionary<string, string>();
            var util = new LargerStructures();

            var result = util.TryGetValue(emptyDict, "key");
            Assert.Equal("Not found", result);

            emptyDict.Add("key", "value");
            result = util.TryGetValue(emptyDict, "key");
            Assert.Equal("value", result);
        }

        [Fact]
        public void LinqHasForEach()
        {
            var lastNumber = 0;
            var numbers = new List<int> { 1, 2, 3, 4, 5 };
            numbers.ForEach(i => lastNumber = i + 2);
            Assert.Equal(7, lastNumber);
        }

        [Fact]
        public void LinqHasFiltering()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };
            var evens = numbers.Where(i => i % 2 == 0).ToList();
            Assert.Equal("2, 4", string.Join(", ", evens));
        }

        [Fact]
        public void LinqHasMapping()
        {
            var numbers = new List<int> { 1, 2, 3 };
            var biggerNumbers = numbers.Select(i => i * 10).ToList();
            Assert.Equal("10, 20, 30", string.Join(", ", biggerNumbers));
        }
    }
}