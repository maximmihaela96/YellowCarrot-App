using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YellowCarrot_App.Data;
using YellowCarrot_App.Models;

namespace YellowCarrot_App.Services
{
    internal class UnitOfWork
    {
        private readonly AppDbContext _context;
        private UserRepository? _userRepo;
        private RecipeRepository? _recipeRepo;
        private TagsRepository? _tagsRepo;
        private IngrediensRepository? _ingrediensRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public TagsRepository TagsRepository
        {
            get
            {
                if (_tagsRepo == null)
                {
                    _tagsRepo = new TagsRepository(_context);
                }

                return _tagsRepo;
            }
        }
        public RecipeRepository RecipeRepo
        {
            get
            {
                if (_recipeRepo == null)
                {
                    _recipeRepo = new RecipeRepository(_context);
                }

                return _recipeRepo;
            }
        }

        public UserRepository UserRepo
        {
            get
            {
                if (_userRepo == null)
                {
                    _userRepo = new UserRepository(_context);
                }

                return _userRepo;
            }
        }

        public IngrediensRepository IngredienceRepo
        {
            get
            {
                if (_ingrediensRepository == null)
                {
                    _ingrediensRepository = new IngrediensRepository(_context);
                }

                return _ingrediensRepository;
            }
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
