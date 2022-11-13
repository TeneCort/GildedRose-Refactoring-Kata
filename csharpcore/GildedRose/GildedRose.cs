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
                if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    item.Quality = item.Quality - 1;
                }
                else
                {
                    item.Quality = item.Quality + 1;

                    if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (item.SellIn < 11)
                        {
                            item.Quality = item.Quality + 1;
                        }

                        if (item.SellIn < 6)
                        {
                            item.Quality = item.Quality + 1;
                        }
                    }
                }

                if (item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    item.SellIn = item.SellIn - 1;
                }

                if (item.SellIn < 0)
                {
                    if (item.Name != "Aged Brie")
                    {
                        if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            item.Quality = item.Quality - 1;
                            
                        }
                        else
                        {
                            item.Quality = item.Quality - item.Quality;
                        }
                    }
                    else
                    {
                        item.Quality = item.Quality + 1;
                    }
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
    }
}
