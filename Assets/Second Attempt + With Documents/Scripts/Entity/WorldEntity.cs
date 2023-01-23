namespace Xenoblade_Remake.Entity
{
    public class WorldEntity
    {
        private string entityName;

        public WorldEntity(string name)
        {
            entityName = name;
        }

        public string EntityName => entityName;
    }
}