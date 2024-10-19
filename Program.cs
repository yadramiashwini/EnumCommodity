namespace EnumCommodity
{
    enum CommodityCategory   //enum cpmmoditycategory
    {
        Furniture,
        Grocery,
        service
    }

    class Commodity
    {
        public Commodity(CommodityCategory category, String commodityName, int commodityQuantity, double commodityPrice)  //commodity     constructor
        {
            this.Category = category; 
            this.CommodityQuantity = commodityQuantity;
            this.CommodityName = commodityName;
            this.CommodityPrice = commodityPrice;
        }
        public CommodityCategory Category { get; set; }     //properties 
        public string CommodityName { get; set; }
        public int CommodityQuantity { get; set; }
        public double CommodityPrice { get; set; }
    }
    class PrepareBill       //creating preparebill
    {
        private IDictionary<CommodityCategory, double> _taxRates { get; }
        public PrepareBill()
        {
            _taxRates = new Dictionary<CommodityCategory, double>();
        }
        public void SetTaxRates(CommodityCategory category, double taxRate)
        {
            _taxRates[category] = taxRate;
           
        }
        public double CalculateBillAmount(IList<Commodity> items) //method to calculte amount
        {
              double amount = 0.0;
            double _taxRates1;
            foreach (var item in items)
            {

                if (!_taxRates.ContainsKey(item.Category))
                {
                    throw new ArgumentException();
                }
                else
                {
                    _taxRates1 = _taxRates[item.Category];
                    amount += _taxRates[item.Category];
                }
            }
            
            return amount;
        }

        static void Main(string[] args)         //main method
        {
            var commodities = new List<Commodity>()
            {
                new Commodity(CommodityCategory.Furniture,"Bed",2,50000),
                new Commodity(CommodityCategory.Grocery,"Flour",5,80),
                new Commodity(CommodityCategory.service,"Insurance",8,8500),
            };
            var PrepareBill = new PrepareBill();      //creating instance
            PrepareBill.SetTaxRates(CommodityCategory.Furniture, 18);
            PrepareBill.SetTaxRates(CommodityCategory.Grocery, 5);
            PrepareBill.SetTaxRates(CommodityCategory.service, 12);

            var billAmount = PrepareBill.CalculateBillAmount(commodities);
            Console.WriteLine($"{billAmount}");

        }
    }
}
    

