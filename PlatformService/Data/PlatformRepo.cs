using PlatformService.Models;

namespace PlatformService.Data
{
    public class PlatformRepo(AppDbContext context) : IPlatformRepo
    {
        public void CreatePlatform(Platform entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            context.Platforms.Add(entity);
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return context.Platforms.ToList();
        }

        public Platform GetPlatfomById(int id)
        {
            return context.Platforms.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() >= 0;
        }
    }
}