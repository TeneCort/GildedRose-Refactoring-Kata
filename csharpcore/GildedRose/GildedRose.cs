﻿using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                if (item.Name == "Aged Brie")
                {
                    UpdateAgedBrie(item);
                }
                else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    UpdateBackstagePass(item);
                }
                else if (item.Name.Contains("Conjured"))
                {
                    UpdateConjuredItem(item);
                }
                else if (item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    UpdateGenericItem(item);
                }

                // Hard set quality threshold to 50 in case it's higher
                item.Quality = item.Quality >= 50 ? 50 : item.Quality;

                // Hard set quality threshold to 0 in case it's lower
                item.Quality = item.Quality <= 0 ? 0 : item.Quality;

                // Sulfuras quality is always 80
                if (item.Name == "Sulfuras, Hand of Ragnaros")
                    item.Quality = 80;
            }

        }
        /// <summary>
        /// Updates Generic item quality
        /// </summary>
        /// <param name="item">Generic Item</param>
        /// <returns></returns>
        public Item UpdateGenericItem(Item item)
        {
            if(item.SellIn > 0)
                item.Quality -= 1;
            else
                item.Quality -= 2;

            item.SellIn--;

            return item;
        }
        /// <summary>
        /// Updates Aged Brie quality
        /// </summary>
        /// <param name="item">Aged Brie</param>
        /// <returns></returns>
        public Item UpdateAgedBrie(Item item)
        {
            if (item.SellIn > 0)
                item.Quality += 1;
            else
                item.Quality += 2;

            item.SellIn--;

            return item;
        }
        /// <summary>
        ///    Updates Backstage Pass quality
        /// </summary>
        /// <param name="item">Backstage Pass</param>
        /// <returns></returns>
        public Item UpdateBackstagePass(Item item)
        {
            if (item.SellIn > 10)
                item.Quality += 1;
            else if (item.SellIn > 6)
                item.Quality += 2;
            else if (item.SellIn > 0)
                item.Quality += 3;
            else
                item.Quality = 0;

            item.SellIn--;

            return item;
        }
        /// <summary>
        /// Updates Conjured Item quality
        /// </summary>
        /// <param name="item">Conjured Item</param>
        /// <returns></returns>
        public Item UpdateConjuredItem(Item item)
        {
            if(item.SellIn > 0)
                item.Quality -= 2;
            else
                item.Quality -= 4;

            item.SellIn--;

            return item;
        }
    }
}
