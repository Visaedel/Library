using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repository
{
    public class RepositoryWrapper
    {
        private RepositoryContext context;
        private KategoriRepository kategoriRepository;
        private KullaniciRepository kullaniciRepository;
        private RollRepository rollRepository;
        private KiralamaRepository kiralamaRepository;
        private KitapRepository kitapRepository;
        private YayineviRepository yayineviRepository;

        public RepositoryWrapper(RepositoryContext context)
        {
            this.context = context;
        }

        public KategoriRepository KategoriRepository
        {
            get
            {
                if (kategoriRepository == null)
                    kategoriRepository = new KategoriRepository(context);
                return kategoriRepository;
            }
        }

        public KullaniciRepository KullaniciRepository
        {
            get
            {
                if (kullaniciRepository == null)
                    kullaniciRepository = new KullaniciRepository(context);
                return kullaniciRepository;
            }
        }
        public RollRepository RollRepository
        {
            get
            {
                if (rollRepository == null)
                    rollRepository = new RollRepository(context);
                return rollRepository;
            }
        }
        public KiralamaRepository KiralamaRepository
        {
            get
            {
                if (kiralamaRepository == null)
                    kiralamaRepository = new KiralamaRepository(context);
                return kiralamaRepository;
            }
        }
        public KitapRepository KitapRepository
        {
            get
            {
                if (kitapRepository == null)
                    kitapRepository = new KitapRepository(context);
                return kitapRepository;
            }
        }
        public YayineviRepository YayineviRepository
        {
            get
            {
                if (yayineviRepository == null)
                    yayineviRepository = new YayineviRepository(context);
                return yayineviRepository;
            }
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
        
    }
}
