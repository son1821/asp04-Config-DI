namespace asp04.Service
{
    public class ProductName
    {
        private List<string> names { get; set; }
        public ProductName() {

            names = new List<string>()
            {
                "Iphone","Samsung","Oppo"
            };
        }
        public List<string> GetNames() => names;
    }
}
