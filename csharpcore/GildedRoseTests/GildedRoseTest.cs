﻿using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        // Generic Tests
        [Fact]
        public void Item_Name_Should_Not_Change()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("foo", Items[0].Name);
        }
        [Fact]
        public void Item_Sell_In_Should_Decrement()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(-1, Items[0].SellIn);
        }
        [Fact]
        public void Item_Should_Not_Have_Negative_Quality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 1, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(0, Items[0].Quality);
        }
        [Fact]
        public void Item_Should_Not_Have_Negative_Quality_When_Sell_In_Has_Passed()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 1 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(0, Items[0].Quality);
        }

        //Common Item Tests
        [Fact]
        public void Common_Item_Should_Degrade_Twice_As_Fast_After_Sell_In_Date()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(8, Items[0].Quality);
        }
        [Fact]
        public void UpdateGenericItem_Function_Degrades_Item_Quality_At_Normal_Rate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 1, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            Items[0] = app.UpdateGenericItem(Items[0]);
            Assert.Equal(9, Items[0].Quality);
        }
        [Fact]
        public void UpdateGenericItem_Function_Degrades_Item_Quality_Twice_As_Fast_After_Sell_In_Date()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            Items[0] = app.UpdateGenericItem(Items[0]);
            Assert.Equal(8, Items[0].Quality);
        }
        [Fact]
        public void UpdateGenericItem_Function_Should_Lower_Item_Sell_In_Date()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 1, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            Items[0] = app.UpdateGenericItem(Items[0]);
            Assert.Equal(0, Items[0].SellIn);
        }

        // Sulfuras Tests
        [Fact]
        public void Sulfuras_Should_Not_Degrade()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(80, Items[0].Quality);
        }
        [Fact]
        public void Sulfuras_Should_Not_Lower_Sell_In()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(0, Items[0].SellIn);
        }

        // Brie Tests
        [Fact]
        public void Brie_Quality_Should_Improve()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 1, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(1, Items[0].Quality);
        }
        [Fact]
        public void Brie_Quality_Should_Improve_At_Twice_Rate_After_Sell_In()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(2, Items[0].Quality);
        }
        [Fact]
        public void Brie_Quality_Should_Not_Exceed_Limit()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 1, Quality = 50 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(50, Items[0].Quality);
        }
        [Fact]
        public void UpdateAgedBrie_Function_Should_Improve_Quality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 1, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            Items[0] = app.UpdateAgedBrie(Items[0]);
            Assert.Equal(1, Items[0].Quality);
        }
        [Fact]
        public void UpdateAgedBrie_Function_Should_Improve_At_Twice_Rate_After_Sell_In()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            Items[0] = app.UpdateAgedBrie(Items[0]);
            Assert.Equal(2, Items[0].Quality);
        }
        [Fact]
        public void UpdateAgedBrie_Function_Should_Lower_Sell_In()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            Items[0] = app.UpdateAgedBrie(Items[0]);
            Assert.Equal(-1, Items[0].SellIn);
        }
        // Backstage Passes Tests
        [Fact]
        public void Backstage_Passes_Quality_Should_Improve_At_Normal_Rate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(1, Items[0].Quality);
        }
        [Fact]
        public void Backstage_Passes_Quality_Should_Improve_At_Double_Rate_At_10_Days()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(2, Items[0].Quality);
        }
        [Fact]
        public void Backstage_Passes_Quality_Should_Improve_At_Triple_Rate_At_5_Days()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(3, Items[0].Quality);
        }
        [Fact]
        public void Backstage_Passes_Quality_Should_Drop_To_Zero_After_Sell_In_Date()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(0, Items[0].Quality);
        }
        [Fact]
        public void UpdateBackstagePass_Function_Should_Improve_Quality_At_Normal_Rate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            Items[0] = app.UpdateBackstagePass(Items[0]);
            Assert.Equal(1, Items[0].Quality);
        }
        [Fact]
        public void UpdateBackstagePass_Function_Should_Improve_Quality_At_Twice_The_Normal_Rate_At_10_Days()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            Items[0] = app.UpdateBackstagePass(Items[0]);
            Assert.Equal(2, Items[0].Quality);
        }
        [Fact]
        public void UpdateBackstagePass_Function_Should_Improve_Quality_At_Triple_The_Normal_Rate_At_5_Days()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            Items[0] = app.UpdateBackstagePass(Items[0]);
            Assert.Equal(3, Items[0].Quality);
        }
        [Fact]
        public void UpdateBackstagePass_Function_Should_Drop_Quality_To_Zero_After_Sell_In_Date()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            Items[0] = app.UpdateBackstagePass(Items[0]); ;
            Assert.Equal(0, Items[0].Quality);
        }
        [Fact]
        public void UpdateBackstagePass_Function_Should_Lower_Sell_In_Date()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            Items[0] = app.UpdateBackstagePass(Items[0]); ;
            Assert.Equal(-1, Items[0].SellIn);
        }

        // Conjured Item Tests
        [Fact]
        public void UpdateConjuredItem_Function_Should_Lower_Sell_In_Date()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 } };
            GildedRose app = new GildedRose(Items);
            Items[0] = app.UpdateConjuredItem(Items[0]); ;
            Assert.Equal(2, Items[0].SellIn);
        }
        [Fact]
        public void UpdateConjuredItem_Function_Should_Degrade_Quality_At_Normal_Rate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 } };
            GildedRose app = new GildedRose(Items);
            Items[0] = app.UpdateConjuredItem(Items[0]); ;
            Assert.Equal(4, Items[0].Quality);
        }
        [Fact]
        public void UpdateConjuredItem_Function_Should_Degrade_Quality_At_Twice_The_Normal_Rate_After_Sell_In_Date()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 6 } };
            GildedRose app = new GildedRose(Items);
            Items[0] = app.UpdateConjuredItem(Items[0]); ;
            Assert.Equal(2, Items[0].Quality);
        }
    }
}
