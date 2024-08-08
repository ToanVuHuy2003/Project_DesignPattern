
namespace ClothingShop.Models
{
    public class DBDatabase
    {
        private static ClothingStore1Entities instance;
        private DBDatabase() { }

        public static ClothingStore1Entities Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new ClothingStore1Entities();
                }
                return instance;
            }
        }
    }
}