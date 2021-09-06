using System.Collections.Generic;
using MongoDB.Driver;

namespace ECommerce.Product.API.Data
{
    public class ProductContextSeed
    {
        public static void SeedData(IMongoCollection<Entities.Product> productCollection)
        {
            bool existProduct = productCollection.Find(x => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetConfigureProducts());
            }
        }

        private static IEnumerable<Entities.Product> GetConfigureProducts()
        {
            return new List<Entities.Product>
            {
                new Entities.Product
                {
                    Name = "Simple Pleasures Peplum Blouse",
                    Category = "TOP",
                    Description = "Make it a prairie-chic moment in the Simple Pleasures Peplum Blouse! This cute top is made of a lightweight woven knit in a fun paisley print. It features a v-neckline with a functional tie and keyhole detail, long balloon sleeves with elastic cuffs and ruffle detailing, and an elastic waist with a peplum hem. Style the Simple Pleasures Blouse for work with black pants and heels, or dress it down with denim and a wide brim hat!",
                    Image = "top1.jpg",
                    Price = 100M,
                },
                new Entities.Product
                {
                    Name = "All You Ever Wanted Kimono",
                    Category = "TOP",
                    Description = "Who could ask for anything cuter than the All You Ever Wanted Kimono! This cute kimono is made of a lightweight chiffon in a boho print with a swiss dot texture. It has an open front with no closures, flowy wide sleeves, and an oversized fit. Style the All You Ever Wanted Kimono with a bodysuit and denim for an easy fall outfit!",
                    Image = "top2.jpg",
                    Price = 120M,
                },
                new Entities.Product
                {
                Name = "Zoe Ruched Shoulder Top - Olive",
                Category = "TOP",
                Description = "We're totally okay with hitting repeat on the Zoe Ruched Shoulder Top! This cute top is made of a lightweight woven knit. It features a rounded neckline with function drawstring ruching on the shoulders, short cap sleeves, and a relaxed fit with an elastic bottom hem. Style the Zoe Top with your favorite denim and boots for a trendy fall look!",
                Image = "top4.jpg",
                Price = 50M,
                },   
                new Entities.Product
                {
                Name = "Smart Style Plaid Mini Skirt",
                Category = "BOTTOM",
                Description = "Add a sophisticated touch to your fall look with the Smart Style Plaid Mini Skirt! This cute skirt is designed with a lightweight knit in a plaid pattern. It features a high-waisted fit with pleating and ends at a mini length. It also has a side zipper! Style the Smart Style Mini Skirt with a sweater and booties for fall!",
                Image = "bottom2.jpg",
                Price = 45M,
                },      
                new Entities.Product
                {
                Name = "Walk The Walk Mini Skirt",
                Category = "BOTTOM",
                Description = "Add a sophisticated touch to your fall look with the Smart Style Plaid Mini Skirt! This cute skirt is designed with a lightweight knit in a plaid pattern. It features a high-waisted fit with pleating and ends at a mini length. It also has a side zipper! Style the Smart Style Mini Skirt with a sweater and booties for fall!",
                Image = "bottom3.jpg",
                Price = 35M,
                }, 
                new Entities.Product
                {
                Name = "Anna Tie-Dye Leggings",
                Category = "BOTTOM",
                Description = "Get up, get moving, and get into style with the Anna Tie-Dye Leggings! These comfy leggings are designed with a thick, soft + stretchy compression knit in a fun tie-dye print. They feature a stretchy high waistband and full length legs!",
                Image = "bottom1.jpg",
                Price = 35M,
                }, 
                new Entities.Product
                {
                Name = "Make A Statement Linen Pants - Rust",
                Category = "BOTTOM",
                Description = "Take your look from drab to fab with the Make A Statement Linen Pants! These trendy pants are designed with a textured linen-blend material. They feature an elastic paperbag waistband with a functional tie, side pockets, side flap pockets with a functional button closure, and relaxed-fit tapered pant legs. Style the Make A Statement Pants for work with a blouse and heels, or dress them down with a bodysuit and mules!",
                Image = "bottom4.jpg",
                Price = 35M,
                }, 
                new Entities.Product
                {
                Name = "Everleigh Knit Tee - White",
                Category = "TOP",
                Description = "Chill at home and unwind from the week with the Everleigh Knit Tee! This cute tee is made of a soft and stretchy lightweight knit. It features a rounded neckline, short sleeves, and an oversized fit. Style the Everleigh Tee with denim and sneakers for a casual yet cute look!",
                Image = "top4.jpg",
                Price = 80M,
                }
            };
        }
    }
}