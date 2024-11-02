using Microsoft.EntityFrameworkCore;
using ModulsDB;

namespace Music_Catalog.Data
{
    public class Seed
    {

        public static async Task SeedData(ApplicationContext context)
        {
            // Инициализация данных для артистов
            if (!context.Artists.Any())
            {
                var artists = new List<Artist>
                {
                    new Artist { Name = "Eminem" },
                    new Artist { Name = "Две тысячи ярдов" },
                    new Artist { Name = "IC3PEAK" },
                    new Artist { Name = "The Police" }
                };
                await context.Artists.AddRangeAsync(artists);
                await context.SaveChangesAsync();
            }

            // Инициализация данных для жанров
            if (!context.Genres.Any())
            {
                var genres = new List<Genre>
                {
                    new Genre { Title = "Rock" },
                    new Genre { Title = "Jazz" },
                    new Genre { Title = "Rap and Hip-hop" },
                    new Genre { Title = "Classic" },
                    new Genre { Title = "Electronic" },
                    new Genre { Title = "Disco" },
                    new Genre { Title = "Country" },
                    new Genre { Title = "Blues" },
                    new Genre { Title = "Reggae" },
                    new Genre { Title = "Indie" },
                    new Genre { Title = "Funk" },
                    new Genre { Title = "Alternative" }
                };

                await context.Genres.AddRangeAsync(genres);
                await context.SaveChangesAsync();
            }

            // Получение всех жанров и артистов для создания альбомов
            var rockGenre = await context.Genres.FirstOrDefaultAsync(g => g.Title == "Rock");
            var rapAndHipHopGenre = await context.Genres.FirstOrDefaultAsync(g => g.Title == "Rap and Hip-hop");
            var artistEminem = await context.Artists.FirstOrDefaultAsync(a => a.Name == "Eminem");
            var artistTwoThousandYards = await context.Artists.FirstOrDefaultAsync(a => a.Name == "Две тысячи ярдов");
            var artistIC3PEAK = await context.Artists.FirstOrDefaultAsync(a => a.Name == "IC3PEAK");
            var artistThePolice = await context.Artists.FirstOrDefaultAsync(a => a.Name == "The Police");

            // Инициализация данных для типов альбомов
            
            if (!context.TypeAlbums.Any())
            {
                var typeAlbums = new List<TypeAlbum> {
                    new TypeAlbum { Genre = rapAndHipHopGenre, Artist = artistEminem},
                    new TypeAlbum { Genre = rockGenre, Artist = artistTwoThousandYards},
                    new TypeAlbum { Genre = rockGenre, Artist = artistIC3PEAK},
                    new TypeAlbum { Genre = rockGenre, Artist = artistThePolice}
                };
                await context.TypeAlbums.AddRangeAsync(typeAlbums);
                await context.SaveChangesAsync();
            }
            
            // Инициализация данных для альбомов
            if (!context.Albums.Any())
            {
                var type1 = await context.TypeAlbums.FirstOrDefaultAsync(g => g.Artist.Name == "Eminem");
                var type2 = await context.TypeAlbums.FirstOrDefaultAsync(g => g.Artist.Name == "Две тысячи ярдов");
                var type3 = await context.TypeAlbums.FirstOrDefaultAsync(g => g.Artist.Name == "IC3PEAK");
                var type4 = await context.TypeAlbums.FirstOrDefaultAsync(g => g.Artist.Name == "The Police");
                var albums = new List<Album>
                {
                    new Album { Title = "Curtain Call: The Hits", YearRelease = 2005, TypeAlbum = type1},
                    new Album { Title = "The Eminem Show", YearRelease = 2002, TypeAlbum = type1 },
                    new Album { Title = "Cпичка", YearRelease = 2023,  TypeAlbum = type2},
                    new Album { Title = "Когда меня не станет главное не забудь…", YearRelease = 2024,  TypeAlbum = type2 },
                    new Album { Title = "Сказка", YearRelease = 2018,  TypeAlbum = type3 },
                    new Album { Title = "Certifiable", YearRelease = 2008,  TypeAlbum = type4 },
                    new Album { Title = "Flexible Strategies", YearRelease = 2018,  TypeAlbum = type4 }
                };

                await context.Albums.AddRangeAsync(albums);
                await context.SaveChangesAsync();
            }
            // Получение жанров и альбомов для создания песни
            var alternativeGenre = await context.Genres.FirstOrDefaultAsync(g => g.Title == "Alternative");
            var indieGenre = await context.Genres.FirstOrDefaultAsync(g => g.Title == "Indie");

            var curtainCallAlbum = await context.Albums.FirstOrDefaultAsync(g => g.Title == "Curtain Call: The Hits");
            var theEminemShowAlbum = await context.Albums.FirstOrDefaultAsync(g => g.Title == "The Eminem Show");
            var spichkaAlbum = await context.Albums.FirstOrDefaultAsync(g => g.Title == "Cпичка");
            var kogdaMenyaNeStanetAlbum = await context.Albums.FirstOrDefaultAsync(g => g.Title == "Когда меня не станет главное не забудь…");
            var skazkaAlbum = await context.Albums.FirstOrDefaultAsync(g => g.Title == "Сказка");
            var certifiableAlbum = await context.Albums.FirstOrDefaultAsync(g => g.Title == "Certifiable");
            var flexibleStrategiesAlbum = await context.Albums.FirstOrDefaultAsync(g => g.Title == "Flexible Strategies");
            // Инициализация данных для песен
            if (!context.Songs.Any())
            {
                var songs = new List<Song>
                {
                    new Song { Title = "Intro", YearRelease = 2005, Duration = (float)0.33, Album=curtainCallAlbum, Genre=rapAndHipHopGenre, Artist=artistEminem},
                    new Song { Title = "FACK", YearRelease = 2005, Duration = (float)3.25, Album=curtainCallAlbum, Genre=rapAndHipHopGenre, Artist=artistEminem},
                    new Song { Title = "The Way I Am", YearRelease = 2005, Duration =(float)4.50, Album=curtainCallAlbum, Genre=rapAndHipHopGenre, Artist=artistEminem},
                    new Song { Title = "My Name is", YearRelease = 2005, Duration = (float)4.28, Album=curtainCallAlbum, Genre=rapAndHipHopGenre, Artist=artistEminem},
                    new Song { Title = "Curtains Up", YearRelease = 2002, Duration = (float)0.30, Album=theEminemShowAlbum, Genre=rapAndHipHopGenre, Artist=artistEminem},
                    new Song { Title = "White America", YearRelease = 2002, Duration = (float)5.24, Album=theEminemShowAlbum, Genre=rapAndHipHopGenre, Artist=artistEminem},
                    new Song { Title = "Business", YearRelease = 2002, Duration = (float)4.11, Album=theEminemShowAlbum, Genre=rapAndHipHopGenre, Artist=artistEminem},

                    new Song { Title = "Спичка", YearRelease = 2023, Duration = (float)1.38, Album=spichkaAlbum, Genre=rockGenre, Artist=artistTwoThousandYards},
                    new Song { Title = "Среди грязи и лести", YearRelease = 2024, Duration = (float)2.50, Album=kogdaMenyaNeStanetAlbum, Genre=alternativeGenre, Artist=artistTwoThousandYards},
                    new Song { Title = "Крыши частных секторов", YearRelease = 2024, Duration = (float)2.09, Album=kogdaMenyaNeStanetAlbum, Genre=alternativeGenre, Artist=artistTwoThousandYards},
                    new Song { Title = "Терабайтами пост-панка", YearRelease = 2024, Duration = (float)2.05, Album=kogdaMenyaNeStanetAlbum, Genre=alternativeGenre, Artist=artistTwoThousandYards},
                    new Song { Title = "По клубам", YearRelease = 2024, Duration = (float)2.38, Album=kogdaMenyaNeStanetAlbum, Genre=alternativeGenre, Artist=artistTwoThousandYards},
                    new Song { Title = "Юными навсегда", YearRelease = 2024, Duration = (float)1.40, Album=kogdaMenyaNeStanetAlbum, Genre=alternativeGenre, Artist=artistTwoThousandYards},

                    new Song { Title = "Считалочка", YearRelease = 2018, Duration = (float)1.52, Album=skazkaAlbum, Genre=indieGenre, Artist=artistIC3PEAK},
                    new Song { Title = "Сказка", YearRelease = 2018, Duration = (float)2.45, Album=skazkaAlbum, Genre=indieGenre, Artist=artistIC3PEAK},
                    new Song { Title = "Привет", YearRelease = 2018, Duration = (float)2.45, Album=skazkaAlbum, Genre=indieGenre, Artist=artistIC3PEAK},

                    new Song { Title = "Message In A Bottle", YearRelease = 2008, Duration = (float)5.00, Album=certifiableAlbum, Genre=rockGenre, Artist=artistThePolice},
                    new Song { Title = "Walking On The Moon", YearRelease = 2008, Duration = (float)6.19, Album=certifiableAlbum, Genre=rockGenre, Artist=artistThePolice},
                    new Song { Title = "Driven To Tears", YearRelease = 2008, Duration = (float)5.50, Album=certifiableAlbum, Genre=rockGenre, Artist=artistThePolice},
                    new Song { Title = "Dead End Job", YearRelease = 2018, Duration = (float)3.35, Album=flexibleStrategiesAlbum, Genre=rockGenre, Artist=artistThePolice},
                    new Song { Title = "Landlord", YearRelease = 2018, Duration = (float)3.35, Album=flexibleStrategiesAlbum, Genre=rockGenre, Artist=artistThePolice}
                };
                await context.Songs.AddRangeAsync(songs);
                await context.SaveChangesAsync();
            }
            // Инициализация данных для коллекций
            if (!context.Collections.Any())
            {
                var collections = new List<Collection>
                {
                    new Collection { Title = "20x", Epoch = 2020 },
                    new Collection { Title = "10x", Epoch = 2010 },
                    new Collection { Title = "Rock Forever", Genre = rockGenre }
                };

                await context.Collections.AddRangeAsync(collections);
                await context.SaveChangesAsync();
            }
            // Получение коллекций и песен для создания связей песен и коллекций 
            var collection20x = await context.Collections.FirstOrDefaultAsync(c => c.Title == "20x");
            var collection10x = await context.Collections.FirstOrDefaultAsync(c => c.Title == "10x");
            var collectionRockForever = await context.Collections.FirstOrDefaultAsync(c => c.Title == "Rock Forever");

            var drivenToTearsSong = await context.Songs.FirstOrDefaultAsync(s => s.Title == "Driven To Tears");
            var deadEndJobSong = await context.Songs.FirstOrDefaultAsync(s => s.Title == "Dead End Job");
            var считалочкаSong = await context.Songs.FirstOrDefaultAsync(s => s.Title == "Считалочка");
            var messageInABottleSong = await context.Songs.FirstOrDefaultAsync(s => s.Title == "Message In A Bottle");
            var curtainsUpSong = await context.Songs.FirstOrDefaultAsync(s => s.Title == "Curtains Up");
            var whiteAmericaSong = await context.Songs.FirstOrDefaultAsync(s => s.Title == "White America");
            var landlordSong = await context.Songs.FirstOrDefaultAsync(s => s.Title == "Landlord");
            var businessSong = await context.Songs.FirstOrDefaultAsync(s => s.Title == "Business");

            // Инициализация данных для связи между коллекциями и песнями 
            if (!context.SongCollections.Any())
            {
                var songCollections = new List<SongCollection>
                {
                    new SongCollection { Song = drivenToTearsSong, Collection = collection20x },
                    new SongCollection { Song = deadEndJobSong, Collection = collection20x },
                    new SongCollection { Song = считалочкаSong, Collection = collection20x },

                    new SongCollection { Song = messageInABottleSong, Collection = collection10x },
                    new SongCollection { Song = curtainsUpSong, Collection = collection10x },
                    new SongCollection { Song = whiteAmericaSong, Collection = collection10x },

                    new SongCollection { Song = landlordSong, Collection = collectionRockForever },
                    new SongCollection { Song = deadEndJobSong, Collection = collectionRockForever },
                    new SongCollection { Song = messageInABottleSong, Collection = collectionRockForever },
                    new SongCollection { Song = businessSong, Collection = collectionRockForever }
                };

                await context.SongCollections.AddRangeAsync(songCollections);
                await context.SaveChangesAsync();
            }
        }
    }
}
