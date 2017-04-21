using class_diagram_lab.containers;
using NUnit.Framework;

namespace class_diagram_lab.Tests
{
    [TestFixture(typeof(ArrayBaseList<IProduct>))]
    public class TestList<T> where T : IList<IProduct>, new()
    {
        private IList<IProduct> testedObject = null;

        [SetUp]
        public void BeforTest()
        {
            testedObject = new T();
        }

        [TearDown]
        public void AfterTest()
        {
            testedObject = null;
        }

        [Test]
        public void AddTest()
        {
            Assert.AreEqual(0, testedObject.Count);
            IProduct novel = new Novel(name: "good story", author: "Goodman");
            testedObject.Add(novel);
            Assert.AreEqual(1, testedObject.Count);
            string marker = "Sonet";
            for (int i = 0; i < 9; i++)
            {
                testedObject.Add(new Song(name: $"{marker}#{i}", author: "Storymaker"));
            }
            Assert.AreEqual(10, testedObject.Count);
            Assert.AreEqual($"{marker}#1", testedObject[2].Name);
            Assert.AreSame(novel, testedObject[0]);
        }

        [Test]
        public void indexTest()
        {
            string workName = "fiction";
            Novel novel = new Novel(name: workName);
            Drama drama = new Drama(name: workName);
            testedObject.Add(novel);
            testedObject.Add(drama);

            Assert.AreEqual(novel, testedObject[workName]);
            Assert.AreNotEqual(drama, testedObject[workName]);

            Assert.Throws<ItemNotFoundException>(() =>
            {
                var stubb = testedObject["stubb"];
            });
        }

        [Test]
        public void RemoveByItemTest()
        {
            Drama testItem = new Drama(content: "for deleting this drama creating.....", name: "sad drama",
                author: "cvetik");
            testedObject.Add(new Drama());
            testedObject.Add(testItem);
            testedObject.Add(new Drama());
            testedObject.Add(new Drama());

            testedObject.Remove(testItem);
            for (int i = 0; i < testedObject.Count; i++)
                Assert.AreNotEqual(testItem, testedObject[i]);

            Assert.Throws<ItemNotFoundException>(() => testedObject.Remove(new Drama()));
        }

        public void RepeatItemTest()
        {
            Drama repeatItem = new Drama(content: "for deleting this drama creating.....", name: "sad drama2",
                author: "cvetik");
            testedObject.Add(new Drama());
            testedObject.Add(repeatItem);
            testedObject.Add(new Drama());
            testedObject.Add(repeatItem);
            testedObject.Add(repeatItem);

            testedObject.Remove(repeatItem);
            bool isContinsRepeatItem = false;
            for (int i = 0; i < testedObject.Count && !isContinsRepeatItem; i++)
                isContinsRepeatItem = testedObject[i].Equals(repeatItem);
            Assert.AreEqual(true, isContinsRepeatItem);
        }

        [Test]
        public void RemoveByIndexTest()
        {
            Novel n1 = new Novel();
            Novel n2 = new Novel();
            testedObject.Add(n1);
            testedObject.Add(n2);

            testedObject.Remove(0);
        }

        [Test]
        public void RemoveByNameTest()
        {
            string[] songsName = {"Sonet", "arabeska", "fake name"};
            Song testItem1 = new Song(content: "pam pam pam", name: songsName[0], author: "cvetik");
            Song testItem2 = new Song(content: "pam pam pam", name: songsName[1], author: "cvetik");
            testedObject.Add(new Drama());
            testedObject.Add(new Drama());
            testedObject.Add(testItem2);
            testedObject.Add(new Drama());
            testedObject.Add(testItem1);

            testedObject.Remove(songsName[0]);
            for (int i = 0; i < testedObject.Count; i++)
                Assert.AreNotEqual(testItem1, testedObject[i]);

            Assert.Throws<ItemNotFoundException>(() => testedObject.Remove(songsName[2]));
        }

        [Test]
        public void SortTest()
        {
            string[] itemsName = {"norton", "bor", "coder", "amalia"};
            string[] sortedItemsName = {"amalia","bor","coder","norton"   };
            for(int i=0;i<itemsName.Length;i++)
                testedObject.Add(new Drama(name:itemsName[i]));

            for(int i=0;i<testedObject.Count;i++)
                Assert.AreEqual(testedObject[i].Name,itemsName[i]);
            testedObject.Sort();
            for(int i=0;i<testedObject.Count;i++)
                Assert.AreEqual(testedObject[i].Name,sortedItemsName[i]);
        }

        [Test]
        public void EmptyContainerTest()
        {
            Assert.Throws<ItemNotFoundException>(() => testedObject.Remove(0));
            Assert.Throws<ItemNotFoundException>(() => testedObject.Remove("test"));
            Assert.Throws<ItemNotFoundException>(() => testedObject.Remove(new Drama()));
            Assert.DoesNotThrow(() => testedObject.Sort());
        }

        [Test]
        public void foreachTest()
        {
            IProduct[] items = new IProduct[10];
            for(int i=0;i<items.Length;i++)
                testedObject.Add(items[i] = new Drama());

            int j = 0;
            foreach (IProduct item in items)
                Assert.AreSame(item,items[j++]);
        }

    }
}