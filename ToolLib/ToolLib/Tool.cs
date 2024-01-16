namespace ToolLib
{
    public class Tool
    {
        public int Id { get; set; }
        public string Type { get; set; } // atleast 2 chars
        public int Price { get; set; }   // positive number
        public string Brand { get; set; }

        public void ValidateType()
        {
            if (Type == null)
            {
                throw new ArgumentNullException("Type is null");
            }

            if (Type.Length < 2)
            {
                throw new ArgumentException("Type must be atleast 2 characters");
            }
        }
        
        public void ValidatePrice()
        {
            if (Price < 0)
            {
                throw new ArgumentOutOfRangeException("Price must be a positive number");
            }
        }

        public void Validate()
        {
            ValidateType();
            ValidatePrice();
        }
    }
}