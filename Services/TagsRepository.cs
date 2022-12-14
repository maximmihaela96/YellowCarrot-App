using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YellowCarrot_App.Data;
using YellowCarrot_App.Models;

namespace YellowCarrot_App.Services
{
    class TagsRepository
    {
        private readonly AppDbContext _context;

        public TagsRepository(AppDbContext context)
        {
            _context = context;
        }
     /*   public void AddDefaultTags()
        { 

            _context.Tags.Add(new Tags()
            {
                TagName = "Desert",
            });

            _context.SaveChanges();
        }
     */
        public List<Tags> GetTags()
        {
            return _context.Tags.ToList();
        }

        public Tags? GetTag()
        {
            return null;
        }

        public void AddTag(Tags tagToAdd)
        {
            _context.Tags.Add(tagToAdd);
        }

        public void RemoveTag(Recipe tagToRemove)
        {
            //_context.Tags.Remove(tagToRemove);
        }
    }
}
