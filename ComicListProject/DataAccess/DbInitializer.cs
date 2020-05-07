using DataStructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace MyComicList.Data
{
    public class DbInitializer
    {
        //public static void Seed(IApplicationBuilder applicationBuilder)
        public static void Seed(ApplicationDbContext context)
        {
            //ApplicationDbContext context =
            //    applicationBuilder.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            if (!context.Origins.Any())
            {
                context.Origins.AddRange(Origins.Select(c => c.Value));
            }
            if (!context.Authors.Any())
            {
                context.Authors.AddRange(Authors.Select(s => s.Value));
            }

            if (!context.Comics.Any())
            {
                context.AddRange
                (
                     new Comic
                     {
                         Title = "Naruto",
                         Info = "A huge demon known as the Kyuubi, the Nine-Tailed Fox, attacked Konohagakure, the Hidden Leaf Village, and wreaked havoc." +
                        "In order to put an end to the Kyuubi's rampage, the leader of the village, the Fourth Hokage, sacrificed his life and sealed the monstrous beast inside the newborn Naruto.",
                         Volumes = 72,
                         ImageUrl = "https://cdn.myanimelist.net/images/manga/3/117681.jpg",
                         ImageThumbnailUrl = "https://miro.medium.com/max/630/1*QaDoXxtLkRbmoyWNlbwdNA.jpeg",
                         IsPopularComic = true,
                         Origin = Origins["Japanese"],
                         Author = Authors["Kishimoto"]
                     },
                     new Comic
                     {
                         Title = "YuGiOh",
                         Info =
                        "Yami Yuugi transforming into the more bold and dangerous persona against his will in moments of great distress, Yuugi begins to moonlight as a vengeful vigilante, challenging " +
                        "bullies and evil-doers to risky games where failure results in fates worse than death.",
                         Volumes = 38,
                         ImageUrl = "https://cdn.myanimelist.net/images/manga/4/126293.jpg",
                         ImageThumbnailUrl = "https://i0.wp.com/itsthecomicbookcommunity.com/wp-content/uploads/2019/05/e7c8afc4fc4c921715f550ba4311316f.jpg?resize=1029%2C640&ssl=1",
                         IsPopularComic = false,
                         Origin = Origins["Japanese"],
                         Author = Authors["Takahashi"]
                     },
                     new Comic
                     {
                         Title = "Tokyo Ghoul",
                         Info = "Tokyo has become a cruel and merciless city—a place where vicious creatures called “ghouls” exist alongside humans. However, the greatest threat these ghouls pose is their " +
                        "dangerous ability to masquerade as humans and blend in with society.",
                         Volumes = 14,
                         ImageUrl = "https://cdn.myanimelist.net/images/manga/3/114037.jpg",
                         ImageThumbnailUrl = "https://wallpaperaccess.com/full/140176.jpg",
                         IsPopularComic = true,
                         Origin = Origins["Japanese"],
                         Author = Authors["Sui"]

                     },
                     new Comic
                     {
                         Title = "Berserk",
                         Info = "Guts, a former mercenary now known as the Black Swordsman is out for revenge. After a tumultuous childhood, he finally finds someone he respects and believes he can trust, only to have everything fall apart" +
                         "Guts, armed with a massive sword and monstrous strength, will let nothing stop him.",
                         Volumes = 7,
                         ImageUrl = "https://cdn.myanimelist.net/images/manga/1/157931.jpg",
                         ImageThumbnailUrl = "https://www.elsetge.cat/myimg/f/168-1688056_kentaro-miura-berserk-guts-wallpapers-hd-desktop-guts.jpg",
                         IsPopularComic = false,
                         Origin = Origins["Japanese"],
                         Author = Authors["Sui"]
                     },
                     new Comic
                     {
                         Title= "Attack on Titan",
                         Info = "In the present day, life within the walls has finally found peace, since the residents have not dealt with titans for many years. Eren Yeager, Mikasa Ackerman, and Armin Arlert are three young children " +
                        "who dream of experiencing all that the world has to offer",
                         Volumes = 6,
                         ImageUrl = "https://cdn.myanimelist.net/images/manga/2/37846.jpg",
                         ImageThumbnailUrl = "https://66.media.tumblr.com/7ab4d4f974c8124c0a51e6b4b4c8645f/tumblr_mvytj0RXKo1r9ee9go1_1280.jpg",
                         IsPopularComic = true,
                         Origin = Origins["Japanese"],
                         Author = Authors["Isayama"]
                     },
                     new Comic
                     {
                         Title = "One-Punch Man",
                         Info = "After rigorously training for three years, the ordinary Saitama has gained immense strength which allows him to take out anyone and anything with just one punch. He decides to put his new skill to good use " +
                         "by becoming a hero",
                         Volumes = 4,
                         ImageUrl = "https://cdn.myanimelist.net/images/manga/3/80661.jpg",
                         ImageThumbnailUrl = "https://i1.wp.com/www.thegeeklygrind.com/wp-content/uploads/2019/05/Photo-May-22-8-04-23-PM.jpg?fit=1661%2C1160",
                         IsPopularComic = true,
                         Origin = Origins["Japanese"],
                         Author = Authors["Isayama"]
                     },
		     ///////////////////////////////////////////////////////////////////////
                     new Comic
                     {
                         Title = "Tower of God",
                         Info = "Twenty-Fifth Bam had been alone his whole life until he met Rachel. Now, however, Rachel is set on climbing the Tower, and she is willing to leave Bam behind to do so. After Rachel disappears in a veil of light, Bam follows her, vowing to ascend the Tower in hopes of meeting her again.",
                         Volumes = 5,
                         ImageUrl = "https://cdn.myanimelist.net/images/manga/2/223694.jpg",
                         ImageThumbnailUrl = "https://pbs.twimg.com/media/EUHayr3XYAAM2Aj.jpg",
                         IsPopularComic = true,
                         Origin = Origins["Korean"],
                         Author = Authors["Jin-Hwan"]
                     },
                     new Comic
                     {
                         Title = "Bastard",
                         Info = "There is nowhere that Seon Jin can find solace. At school, he is ruthlessly bullied due to his unsettlingly quiet nature and weak appearance. However, this is not the source of Jin's insurmountable terror: the thing that he fears more than anything else is his own father.",
                         Volumes = 5,
                         ImageUrl = "https://cdn.myanimelist.net/images/manga/1/205549.jpg",
                         ImageThumbnailUrl = "https://i.pinimg.com/originals/4a/99/5c/4a995cdc8a38297d6234323105f33cd6.jpg",
                         IsPopularComic = false,
                         Origin = Origins["Korean"],
                         Author = Authors["Seung-Hee"]
                     },
                     new Comic
                     {
                         Title = "The Breaker",
                         Info = "Yi Shioon Shi-Woon's everyday life at Nine Dragons High School—which consists of beatings from fellow student Ho Chang and his gang—is far from ideal. ",
                         Volumes = 10,
                         ImageUrl = "https://cdn.myanimelist.net/images/manga/2/55867.jpg",
                         ImageThumbnailUrl = "https://i.pinimg.com/originals/fc/22/de/fc22de3eb24838622a46e1cdb222e66c.jpg",
                         IsPopularComic = true,
                         Origin = Origins["Korean"],
                         Author = Authors["Carnby"]
                     },
                     new Comic
                     {
                         Title = "Winter Woods",
                         Info = "Winter Woods is originally a webtoon which was officially published in a paperbook format by artePOP (아르테팝) on February 23, 2018. The series was published digitally in English by LINE Webtoon from November 19, 2014 to June 7, 2017.",
                         Volumes = 7,
                         ImageUrl = "https://cdn.myanimelist.net/images/manga/3/208547.jpg",
                         ImageThumbnailUrl = "https://i.ytimg.com/vi/E-yOFMjX38k/hqdefault.jpg",
                         IsPopularComic = false,
                         Origin = Origins["Korean"],
                         Author = Authors["Kentaro"]
                     },
                     new Comic
                     {
                         Title = "Annarasumanara",
                         Info = "There is a rumor that a magician lives in the tent by the abandoned theme park; some even say his magic is real. However, before he starts his show, he always asks his audience: Do you believe in magic ? ",
                         Volumes = 3,
                         ImageUrl = "https://cdn.myanimelist.net/images/manga/3/71143.jpg",
                         ImageThumbnailUrl = "https://coffeebearexpress.files.wordpress.com/2013/04/annarasumanara-26693371.jpg",
                         IsPopularComic = true,
                         Origin = Origins["Korean"],
                         Author = Authors["Seung-Hee"]
                     },
                     new Comic
                     {
                         Title = "One Thousand and One Nights",
                         Info = "Everyone knows about the story of Shahrazad and her wonderful tales of the Arabian nights. For one thousand and one nights, she entertained the mad Sultan with the adventures of Aladdin, Ali Baba, Sinbad, genies, and many other mystical creatures.",
                         Volumes = 6,
                         ImageUrl = "https://cdn.myanimelist.net/images/manga/3/6683.jpg",
                         ImageThumbnailUrl = "https://4.bp.blogspot.com/-N87oBquX4dU/TkCorvYuc8I/AAAAAAAABNA/R8iscUVdKzw/141.png?imgmax=16383",
                         IsPopularComic = false,
                         Origin = Origins["Korean"],
                         Author = Authors["Hichov"]
                     }
                );
            }

            context.SaveChanges();
        }

        private static Dictionary<string, Origin> origins;
        public static Dictionary<string, Origin> Origins
        {
            get
            {
                if (origins == null)
                {
                    var genresList = new Origin[]
                    {
                        new Origin { Name = "Japanese", Description="The comic is translated from Japanese", FlagUrl="https://cdn.webshopapp.com/shops/94414/files/54037182/japan-flag-icon-free-download.jpg"},
                        new Origin { Name = "Korean", Description="The comic is translated from korean", FlagUrl="https://cdn.webshopapp.com/shops/94414/files/54354268/south-korea-flag-icon-free-download.jpg"},

                    };

                    origins = new Dictionary<string, Origin>();

                    foreach (Origin genre in genresList)
                    {
                        origins.Add(genre.Name, genre);
                    }
                }

                return origins;
            }
        }
        private static Dictionary<string, Author> authors;
        public static Dictionary<string, Author> Authors
        {
            get
            {
                if (authors == null)
                {
                    var authorList = new Author[]
                    {
                        new Author {FirstName="Kishimoto",LastName="Kishimoto"}, 
                        new Author {FirstName="Hajime",LastName= "Isayama" },
                        new Author {FirstName="Ishida",LastName="Sui"},
                        new Author {FirstName="Kazuki",LastName="Takahashi"},
                        new Author {FirstName="Miura",LastName="Kentaro"},
                        new Author {FirstName="Park",LastName="Jin-Hwan"},
                        new Author {FirstName="Kim",LastName="Carnby"},
                        new Author {FirstName="Han",LastName="Seung-Hee"},
                        new Author {FirstName="Cosmos",LastName="Hichov"},
                    };

                    authors = new Dictionary<string, Author>();

                    foreach (Author author in authorList)
                    {
                        authors.Add(author.LastName, author);
                    }
                }

                return authors;
            }
        }
    }
}
