using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class UnitOfWork
    {
        private readonly ComicDbContext context;

        private ComicRepository comicRepository;
        private StudioRepository studioRepository;
        private OriginRepository originRepository;
        private GenreRepository genreRepository;

        private static UnitOfWork main;
        public static UnitOfWork Main
        {
            get
            {
                if (main == null)
                {
                    main = new UnitOfWork();
                }
                return main;
            }
        }

        public ComicRepository ComicRepository
        {
            get
            {
                if (this.ComicRepository == null)
                {
                    this.comicRepository = new ComicRepository(context);
                }

                return comicRepository;
            }
        }

        public StudioRepository StudioRepository
        {
            get
            {
                if (this.studioRepository == null)
                {
                    this.studioRepository = new StudioRepository();
                }

                return this.studioRepository;
            }
        }

        public OriginRepository OriginRepository
        {
            get
            {
                if (this.originRepository == null)
                {
                    this.originRepository = new OriginRepository();
                }

                return this.originRepository;
            }
        }

        public GenreRepository GenreRepository
        {
            get
            {
                if (this.genreRepository == null)
                {
                    this.genreRepository = new GenreRepository();
                }

                return this.genreRepository;
            }
        }

        private UnitOfWork()
        {
            this.context = new ComicDbContext();
        }
        //private void Dispose(bool disposing)
        //{
        //    if (!disposing) return;
        //    if (context == null) return;
        //    context.Dispose();
        //    context = null;
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

    }
}