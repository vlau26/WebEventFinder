using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventBriteCatalog.Domain;
using Microsoft.EntityFrameworkCore;


namespace EventBriteAssignment3A.Data
{
    public static class CatalogSeed
    {
        public static void Seed(CatalogContext context)
        {
            if (!context.CatalogCategories.Any())
            {
                {
                    context.CatalogCategories.AddRange(GetPreConfiguredCategories());
                    context.SaveChanges();
                }
            }

            if (!context.CatalogItems.Any())
            {
                {
                    context.CatalogItems.AddRange(GetPreConfiguredCatalogItems());
                    context.SaveChanges();
                }
            }


            if (!context.CatalogLocations.Any())
            {
                {
                    context.CatalogLocations.AddRange(GetPreCongfiguredCatalogLocations());
                    context.SaveChanges();
                }



            }
        }


        private static IEnumerable<CatalogCategory> GetPreConfiguredCategories()
        {

            return new List<CatalogCategory>()

            {

                new CatalogCategory() {Category = "Music"},

                new CatalogCategory() {Category = "Health"},

                new CatalogCategory() {Category = "Food/Drink"},

                new CatalogCategory() {Category = "Outdoors"}

            };
        }


        private static IEnumerable<CatalogLocation> GetPreCongfiguredCatalogLocations()
        {

            return new List<CatalogLocation>()

            {

                new CatalogLocation() {Location = "Seattle"},

                new CatalogLocation() {Location = "Los Angeles"},

                new CatalogLocation() {Location = "Chicago"}

            };

        }
        private static IEnumerable<CatalogItem> GetPreConfiguredCatalogItems()
        {
            return new List<CatalogItem>()
            {
                // [event 1 - concert (music)]_ Capitol Hill Block Party 2019
                new CatalogItem() {CatalogCategoryId=1 CatalogLocationId=1,
                EventName = "Capitol Hill Block Party 2019", Price = 200, Description = "a large-scale music festival that originally started as " +
                "a charming neighborhood get-together " +
                "and has since morphed into a massive spectacle of Top-40 headliners and Seattle heavy hitters" +
                " converging during the dog days of summer in the Pike/Pine corridor. \nLocated at 925 East Pike Street, Seattle, WA 98122",
                EventStartTime = DateTime.Parse("07/19/2019 7:00PM"),
                EventEndTime = DateTime.Parse("07/20/2019 2:00AM"),
                PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/1" },

            // [event 2 - outdoor]_ 1000 Lights Water Lantern Festival 
                new CatalogItem() { CatalogCategoryId =4,CatalogLocationId=1,
                EventName = "1000 Lights Water Lantern Festival", Price= 25, Description = "Enjoy thousands of water lanterns at gently floating on the water to " +
                "create a spectacle at this one night only event with friends and family. " +
                "There will be carefully curated live musicians and food trucks! Located at Seattle Public Theater at 7312 West Green Lake Dr N, Seattle, WA 98103. " +
                "\nSchedule: \nGates open: 6:00 PM \nFestival: 6:00 PM - 9:00 PM \nLive Entertainment: 7:30-8:30 PM \nLantern Launch Window: 9:15 PM - 10:00 PM", 
                EventStartTime = DateTime.Parse("08/10/2019 6:00PM"),
                EventEndTime = DateTime.Parse("08/10/2019 10:00AM"),
                PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/2" },

                // [event 3 - Hiking(outdoors)]_ Chicago Group Hiking
                new CatalogItem() { CatalogCategoryId =4,CatalogLocationId=3,
                EventName = "Chicago Group Hiking", Price = 0, Description = "Hiking is the best way to stay healthy." +
                " Let's go for chilling group hike + lunch! It will be an 8-mile hike with 252 ft elevation gain." +
                " We will be hiking the Des Plaines River Trail: Old School County Forest to Des Plaines." +
                " This hike will be dog-friendly! Please bring plenty of water,sunscreen, appropriate clothing for the weather. \nMeet at head of Des Plaines River Trail",
                EventStartTime = DateTime.Parse("09/07/2019 11:30AM"),
                EventEndTime = DateTime.Parse("09/07/2019 4:00PM"),
                PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/3" },

                //[event 4 - kayak tour (outdoors)]_ Los Angeles River Kayak Tours, 2019, Elysian Valley
                new CatalogItem() {CatalogCategoryId = 4,CatalogLocationId = 2,
                EventName = "Los Angeles River Kayak Tours, 2019, Elysian Valley", Price = 55, Description = "Enjoy a next-level experience on a guided kayak tour " +
                "in the Elysian Valley Recreation Zone(a.k.a.the Glendale Narrows) and adjacent Frogtown on these special Saturday trips." +
                " This section has some Class - I rapids(light) and plenty of rocks to maneuver around.It's fun but not easy; " +
                "you should have prior intermediate - level kayaking experience. You'll learn how to be safe around rivers and get a fantastic workout. Expect to get wet. "
                + "\nMeet at 2900 Newell Street, Los Angeles, CA 90039",
                EventStartTime = DateTime.Parse("07/13/2019 3:00PM"),
                EventEndTime = DateTime.Parse("07/13/2019 5:00PM"),
                PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/4" },
                
                //[event 5 - festival (food & drink)]_ Chicago Food Truck Festival 2019
                new CatalogItem() {CatalogCategoryId = 3,CatalogLocationId = 3,
                EventName = "Chicago Food Truck Festival 2019", Price = 0, Description = "Chicago Food Truck Festival is one of the largest gathering " +
                "of food trucks in the Midwest with over 55 gourmet food trucks and 50,000foodies gathering over two days." +
                "Realizing the joy people received each dayfrom eating from their favorite food truck paired with entrepreneurs " +
                "following their dreams Chicago Food Truck Festival was created. Entry to the festival is free and food prices defer by each vendor. " +
                "The festival ends each night at 9:00PM. \nLocated at 2400 S.State St., Chicago, IL 60616",
                EventStartTime = DateTime.Parse("08/21/2019 11:30AM"),
                EventEndTime = DateTime.Parse("08/22/2019 6:00PM"),
                PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/5" },

                // event 6 - [some food] festival (food & drink)_ Seattle Night Market: Aloha
                new CatalogItem() {CatalogCategoryId = 3,CatalogLocationId = 1,
                EventName = "Seattle Night Market: Aloha", Price = 0, Description = "Hyper local, globally-inspired. Celebrating Polynesian cuisine from around the world " +
                "curbside at South Lake Union on August 17th.Over 100 food trucks and pop-ups inspired by global destinations around the world.Live entertainment " +
                "and free 21 + Moonlight Cinema series screening on the grass lawn at SLU Discovery Center.Family - friendly and always free at the SLU Saturday Market. " +
                "\nLocated at South Lake Union Saturday Market at 139 9th ave N, Seattle, WA 98109.",
                EventStartTime = DateTime.Parse("08/17/2019 4:00PM"),
                EventEndTime = DateTime.Parse("08/17/2019 10:00PM"),
                PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/6" },

                //event 7 - wine tasting (food & drink)_ Wine Camp 
                new CatalogItem() {CatalogCategoryId = 3,CatalogLocationId = 2,
                EventName = "Wine Camp", Price = 60, Description = "This 2-hour wine experience is packed with all you need to know about wine. " +
                "You’ll learn how wine is made, improve your ability to describe wine, find out the best way to serve wine, and we’ll even discuss food and wine pairing." +
                "At Wine Camp you’ll explore seven outstanding wines in a fun and relaxed setting.When you’re finished, you’ll be able  to enjoy wine at a higher level " +
                "and make confident purchases with your new, topical insights. \nMeet us at LearnAboutWine loft located at 530 Molino St. #218, Los Angeles, CA 90013.",
                EventStartTime = DateTime.Parse("09/08/2019 3:30PM"),
                EventEndTime = DateTime.Parse("09/08/2019 5:30PM"),
                PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/7"  },

                //event 8 - beer tasting (food & drink)_ Beer Tasting
                new CatalogItem() {CatalogCategoryId = 3,CatalogLocationId = 3,
                EventName = "Beer Tasting", Price = 15, Description = "This is our easiest and most popular way to see Chicago Breweries." +
                " Whether you are a couple on vacation, a group of friends visiting Chicago, or craving for good craft beer, " +
                "a Join - In Brewery Tour is a great way to discover the Chicago microbrew scene.We have 14 seats available on each tour so book your spot " +
                "now because seats fill up quickly." +
                "STRICTLY 21 and older: No exceptions.Public transportation is highly encouraged! \nMeet us at The Hyde located at 5115 S Harper Ave, Chicago, IL 60615.",
                EventStartTime = DateTime.Parse("07/17/2019 6:00PM"),
                EventEndTime = DateTime.Parse("07/18/2019 2:00AM"),
                PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/7"  },

                //event 9 – cooking class (food & drink)_ Cooking with Summer Berries
                new CatalogItem() {CatalogCategoryId = 3,CatalogLocationId = 3,
                EventName = "Cooking with Summer Berries", Price = 66, Description = "Summer is the season for blueberries, raspberries, strawberries, blackberries and more." +
                " Join us in this hands - on beginners’ class to turn these seasonal favorites delicious treats you can enjoy all year long. " +
                "We will cover making jam, flavored vinegar, and desserts! " +
                "\nLocated at 1000 Lake Cook Rd, Chicago, IL 60022.",
                EventStartTime = DateTime.Parse("08/17/2019 6:00PM"),
                EventEndTime = DateTime.Parse("08/18/2019 8:00PM"),
                PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/7"  },

                // event10 – food & drink _ Pierogi Making Class
                new CatalogItem() {CatalogCategoryId = 3,CatalogLocationId = 1,
                EventName = "Pierogi Making Class", Price = 15,Description = "This interactive class will cover all the techniques you need to know " +
                "to make your own pierogi from scratch." +
                "A portion of the class will be dedicated to discussing different pierogi fillings and well as different cooking techniques." +
                "The pierogi will be cooked and you will be able to take home your handmade products! \nLocated at 405 Union St., Seattle, WA 98101.",
                EventStartTime = DateTime.Parse("10/05/2019 4:00PM"),
                EventEndTime = DateTime.Parse("10/05/2019 6:00PM"),
                PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/7"  },

                
                // event11 - yoga class (health) _Start your Morning with Yoga & Cats
                new CatalogItem() { CatalogCategoryId = 2,CatalogLocationId = 1,
                EventName = "Start your Morning with Yoga & Cats", Price = 20, Description = "Start your weekend off right with cuddly cats and an energizing yoga sequence. " +
                "This all-levels class moves through a traditional Vinyasa flow with plenty of opportunities for deeper asanas(postures) " +
                "and petting cats.Take some time to strengthen your body, relaxyour mind, " +
                "and be here meow. \nLocated 1225 N 45th Street, Seattle, WA 98103.",
                EventStartTime = DateTime.Parse("08/21/2019 9:00AM"),
                EventEndTime = DateTime.Parse("08/21/2019 10:30AM"),
                PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/7"  },

                // event12 - Health_Community Health Fair 2019
                new CatalogItem() {CatalogCategoryId = 2,CatalogLocationId = 2,
                EventName = "Community Health Fair 2019", Price = 0, Description = "Join us for an awesome day filled with fun while learning ways to be healthier with " +
                "Kaiser Permanente. It is a great event for children and adults.There will be free consultations and screenings + freebies!Come out " +
                "and get your health popping!Some topics available include: stress relief / management, herbalism,  massage therapy, holistic medicine, " +
                "healthy cooking, mental health," +
                " and DIY projects for all ages! \nLocated at 3782 West Martin Luther King Junior Boulevard, Los Angles, CA 90008.",
                EventStartTime = DateTime.Parse("09/28/2019 10:00AM"),
                EventEndTime = DateTime.Parse("09/28/2019 3:00PM"),
                PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/7"  },

                // event13 - lavender weekend (outdoors)]_ Lavender Weekend 2019
                new CatalogItem() {CatalogCategoryId = 4,CatalogLocationId = 1,
                EventName = "Lavender Weekend 2019", Price = 0, Description = "Welcome to Seattle Lavender Weekend, where we celebrate all things lavender! " +
                "The world class street fair, lavender farm festivals and events, and a host of community events make the Lavender Weekend one of the biggest lavender " +
                "celebrations in the country.Come enjoy bursting activites during this three day celebration of everything lavender the third weekend in July at the Pike Place Market." +
                " \nLocated at 85 Pike St, Seattle, WA 98101 from noon until 3PM each day.",
                EventStartTime = DateTime.Parse("07/21/2019 12:00PM"),
                EventEndTime = DateTime.Parse("07/23/2019 3:00PM"),
                PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/7"  },

                // event14 - beginners piano lessons (music)_ Free Introductory Piano Session
                new CatalogItem() {CatalogCategoryId = 1,CatalogLocationId = 2,
                EventName = "Free Introductory Piano Session", Price = 0, Description = "At PLAY! Piano Studios students learn in 2-3 months through Simply Music what takes " +
                " traditional lessons 2 + years to learn. Attend this one - hour session to learn more about Simply Music,  what sets Simply Music apart from other traditional learning methods," +
                " see a sample lesson in action and get answers for any questions you may have. \nLocated at 5408 Kester Avenue Sherman Oaks, CA 91411.",
                EventStartTime = DateTime.Parse("08/17/2019 3:00PM"),
                EventEndTime = DateTime.Parse("08/17/2019 5:00PM"),
                PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/7"  },

                // event15 - local musical (music)_ All American Favorite: The Music Man
                new CatalogItem() {CatalogCategoryId = 1,CatalogLocationId = 3,
                EventName = "All American Favorite: The Music Man", Price = 300,  Description = "Coming to Chicago’s Goodman Theatre for Independence Week, " +
                "the All-American classic The Music Man is a Tony - winning musical - comedy - romance that follows the adventures of fast-talking “Professor” Harold Hill." +
                " The charming con man plans to trick the good people of an Iowa town into buying instruments for a boys’ band he has no intention of organizing," +
                " then marching off with their hard - earned cash.But there’s trouble right there in River City when he becomes fond of the townspeople and falls for the lovely Marian the Librarian, " +
                "even as she begins to see through his scheme. \nThe Goodman Theatre is located at 170 N Dearborn St, Chicago, IL 60601.",
                EventStartTime = DateTime.Parse("09/20/2019 8:00PM"),
                EventEndTime = DateTime.Parse("09/20/2019 11:00PM"),
                PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/7"  },

            };

        }
    }
}

